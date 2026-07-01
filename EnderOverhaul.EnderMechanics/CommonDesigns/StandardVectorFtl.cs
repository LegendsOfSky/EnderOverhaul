using System.Diagnostics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.Misc;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class StandardVectorFtl
{
    public static List<ThrownEnderpearl> CalculateEnderPearlTrace(StandardVectorFtlArgs args , int tickCount = 128)
    {
        ThrownEnderpearl enderPearl = args.EnderPearl.DeepCopy();
        args.NorthWestTnt.AccelerateEntity(enderPearl , tntCount: args.NorthWestTntCount);
        args.NorthEastTnt.AccelerateEntity(enderPearl , tntCount: args.NorthEastTntCount);
        args.SouthWestTnt.AccelerateEntity(enderPearl , tntCount: args.SouthWestTntCount);
        args.SouthEastTnt.AccelerateEntity(enderPearl , tntCount: args.SouthEastTntCount);
        List<ThrownEnderpearl> results = new List<ThrownEnderpearl>(tickCount + 1) { enderPearl.DeepCopy() };
        for (int i = 0; i < tickCount; i++)
        {
            enderPearl.Tick();
            results.Add(enderPearl.DeepCopy());
        }
        return results;
    }

    /// <param name="maxTickCount"> This parameter should be less than or equal to the distance. Otherwise, unnecessary performance overhead will be created. </param>
    /// <returns> Returns a set of distinct TNT config. Ideally, for each tick, 4 result will be created each at different quadrant relative to the landing spot. </returns>
    public static List<StandardVectorFtlTntConfigResult> CalculateTntConfig(StandardVectorFtlArgs args , int maxErrorPerAxis = 256 , int maxTickCount = 128)
    {
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

            throw new NotImplementedException("Pass to single TNT return cannon to calculate this.");
        }
        (PrimedTnt aSideTnt , PrimedTnt bSideTnt , CompassDirections aSideLocation , CompassDirections bSideLocation) = (tnt1Side , tnt2Side) switch
        {
            (ABSide.ASide , ABSide.BSide) => (propellingTnt1 , propellingTnt2 , tnt1Location , tnt2Location) ,
            (ABSide.BSide , ABSide.ASide) => (propellingTnt2 , propellingTnt1 , tnt2Location , tnt1Location) ,

            _ => throw new ArgumentException() ,
        };

        /* compute theoretical result for single tick traverse */
        Vector2D targetMotion = distance - (Vector2D)args.EnderPearl.Motion;
        Vector3D motionA = EnderMechanicsUtils.CalculateMotionOfEnderPearlAcceleratedTnt(aSideTnt , args.EnderPearl.Position);
        Vector3D motionB = EnderMechanicsUtils.CalculateMotionOfEnderPearlAcceleratedTnt(bSideTnt , args.EnderPearl.Position);
        double theoreticalSingleTickATntCount = (targetMotion.Z * motionB.X - targetMotion.X * motionB.Z) / (motionB.X * motionA.Z - motionA.X * motionB.Z);
        double theoreticalSingleTickBTntCount = (targetMotion.X - theoreticalSingleTickATntCount * motionA.X) / motionB.X;

        /*  Purpose of the following code:
         *  1. generate multi-tick traverse by using single tick version;
         *  2. convert theoretical result into practical result;
         */
        List<StandardVectorFtlTntConfigResult> results = new List<StandardVectorFtlTntConfigResult>(maxTickCount * 4);
        ThrownEnderpearl tntCountDivisorSampler = new ThrownEnderpearl(new Vector3D() , new Vector3D(1D , 0D , 1D));
        for (int i = 1; i <= maxTickCount; i++)
        {
            tntCountDivisorSampler.Tick();
            double tntCountDivisor = tntCountDivisorSampler.Position.X;
            double theoreticalATntCount = theoreticalSingleTickATntCount / tntCountDivisor;
            double theoreticalBTntCount = theoreticalSingleTickBTntCount / tntCountDivisor;
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
        return results.Distinct().ToList();
    }

    private static void AppendTntConfigIfValid(
        ThrownEnderpearl enderPearl , Vector2D destination ,
        StandardVectorFtlTntConfigResult template ,
        int aSideTntCount , int bSideTntCount ,
        int tick , int maxErrorPerAxis ,
        List<StandardVectorFtlTntConfigResult> results)
    {
        ThrownEnderpearl tester = enderPearl.DeepCopy();
        template.ASideTnt.AccelerateEntity(tester , aSideTntCount);
        template.BSideTnt.AccelerateEntity(tester , bSideTntCount);
        for (int i = 0; i < tick; i++)
            tester.Tick();
        Vector2D error = (Vector2D)tester.Position - destination;
        if (Math.Abs(error.GetDominantEntry()) <= maxErrorPerAxis)
            results.Add(template with { ASideTntCount = aSideTntCount , BSideTntCount = bSideTntCount , Error = error });
    }
}
