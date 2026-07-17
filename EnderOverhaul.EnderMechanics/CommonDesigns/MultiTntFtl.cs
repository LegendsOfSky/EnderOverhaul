using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using Google.OrTools.Sat;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class MultiTntFtl
{
    public static List<ThrownEnderpearl> CalculateEnderPearlTrace(ThrownEnderpearl enderPearl , Dictionary<PrimedTnt , int> tntConfigs , int travellingTickCount = 128)
    {
        ThrownEnderpearl enderPearlTraceSampler = enderPearl.DeepCopy();
        foreach ((PrimedTnt tnt , int tntCount) in tntConfigs)
            tnt.AccelerateEntity(enderPearlTraceSampler , tntCount: tntCount);
        List<ThrownEnderpearl> result = new List<ThrownEnderpearl>(travellingTickCount + 1) { enderPearlTraceSampler.DeepCopy() };
        for (int i = 0; i < travellingTickCount; i++)
        {
            enderPearlTraceSampler.Tick();
            result.Add(enderPearlTraceSampler.DeepCopy());
        }
        return result;
    }

    public static List<Dictionary<PrimedTnt , int>> CalculateTntAmount(
        ThrownEnderpearl enderPearl , Vector2D destination , List<PrimedTnt> tnts , int maxTntCount , int maxTicks = 256)
    {
        List<TntConfig> tntConfigs = [];
        tntConfigs.AddRange(
                tnts.Select((t , i) => new TntConfig { GroupID = i , MaxTntCount = maxTntCount , Tnt = t })
            );
        return CalculateTntAmount(enderPearl , destination , tntConfigs , maxTicks);
    }

    public static List<Dictionary<PrimedTnt , int>> CalculateTntAmount(
        ThrownEnderpearl enderPearl , Vector2D destination , List<TntConfig> tntConfigs , int maxTicks = 256)
    {
        List<Dictionary<PrimedTnt , int>> results = [];
        Vector2D distance = destination - (Vector2D)enderPearl.Position;
        ThrownEnderpearl tntCountDivisorSampler = new ThrownEnderpearl().WithMotion(1 , 0 , 1);
        for (int i = 0; i < maxTicks; i++)
        {
            tntCountDivisorSampler.Tick();
            double divisor = tntCountDivisorSampler.Position.X;
            
            Vector2D targetMotion = distance * (1 / divisor) - (Vector2D)enderPearl.Motion;
            Dictionary<TntConfig , int>? orToolSolution = CalculateOptimalAmountForSpecificMotion(enderPearl.Position , targetMotion - (Vector2D)enderPearl.Motion , tntConfigs);
            if (orToolSolution is not null)
                results.Add(orToolSolution.ToDictionary(solution => solution.Key.Tnt , solution => solution.Value));
        }
        return results;
    }

    private static Dictionary<TntConfig , int>? CalculateOptimalAmountForSpecificMotion(Vector3D enderPearlPos , Vector2D targetMotion , List<TntConfig> tntConfigsIn)
    {
        List<TntConfig> tntConfigs = tntConfigsIn.Where(config => config.MaxTntCount >= 1).ToList();
        int maxOfMaxTntCount = tntConfigs.Max(config => config.MaxTntCount);
        if (maxOfMaxTntCount <= 0)
            throw new ArgumentOutOfRangeException(
                    nameof(tntConfigsIn) , "All MaxTntCount in tntConfigs are less than or equal to 0. Expected to have at least some configs with MaxTntCount >= 1."
                );

        const long scale = 1L << 26;  // the scaling factor is determined by having 12 digits storing integer part of the 64bit fixed point decimal, then cut into half
                                      //     because when two 26bits fixed point decimal multiplied together, it left 12 digits for integer part of a final 64bit fixed
                                      //     point decimal.

        double[,] tntMotions = new double[2 , tntConfigs.Count];
        for (int i = 0; i < tntConfigs.Count; i++)
        {
            ThrownEnderpearl motionSampler = new ThrownEnderpearl().WithPosition(enderPearlPos);
            tntConfigs[i].Tnt.AccelerateEntity(motionSampler);
            (tntMotions[i , 0] , tntMotions[i , 1]) = (motionSampler.Motion.X , motionSampler.Motion.Z);
        }

        CpModel model = new CpModel();
        IntVar[] tntAmounts = new IntVar[tntConfigs.Count];
        for (int i = 0; i < tntConfigs.Count; i++)
            tntAmounts[i] = model.NewIntVar(0 , tntConfigs[i].MaxTntCount , $"tntAmounts_{i}");

        /* Create constraint to only allow one set of TNT to be used within the same batch */
        Dictionary<int , LinearExpr> groupConstraints = new Dictionary<int , LinearExpr>();
        BoolVar[] tntUsedIndicators = new BoolVar[tntConfigs.Count];
        IntVar[] tntFeasibleAmounts = new IntVar[tntConfigs.Count];
        for (int i = 0; i < tntConfigs.Count; i++)
        {
            tntUsedIndicators[i] = model.NewBoolVar($"tntUsedIndicators_{i}");
            tntFeasibleAmounts[i] = model.NewIntVar(0 , tntConfigs[i].MaxTntCount , $"tntAuxAmounts_{i}");
            model.AddMultiplicationEquality(tntAmounts[i] , [tntUsedIndicators[i] , tntFeasibleAmounts[i]]);

            LinearExpr? expr = groupConstraints.TryGetValue(tntConfigs[i].GroupID , out expr) ? expr + tntUsedIndicators[i] : tntUsedIndicators[i];
            groupConstraints[tntConfigs[i].GroupID] = expr;
        }
        foreach ((_ , LinearExpr constraint) in groupConstraints)
            model.Add(constraint <= 1);

        /* Construct the objective function to be minimized */
        LinearExpr summedMotionX = tntAmounts[0] * (long)Math.Round(tntMotions[0 , 0] * scale) , summedMotionZ = tntAmounts[0] * (long)Math.Round(tntMotions[0 , 1] * scale);
        for (int i = 1; i < tntConfigs.Count; i++)
        {
            summedMotionX += tntAmounts[i] * (long)Math.Round(tntMotions[i , 0] * scale);
            summedMotionZ += tntAmounts[i] * (long)Math.Round(tntMotions[i , 1] * scale);
        }
        IntVar errorX = model.NewIntVar(int.MinValue / 4 , int.MaxValue / 4 , "error_x") , errorZ = model.NewIntVar(int.MinValue / 4 , int.MaxValue / 4 , "error_z");
        model.Add(errorX == summedMotionX - (long)Math.Round(targetMotion.X * scale));
        model.Add(errorZ == summedMotionZ - (long)Math.Round(targetMotion.Z * scale));
        IntVar squaredErrorX = model.NewIntVar(0 , long.MaxValue / 4 , "sqErr_x") , squaredErrorZ = model.NewIntVar(0 , long.MaxValue / 4 , "sqErr_z");
        model.AddMultiplicationEquality(squaredErrorX , [errorX , errorX]);
        model.AddMultiplicationEquality(squaredErrorZ , [errorZ , errorZ]);
        model.Minimize(squaredErrorX + squaredErrorZ);

        string validationError = model.Validate();
        if (!string.IsNullOrEmpty(validationError))
            throw new Exception(validationError);

        /* Solve the quadratic programming problem and extract the result */
        CpSolver solver = new CpSolver();
        solver.StringParameters = "max_time_in_seconds:60";
        CpSolverStatus status = solver.Solve(model);
        switch (status)
        {
            case CpSolverStatus.Optimal:
            case CpSolverStatus.Feasible:
                Dictionary<TntConfig , int> result = new Dictionary<TntConfig , int>();
                for (int i = 0; i < tntConfigs.Count; i++)
                    result[tntConfigs[i]] = (int)solver.Value(tntAmounts[i]);
                return result;

            case CpSolverStatus.Infeasible:
                return null;

            default:
                throw new Exception();
        }
    }
}
