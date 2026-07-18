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

    /// <param name="maxTnt">
    ///     Maximum number of TNT entities to consider.
    ///     <para> <b>REMARKS:</b> Setting to zero does not disable this feature. </para>
    /// </param>
    /// <param name="maxErrorPerAxis">
    ///     Creates an allowed landing region by creating a square with side length equal to (2 * <paramref name="maxErrorPerAxis"/>) centered at <paramref name="destination"/>.
    ///     <para> <b>REMARKS:</b> Setting to zero does not disable this feature. </para>
    /// </param>
    /// <param name="maxTravellingTickCount">
    ///     Maximum simulation ticks. Should be less than or equal to the approximate distance from source to destination. Larger values add unnecessary performance overhead.
    /// </param>
    /// <param name="maxAngleErrorOnAccelerateDirection">
    ///     Maximum allowed angle (in degrees) between the ideal travel direction and the actual TNT acceleration direction.
    ///     <para>
    ///         <b>REMARKS:</b><list type="number">
    ///             <item> Setting to zero does not disable this feature. </item>
    ///             <item> Values larger than 90 will be treated as 90. </item>
    ///         </list>
    ///     </para>
    /// </param>
    /// <returns>
    ///     A set of distinct TNT configurations, or <see langword="null"/> if no valid solution is found. Ideally, for each tick, up to 3 results are generated.
    ///     Each of them are:
    ///     <list type="number">
    ///         <item> Best match for X coordinate (minimal X error). </item>
    ///         <item> Best match for Z coordinate (minimal Z error). </item>
    ///         <item> Overall smallest Euclidean distance error to destination. </item>
    ///     </list>
    ///     <b>REMARKS:</b> Return null if angle between travel direction and acceleration direction is larger than <paramref name="maxAngleErrorOnAccelerateDirection"/>,
    ///     or return empty list if no configuration found.
    /// </returns>
    public static List<SingleTntReturnFtlTntConfigResult>? CalculateTntAmountWithFixTntLocation(
        ThrownEnderpearl enderPearl , PrimedTnt tnt , Vector2D destination ,
        int maxTnt = int.MaxValue, double maxErrorPerAxis = 256D , int maxTravellingTickCount = 128 , double maxAngleErrorOnAccelerateDirection = 30D)
    {
        Vector2D motion2D = (Vector2D)EnderMechanicsUtils.CalculateMotionOfEnderPearlAcceleratedTnt(tnt , enderPearl.Position);
        Vector2D distance = destination - (Vector2D)enderPearl.Position;

        /* return null if the angle between motion and destination direction is larger than 30 degrees */
        maxAngleErrorOnAccelerateDirection = Math.Clamp(maxAngleErrorOnAccelerateDirection , 0 , 90);
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
            if (Math.Abs(errorForZAligned.GetDominantEntry()) <= maxErrorPerAxis && tntCountForZAligned <= maxTnt)
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
        return results.Where(result => result.TntCount > 0).Distinct().ToList();
    }
}
