using System.Diagnostics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.Misc;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class StandardVectorFtl
{
    /// <param name="args">
    ///     Required field:
    ///     <list type="bullet">
    ///         <item><paramref name="args.EnderPearl"/>;</item>
    ///         <item><paramref name="args.NorthWestTnt"/>;</item>
    ///         <item><paramref name="args.NorthEastTnt"/>;</item>
    ///         <item><paramref name="args.SouthWestTnt"/>;</item>
    ///         <item><paramref name="args.SouthEastTnt"/>;</item>
    ///         <item><paramref name="args.NorthWestTntCount"/>;</item>
    ///         <item><paramref name="args.NorthEastTntCount"/>;</item>
    ///         <item><paramref name="args.SouthWestTntCount"/>;</item>
    ///         <item><paramref name="args.SouthEastTntCount"/>;</item>
    ///     </list>
    /// </param>
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

    /// <param name="args">
    ///     Required field:
    ///     <list type="bullet">
    ///         <item><paramref name="args.EnderPearl"/>;</item>
    ///         <item><paramref name="args.Destination"/>;</item>
    ///         <item><paramref name="args.NorthWestTnt"/>;</item>
    ///         <item><paramref name="args.NorthEastTnt"/>;</item>
    ///         <item><paramref name="args.SouthWestTnt"/>;</item>
    ///         <item><paramref name="args.SouthEastTnt"/>;</item>
    ///         <item><paramref name="args.NorthWestTntSide"/>;</item>
    ///         <item><paramref name="args.NorthEastTntSide"/>;</item>
    ///         <item><paramref name="args.SouthWestTntSide"/>;</item>
    ///         <item><paramref name="args.SouthEastTntSide"/>;</item>
    ///         <item><paramref name="args.MaxTntForOneSide"/>;</item>
    ///     </list>
    /// </param>
    /// <param name="maxErrorPerAxis">
    ///     Creates an allowed landing region by creating a square with side length equal to (2 * <paramref name="maxErrorPerAxis"/>) centered at <paramref name="args.Destination"/>.
    ///     <para> <b>REMARKS:</b> Setting to zero does not disable this feature. </para>
    /// </param>
    /// <param name="maxTravellingTickCount">
    ///     The maximum number of ticks to simulate. This value should be less than or equal to the distance; using a larger value creates unnecessary performance overhead.
    /// </param>
    /// <returns>
    ///     A set of distinct TNT configurations. Ideally, for each tick, up to 4 results are generated, each positioned in a different quadrant relative to destination.
    ///     <para>
    ///         <b>REMARKS:</b>
    ///         <list type="bullet">
    ///             <item> If target direction is ordinal, the quadrant is rotated 45 degree compare to regular quadrant orientation; </item>
    ///             <item> If target direction is cardinal, only 2 result are generated for each tick; </item>
    ///         </list>
    ///     </para>
    /// </returns>
    /// <remarks>
    ///     <b>REMARKS:</b>
    ///     <list type="bullet">
    ///         <item>
    ///             When no suitable pair of TNT is found to enable vectorized FTL, the method falls back to the same logic as <br/>
    ///             <see cref="SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation"/>;
    ///         </item>
    ///         <item>
    ///             Setting any constraint argument, such as MaxTntForOneSide, to 0 does not disable the corresponding feature. Instead, sets the constraint into no more than 0;
    ///         </item>
    ///     </list>
    /// </remarks>
    /// <exception cref="ArgumentException"> Thrown when TNT configuration is invalid. </exception>
    public static List<StandardVectorFtlTntConfigResult> CalculateTntConfig(StandardVectorFtlArgs args , double maxErrorPerAxis = 256D , int maxTravellingTickCount = 128)
    {
        List<StandardVectorFtlTntConfigResult> results;
        Vector2D distance = args.Destination - (Vector2D)args.EnderPearl.Position;

        ThrowIfTntPositionInFtlArgsIsInvalid(args);

        /*  Flow of this function [FLOW]:
         *  1, obtain possible TNTs and their related info;
         *  2, decide which side those possible TNTs are;
         *      - If both TNT must be on the same side, handle the edge case by solving as SingleTntReturnFtl.
         *  3, extract information for ASide TNT and BSide TNT;
         *  4, compute the result each with four targeted at different quadrant;
         *  5, remove all invalid result;
         */

        // [FLOW].1 obtain possible TNTs and their related info
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

        // [FLOW].2 decide the side of the TNTs or handle edge case for tnt1 and tnt2 both must on the same side
        if (tnt1Side == ABSide.NotAssigned || tnt2Side == ABSide.NotAssigned)
            throw new ArgumentException("Both side of TNT are not assigned, expected two to be assigned.");
        switch (tnt1Side , tnt2Side)
        {
            case (ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide):
                (tnt1Side , tnt2Side) = (ABSide.ASide , ABSide.BSide);
                break;

            case (ABSide.ASide | ABSide.BSide , _):
                tnt1Side = tnt2Side == ABSide.ASide ? ABSide.BSide : ABSide.ASide;
                break;

            case (_ , ABSide.ASide | ABSide.BSide):
                tnt2Side = tnt1Side == ABSide.ASide ? ABSide.BSide : ABSide.ASide;
                break;

            case (_ , _) when tnt1Side == tnt2Side:
            {
                results = [];
                List<SingleTntReturnFtlTntConfigResult>? resultFromTnt1 = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                        args.EnderPearl , propellingTnt1 , args.Destination , args.MaxTntForOneSide , maxTravellingTickCount: maxTravellingTickCount , maxErrorPerAxis: maxErrorPerAxis
                    );
                if (resultFromTnt1 is not null)
                {
                    results.AddRange(
                            resultFromTnt1.Select(result => new StandardVectorFtlTntConfigResult
                                    {
                                        ASideTnt = propellingTnt1 ,
                                        ASideTntLocation = tnt1Location ,
                                        ASideTntCount = result.TntCount ,
                                        BSideTnt = propellingTnt2 ,
                                        BSideTntLocation = tnt2Location ,
                                        BSideTntCount = 0 ,
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
                                        ASideTnt = propellingTnt1 ,
                                        ASideTntLocation = tnt1Location ,
                                        ASideTntCount = 0 ,
                                        BSideTnt = propellingTnt2 ,
                                        BSideTntLocation = tnt2Location ,
                                        BSideTntCount = result.TntCount ,
                                        Error = result.Error ,
                                        TravellingTicks = result.TravellingTicks ,
                                    }
                                )
                        );
                }
                return results;
            }
        }

        // [FLOW].3 extract information for ASide TNT and BSide TNT
        (PrimedTnt aSideTnt , PrimedTnt bSideTnt , CompassDirections aSideLocation , CompassDirections bSideLocation) = (tnt1Side , tnt2Side) switch
        {
            (ABSide.ASide , ABSide.BSide) => (propellingTnt1 , propellingTnt2 , tnt1Location , tnt2Location) ,
            (ABSide.BSide , ABSide.ASide) => (propellingTnt2 , propellingTnt1 , tnt2Location , tnt1Location) ,

            _ => throw new UnreachableException() ,
        };

        // [FLOW].4 compute the result each with four targeted at different quadrant
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
            theoreticalATntCount = Math.Abs(theoreticalATntCount) <= 1E-2 ? 0 : theoreticalATntCount;  // set to 0 to fix floating point arithmetic error
            theoreticalBTntCount = Math.Abs(theoreticalBTntCount) <= 1E-2 ? 0 : theoreticalBTntCount;

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

        // [FLOW].5 remove all invalid result
        return results
            .Where(result => result.ASideTntCount <= args.MaxTntForOneSide && result.BSideTntCount <= args.MaxTntForOneSide)
            .Distinct()
            .ToList();
    }

    private static void AppendTntConfigIfValid(
        ThrownEnderpearl enderPearl , Vector2D destination ,
        StandardVectorFtlTntConfigResult template ,
        int aSideTntCount , int bSideTntCount ,
        int travellingTick , double maxErrorPerAxis ,
        List<StandardVectorFtlTntConfigResult> results)
    {
        ThrownEnderpearl tester = enderPearl.DeepCopy();
        template.ASideTnt.AccelerateEntity(tester , tntCount: aSideTntCount);
        template.BSideTnt.AccelerateEntity(tester , tntCount: bSideTntCount);
        for (int i = 0; i < travellingTick; i++)
            tester.Tick();
        Vector2D error = (Vector2D)tester.Position - destination;
        if (Math.Abs(error.GetDominantEntry()) <= maxErrorPerAxis && !(aSideTntCount <= 0 && bSideTntCount <= 0))
            results.Add(template with { ASideTntCount = aSideTntCount , BSideTntCount = bSideTntCount , Error = error });
    }

    private static void ThrowIfTntPositionInFtlArgsIsInvalid(StandardVectorFtlArgs args)
    {
        Vector3D relativeNorthWestTntPos = args.NorthWestTnt.Position - args.EnderPearl.Position;
        if (relativeNorthWestTntPos.X >= 0 || relativeNorthWestTntPos.Z >= 0)
            throw new ArgumentException(
                    "North west TNT is not at the north west side of the ender pearl. Suppose to be at north west side." , nameof(args.NorthWestTnt)
                );
        Vector3D relativeNorthEastTntPos = args.NorthEastTnt.Position - args.EnderPearl.Position;
        if (relativeNorthEastTntPos.X <= 0 || relativeNorthEastTntPos.Z >= 0)
            throw new ArgumentException(
                    "North east TNT is not at the north west side of the ender pearl. Suppose to be at north east side." , nameof(args.NorthEastTnt)
                );
        Vector3D relativeSouthWestTntPos = args.SouthWestTnt.Position - args.EnderPearl.Position;
        if (relativeSouthWestTntPos.X >= 0 || relativeSouthWestTntPos.Z <= 0)
            throw new ArgumentException(
                    "South west TNT is not at the north west side of the ender pearl. Suppose to be at south west side." , nameof(args.SouthWestTnt)
                );
        Vector3D relativeSouthEastTntPos = args.SouthEastTnt.Position - args.EnderPearl.Position;
        if (relativeSouthEastTntPos.X <= 0 || relativeSouthEastTntPos.Z <= 0)
            throw new ArgumentException(
                    "South east TNT is not at the north west side of the ender pearl. Suppose to be at south east side." , nameof(args.SouthEastTnt)
                );
    }
}
