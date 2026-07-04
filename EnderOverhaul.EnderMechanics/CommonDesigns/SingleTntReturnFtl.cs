using EnderOverhaul.EnderDynamics.Minecraft;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class SingleTntReturnFtl
{
    /// <remarks>
    ///     <b>REMARKS:</b> The method will not terminate when the Y coordinate of the ender pearl is below any value. It only terminates when the parameter
    ///         <see cref="travellingTickCount"/> is reached.
    /// </remarks>
    public static List<ThrownEnderpearl> CalculateEnderPearlTrace(ThrownEnderpearl enderPearl , PrimedTnt tnt , int tntCount , int travellingTickCount = 128)
    {
        ThrownEnderpearl tracer = enderPearl.DeepCopy();
        tnt.AccelerateEntity(tracer , tntCount: tntCount);
        List<ThrownEnderpearl> results = new List<ThrownEnderpearl>(travellingTickCount + 1) { tracer.DeepCopy() };
        for (int i = 0; i < travellingTickCount; i++)
        {
            tracer.Tick();
            results.Add(tracer.DeepCopy());
        }
        return results;
    }

    /// <param name="maxTravellingTickCount">
    ///     The maximum number of ticks to simulate. This value should be less than or equal to the distance; using a larger value creates unnecessary performance overhead.
    /// </param>
    /// <returns>
    ///     Returns a set of distinct TNT configurations. Ideally, for each tick, up to 3 results are generated. Each of them are:
    ///     <list type="number">
    ///         <item> a landing location that has almost the exact X coordinate compare to destination; </item>
    ///         <item> a landing location that has almost the exact Z coordinate compare to destination; </item>
    ///         <item> a landing location that has the smallest error distance from ender pearl to destination. </item>
    ///     </list>
    /// </returns>
    public static List<SingleTntReturnFtlTntConfigResult>? CalculateTntAmountWithFixTntLocation(
        ThrownEnderpearl enderPearl , PrimedTnt tnt , Vector2D destination ,
        int maxTnt = int.MaxValue, int maxErrorPerAxis = 256 , int maxTravellingTickCount = 128 , double maxAngleErrorOnAccelerateDirection = 30D)
    {
        Vector2D motion2D = (Vector2D)EnderMechanicsUtils.CalculateMotionOfEnderPearlAcceleratedTnt(tnt , enderPearl.Position);
        Vector2D distance = destination - (Vector2D)enderPearl.Position;

        /* return null if the angle between motion and destination direction is larger than 30 degrees */
        double cosOfAngles = Math.Cos(MathHelper.DegreeToRadiant(maxAngleErrorOnAccelerateDirection));
        if (motion2D.ComputeDotProductWith(distance) < cosOfAngles * motion2D.Length * distance.Length)
            return null;

        ThrownEnderpearl tntCountDivisorSampler = new ThrownEnderpearl().WithMotion(1 , 0 , 1);
        List<SingleTntReturnFtlTntConfigResult> results = new List<SingleTntReturnFtlTntConfigResult>(maxTravellingTickCount * 3);
        for (int i = 1; i <= maxTravellingTickCount; i++)
        {
            tntCountDivisorSampler.Tick();
            double divisor = tntCountDivisorSampler.Position.X;
            Vector2D targetMotion = distance * (1 / divisor) - (Vector2D)enderPearl.Motion;


            int tntCountForXAligned = (int)Math.Round(targetMotion.X / motion2D.X);
            ThrownEnderpearl enderPearlTesterForXAligned = enderPearl.DeepCopy();
            tnt.AccelerateEntity(enderPearlTesterForXAligned , tntCount: tntCountForXAligned);
            for (int j = 0; j < i; j++)
                enderPearlTesterForXAligned.Tick();
            Vector2D errorForXAligned = (Vector2D)enderPearlTesterForXAligned.Position - destination;
            if (Math.Abs(errorForXAligned.GetDominantEntry()) <= maxErrorPerAxis && tntCountForXAligned <= maxTnt)
                results.Add(
                        new SingleTntReturnFtlTntConfigResult { TravellingTicks = i , Tnt = tnt , TntCount = tntCountForXAligned , Error = errorForXAligned }
                    );

            int tntCountForZAligned = (int)Math.Round(targetMotion.Z / motion2D.Z);
            ThrownEnderpearl enderPearlTesterForZAligned = enderPearl.DeepCopy();
            tnt.AccelerateEntity(enderPearlTesterForZAligned , tntCount: tntCountForZAligned);
            for (int j = 0; j < i; j++)
                enderPearlTesterForZAligned.Tick();
            Vector2D errorForZAligned = (Vector2D)enderPearlTesterForZAligned.Position - destination;
            if (Math.Abs(errorForXAligned.GetDominantEntry()) <= maxErrorPerAxis && tntCountForZAligned <= maxTnt)
                results.Add(
                        new SingleTntReturnFtlTntConfigResult { TravellingTicks = i , Tnt = tnt , TntCount = tntCountForZAligned , Error = errorForZAligned }
                    );

            int tntCountForClosestLanding = (int)Math.Round(targetMotion.Length * targetMotion.Length / targetMotion.ComputeDotProductWith(motion2D));
            ThrownEnderpearl enderPearlTesterForClosestLanding = enderPearl.DeepCopy();
            tnt.AccelerateEntity(enderPearlTesterForClosestLanding , tntCount: tntCountForClosestLanding);
            for (int j = 0; j < i; j++)
                enderPearlTesterForClosestLanding.Tick();
            Vector2D errorForClosestLanding = (Vector2D)enderPearlTesterForClosestLanding.Position - destination;
            if (Math.Abs(errorForClosestLanding.GetDominantEntry()) <= maxErrorPerAxis && tntCountForClosestLanding <= maxTnt)
                results.Add(
                        new SingleTntReturnFtlTntConfigResult { TravellingTicks = i , Tnt = tnt , TntCount = tntCountForClosestLanding , Error = errorForClosestLanding }
                    );
        }
        return results.Distinct().ToList();
    }
}
