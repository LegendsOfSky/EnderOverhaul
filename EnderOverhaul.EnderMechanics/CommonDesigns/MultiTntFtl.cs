using System.Collections.Concurrent;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using Google.OrTools.Sat;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class MultiTntFtl
{
    /// <param name="tntConfigs"> A TNT config stored as TNT (key) and TNT count (value) dictionary. </param>
    /// <remarks>
    ///     <b>REMARKS:</b> The method will not terminate when the Y coordinate of the ender pearl is below any value. It only terminates when the parameter
    ///         <see cref="travellingTickCount"/> is reached.
    /// </remarks>
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

    /// <param name="maxTntCount">
    ///     Maximum number of TNT entities to consider.
    ///     <para> <b>REMARKS:</b> Setting to zero does not disable this feature. </para>
    /// </param>
    /// <param name="maxTravellingTickCount">
    ///     Maximum simulation ticks. Should be less than or equal to the approximate distance from source to destination. Larger values add unnecessary performance overhead.
    /// </param>
    /// <param name="maxSearchTimeForEachTick"> Maximum time for searching solution in each tick (in seconds). </param>
    /// <param name="numberOfSearchWorkers">
    ///     Number of workers will or-tools creates. Set to 0 for or-tools to decide.
    ///     <b>REMARKS:</b> Only change this value if you know how "num_search_workers" parameter works in or-tools.
    /// </param>
    /// <summary> Calculate TNT amount while optimizing the error between final location and destination. </summary>
    /// <returns>
    ///     A list of results ideally one for each tick.
    ///     <para> <b>REMARKS:</b> Does not guarantee to find a solution for each tick. </para>
    /// </returns>
    /// <remarks>
    ///     <b>REMARKS:</b>
    ///     <list type="bullet">
    ///         <item> The algorithm does not filter out results with error larger than any value; </item>
    ///         <item> It may take a long to search for results. Consider creating new thread to run it when needed; </item>
    ///     </list>
    /// </remarks>
    public static List<MultiTntFtlTntConfigResult> CalculateTntAmount(
        ThrownEnderpearl enderPearl , Vector2D destination , List<PrimedTnt> tnts , int maxTntCount ,
        int maxTravellingTickCount = 64 , double maxSearchTimeForEachTick = 5D , int numberOfSearchWorkers = 0 , bool allowMultiThread = false)
    {
        List<TntConfig> tntConfigs = [];
        tntConfigs.AddRange(
                tnts.Select((t , i) => new TntConfig { GroupID = i , MaxTntCount = maxTntCount , Tnt = t })
            );
        return CalculateTntAmount(
                enderPearl , destination , tntConfigs , maxTravellingTickCount , maxSearchTimeForEachTick , numberOfSearchWorkers , allowMultiThread
            );
    }

    /// <param name="maxTravellingTickCount">
    ///     Maximum simulation ticks. Should be less than or equal to the approximate distance from source to destination. Larger values add unnecessary performance overhead.
    /// </param>
    /// <param name="maxSearchTimeForEachTick"> Maximum time for searching solution in each tick (in seconds). </param>
    /// <param name="numberOfSearchWorkers">
    ///     Number of workers will or-tools creates. Set to 0 for or-tools to decide.
    ///     <b>REMARKS:</b> Only change this value if you know how "num_search_workers" parameter works in or-tools.
    /// </param>
    /// <summary> Calculate TNT amount while optimizing the error between final location and destination. </summary>
    /// <returns>
    ///     A list of results ideally one for each tick.
    ///     <para> <b>REMARKS:</b> Does not guarantee to find a solution for each tick. </para>
    /// </returns>
    /// <remarks>
    ///     <b>REMARKS:</b>
    ///     <list type="bullet">
    ///         <item> The algorithm does not filter out results with error larger than any value; </item>
    ///         <item> It may take a long to search for results. Consider creating new thread to run it when needed; </item>
    ///     </list>
    /// </remarks>
    public static List<MultiTntFtlTntConfigResult> CalculateTntAmount(
        ThrownEnderpearl enderPearl , Vector2D destination , List<TntConfig> tntConfigs ,
        int maxTravellingTickCount = 64 , double maxSearchTimeForEachTick = 5D , int numberOfSearchWorkers = 0 , bool allowMultiThread = false)
    {
        Vector2D distance = destination - (Vector2D)enderPearl.Position;

        ConcurrentBag<MultiTntFtlTntConfigResult> results = [];
        int degreeOfParallelism = allowMultiThread
            ? numberOfSearchWorkers > 1
                ? Math.Max(1 , Environment.ProcessorCount / numberOfSearchWorkers)
                : Environment.ProcessorCount
            : 1;
        ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = degreeOfParallelism };
        ParallelLoopResult parallelResult = Parallel.For(1 , maxTravellingTickCount + 1 , parallelOptions , (tick) =>
        {
            ThrownEnderpearl tntCountDivisorSampler = new ThrownEnderpearl().WithMotion(1 , 0 , 1);
            for (int i = 0; i < tick; i++)
                tntCountDivisorSampler.Tick();
            double divisor = tntCountDivisorSampler.Position.X;

            Vector2D targetMotion = distance * (1 / divisor) - (Vector2D)enderPearl.Motion;
            Dictionary<TntConfig , int>? orToolSolution = CalculateOptimalAmountForSpecificMotion(
                    enderPearl.Position , targetMotion - (Vector2D)enderPearl.Motion , tntConfigs ,
                    maxSearchTimeForEachTick , numberOfSearchWorkers
                );
            if (orToolSolution is null)
                return;

            ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
            foreach ((TntConfig tntConfig , int tntCount) in orToolSolution)
                tntConfig.Tnt.AccelerateEntity(testEnderPearl , tntCount: tntCount);
            for (int j = 0; j < tick; j++)
                testEnderPearl.Tick();
            results.Add(
                    new MultiTntFtlTntConfigResult
                    {
                        Error           = (Vector2D)testEnderPearl.Position - destination ,
                        TntConfig       = orToolSolution.ToDictionary(solution => solution.Key.Tnt , solution => solution.Value) ,
                        TravellingTicks = tick ,
                    }
                );
        });
        return results
            .Where(result => result.TntConfig.Max(config => config.Value) > 0)
            .Distinct()
            .ToList();
    }

    private static Dictionary<TntConfig , int>? CalculateOptimalAmountForSpecificMotion(
        Vector3D enderPearlPos , Vector2D targetMotion , List<TntConfig> tntConfigsIn , double maxSearchTimeForEachTick = 30D , int numberOfSearchWorkers = 0)
    {
        List<TntConfig> tntConfigs = tntConfigsIn.Where(config => config.MaxTntCount >= 1).ToList();
        int maxOfMaxTntCount = tntConfigs.Max(config => config.MaxTntCount);
        if (maxOfMaxTntCount <= 0)
            throw new ArgumentOutOfRangeException(
                    nameof(tntConfigsIn) , "All MaxTntCount in tntConfigs are less than or equal to 0. Expected to have at least some configs with MaxTntCount >= 1."
                );

        const long Scale = 1L << 26;  // the scaling factor is determined by having 12 digits storing integer part of the 64bit fixed point decimal, then cut into half
                                      //     because when two 26bits fixed point decimal multiplied together, it left 12 digits for integer part of a final 64bit fixed
                                      //     point decimal.

        double[,] tntMotions = new double[tntConfigs.Count , 2];
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
        LinearExpr summedMotionX = tntAmounts[0] * (long)Math.Round(tntMotions[0 , 0] * Scale) , summedMotionZ = tntAmounts[0] * (long)Math.Round(tntMotions[0 , 1] * Scale);
        for (int i = 1; i < tntConfigs.Count; i++)
        {
            summedMotionX += tntAmounts[i] * (long)Math.Round(tntMotions[i , 0] * Scale);
            summedMotionZ += tntAmounts[i] * (long)Math.Round(tntMotions[i , 1] * Scale);
        }
        IntVar errorX = model.NewIntVar(int.MinValue / 4 , int.MaxValue / 4 , "error_x") , errorZ = model.NewIntVar(int.MinValue / 4 , int.MaxValue / 4 , "error_z");
        model.Add(errorX == summedMotionX - (long)Math.Round(targetMotion.X * Scale));
        model.Add(errorZ == summedMotionZ - (long)Math.Round(targetMotion.Z * Scale));
        IntVar squaredErrorX = model.NewIntVar(0 , long.MaxValue / 4 , "sqErr_x") , squaredErrorZ = model.NewIntVar(0 , long.MaxValue / 4 , "sqErr_z");
        model.AddMultiplicationEquality(squaredErrorX , [errorX , errorX]);
        model.AddMultiplicationEquality(squaredErrorZ , [errorZ , errorZ]);
        model.Minimize(squaredErrorX + squaredErrorZ);

        string validationError = model.Validate();
        if (!string.IsNullOrEmpty(validationError))
            throw new Exception(validationError);

        /* Solve the quadratic programming problem and extract the result */
        CpSolver solver = new CpSolver();
        solver.StringParameters = $"max_time_in_seconds:{maxSearchTimeForEachTick},num_search_workers:{numberOfSearchWorkers}";
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
                throw new Exception("Unknow or Invalid model.");
        }
    }
}
