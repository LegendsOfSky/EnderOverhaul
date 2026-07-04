using System.Diagnostics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.Misc;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class StandardVectorFtl
{
    /// <remarks>
    ///     <b>REMARKS:</b> The method will not terminate when the Y coordinate of the ender pearl is below any value. It only terminates when the parameter
    ///         <see cref="travellingTickCount"/> is reached.
    /// </remarks>
    public static List<ThrownEnderpearl> CalculateEnderPearlTrace(StandardVectorFtlArgs args , int travellingTickCount = 128)
    {
        ThrownEnderpearl enderPearl = args.EnderPearl.DeepCopy();
        args.NorthWestTnt.AccelerateEntity(enderPearl , tntCount: args.NorthWestTntCount);
        args.NorthEastTnt.AccelerateEntity(enderPearl , tntCount: args.NorthEastTntCount);
        args.SouthWestTnt.AccelerateEntity(enderPearl , tntCount: args.SouthWestTntCount);
        args.SouthEastTnt.AccelerateEntity(enderPearl , tntCount: args.SouthEastTntCount);
        List<ThrownEnderpearl> results = new List<ThrownEnderpearl>(travellingTickCount + 1) { enderPearl.DeepCopy() };
        for (int i = 0; i < travellingTickCount; i++)
        {
            enderPearl.Tick();
            results.Add(enderPearl.DeepCopy());
        }
        return results;
    }

    /// <remarks>
    ///     <b>REMARKS:</b> When no suitable pair of TNT is found to enable vectorized FTL, the method falls back to the same logic as 
    ///         <see cref="SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation"/>.
    /// </remarks>
    /// <param name="maxTravellingTickCount">
    ///     The maximum number of ticks to simulate. This value should be less than or equal to the distance; using a larger value creates unnecessary performance overhead.
    /// </param>
    /// <returns>
    ///     Returns a set of distinct TNT configurations. Ideally, for each tick, up to 4 results are generated, each positioned in a different quadrant relative to the
    ///         landing spot.
    /// </returns>
    public static List<StandardVectorFtlTntConfigResult> CalculateTntConfig(StandardVectorFtlArgs args , int maxErrorPerAxis = 256 , int maxTravellingTickCount = 128)
    {
        List<StandardVectorFtlTntConfigResult> results;
        Vector2D distance = args.Destination - (Vector2D)args.EnderPearl.Position;

        /* compute which Tnt to use */
        (PrimedTnt propellingTnt1 , PrimedTnt propellingTnt2 , ABSide tnt1Side , ABSide tnt2Side , CompassDirections tnt1Location , CompassDirections tnt2Location)
            = distance.ToCardinalCompassDirection() switch
            {
                CompassDirections.North => (
                        args.SouthWestTnt , args.SouthEastTnt ,
                        args.SouthWestTntSide , args.SouthEastTntSide ,
                        CompassDirections.SouthWest , CompassDirections.SouthEast
                    ) ,
                CompassDirections.South => (
                        args.NorthWestTnt , args.NorthEastTnt ,
                        args.NorthWestTntSide , args.NorthEastTntSide ,
                        CompassDirections.NorthWest , CompassDirections.NorthEast
                    ) ,
                CompassDirections.East => (
                        args.NorthWestTnt , args.SouthWestTnt ,
                        args.NorthWestTntSide , args.SouthWestTntSide ,
                        CompassDirections.NorthWest , CompassDirections.SouthWest
                    ) ,
                CompassDirections.West => (
                        args.NorthEastTnt , args.SouthEastTnt ,
                        args.NorthEastTntSide , args.SouthEastTntSide ,
                        CompassDirections.NorthEast , CompassDirections.SouthEast
                    ) ,

                _ => throw new UnreachableException() ,
            };
        if (tnt1Side == tnt2Side)
        {
            if (tnt1Side == ABSide.NotAssigned)
                throw new ArgumentException();

            results = [];
            List<SingleTntReturnFtlTntConfigResult>? resultFromTnt1 = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    args.EnderPearl , propellingTnt1 , args.Destination , args.MaxTntForOneSide , maxTravellingTickCount: maxTravellingTickCount , maxErrorPerAxis: maxErrorPerAxis
                );
            if (resultFromTnt1 is not null)
            {
                results.AddRange(
                        resultFromTnt1.Select(result => new StandardVectorFtlTntConfigResult
                                {
                                    ASideTnt = propellingTnt1 , ASideTntLocation = tnt1Location , ASideTntCount = result.TntCount ,
                                    BSideTnt = propellingTnt2 , BSideTntLocation = tnt2Location , BSideTntCount = 0 ,
                                    Error = result.Error ,
                                    TravellingTicks = result.TravellingTicks ,
                                }
                            )
                    );
            }
            List<SingleTntReturnFtlTntConfigResult>? resultFromTnt2 = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    args.EnderPearl , propellingTnt2 , args.Destination , args.MaxTntForOneSide , maxTravellingTickCount: maxTravellingTickCount , maxErrorPerAxis: maxErrorPerAxis
                );
            if (resultFromTnt2 is not null)
            {
                results.AddRange(
                        resultFromTnt2.Select(result => new StandardVectorFtlTntConfigResult
                                {
                                    ASideTnt = propellingTnt1 , ASideTntLocation = tnt1Location , ASideTntCount = result.TntCount ,
                                    BSideTnt = propellingTnt2 , BSideTntLocation = tnt2Location , BSideTntCount = 0 ,
                                    Error = result.Error ,
                                    TravellingTicks = result.TravellingTicks ,
                                }
                            )
                    );
            }
            return results;
        }
        (PrimedTnt aSideTnt , PrimedTnt bSideTnt , CompassDirections aSideLocation , CompassDirections bSideLocation) = (tnt1Side , tnt2Side) switch
        {
            (ABSide.ASide , ABSide.BSide) => (propellingTnt1 , propellingTnt2 , tnt1Location , tnt2Location) ,
            (ABSide.BSide , ABSide.ASide) => (propellingTnt2 , propellingTnt1 , tnt2Location , tnt1Location) ,

            _ => throw new ArgumentException() ,
        };

        results = new List<StandardVectorFtlTntConfigResult>(maxTravellingTickCount * 4);
        Vector3D motionA = EnderMechanicsUtils.CalculateMotionOfEnderPearlAcceleratedTnt(aSideTnt , args.EnderPearl.Position);
        Vector3D motionB = EnderMechanicsUtils.CalculateMotionOfEnderPearlAcceleratedTnt(bSideTnt , args.EnderPearl.Position);
        ThrownEnderpearl motionDivisorSampler = new ThrownEnderpearl(new Vector3D() , new Vector3D(1D , 0D , 1D));
        for (int i = 1; i <= maxTravellingTickCount; i++)
        {
            motionDivisorSampler.Tick();
            double motionDivisor = motionDivisorSampler.Position.X;
            Vector2D targetMotion = distance * (1 / motionDivisor) - (Vector2D)args.EnderPearl.Motion;
            double theoreticalATntCount = (targetMotion.Z * motionB.X - targetMotion.X * motionB.Z) / (motionB.X * motionA.Z - motionA.X * motionB.Z);
            double theoreticalBTntCount = (targetMotion.X - theoreticalATntCount * motionA.X) / motionB.X;

            int aCeiling = (int)Math.Ceiling(theoreticalATntCount) , bCeiling = (int)Math.Ceiling(theoreticalBTntCount);
            int aFloor = (int)Math.Floor(theoreticalATntCount) , bFloor = (int)Math.Floor(theoreticalBTntCount);
            StandardVectorFtlTntConfigResult template = new StandardVectorFtlTntConfigResult()
            {
                ASideTnt = aSideTnt ,
                BSideTnt = bSideTnt ,
                ASideTntLocation = aSideLocation ,
                BSideTntLocation =  bSideLocation ,
                ASideTntCount = 0 ,
                BSideTntCount = 0 ,
                TravellingTicks = i ,
            };
            AppendTntConfigIfValid(args.EnderPearl , args.Destination , template , aCeiling , bCeiling , i , maxErrorPerAxis , results);
            AppendTntConfigIfValid(args.EnderPearl , args.Destination , template , aCeiling , bFloor   , i , maxErrorPerAxis , results);
            AppendTntConfigIfValid(args.EnderPearl , args.Destination , template , aFloor   , bCeiling , i , maxErrorPerAxis , results);
            AppendTntConfigIfValid(args.EnderPearl , args.Destination , template , aFloor   , bFloor   , i , maxErrorPerAxis , results);
        }
        return results
            .Where(result => result.ASideTntCount <= args.MaxTntForOneSide && result.BSideTntCount <= args.MaxTntForOneSide)
            .Distinct()
            .ToList();
    }

    private static void AppendTntConfigIfValid(
        ThrownEnderpearl enderPearl , Vector2D destination ,
        StandardVectorFtlTntConfigResult template ,
        int aSideTntCount , int bSideTntCount ,
        int travellingTick , int maxErrorPerAxis ,
        List<StandardVectorFtlTntConfigResult> results)
    {
        ThrownEnderpearl tester = enderPearl.DeepCopy();
        template.ASideTnt.AccelerateEntity(tester , aSideTntCount);
        template.BSideTnt.AccelerateEntity(tester , bSideTntCount);
        for (int i = 0; i < travellingTick; i++)
            tester.Tick();
        Vector2D error = (Vector2D)tester.Position - destination;
        if (Math.Abs(error.GetDominantEntry()) <= maxErrorPerAxis)
            results.Add(template with { ASideTntCount = aSideTntCount , BSideTntCount = bSideTntCount , Error = error });
    }
}
