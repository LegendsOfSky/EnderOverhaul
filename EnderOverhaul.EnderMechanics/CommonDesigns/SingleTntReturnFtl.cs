using EnderOverhaul.EnderDynamics.Minecraft;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public static class SingleTntReturnFtl
{
    private static readonly double s_cosOf30Degree = Math.Cos(MathHelper.DegreeToRadiant(30D));


    public static List<ThrownEnderpearl> CalculateEnderPearlTrace(ThrownEnderpearl enderPearl , PrimedTnt tnt , int tntCount , int maxTick = 128)
    {
        ThrownEnderpearl tracer = enderPearl.DeepCopy();
        tnt.AccelerateEntity(tracer , tntCount: tntCount);
        List<ThrownEnderpearl> results = new List<ThrownEnderpearl>(maxTick + 1) { tracer.DeepCopy() };
        for (int i = 0; i < maxTick; i++)
        {
            tracer.Tick();
            results.Add(tracer.DeepCopy());
        }
        return results;
    }

    public static List<SingleTntReturnFtlTntConfigResult>? CalculateTntAmountWithFixTntLocation(
        ThrownEnderpearl enderPearl , PrimedTnt tnt , Vector2D destination , int maxTnt , int maxErrorPerAxis = 256 , int maxTick = 128)
    {
        ThrownEnderpearl motionSampler = enderPearl.DeepCopy();
        tnt.AccelerateEntity(motionSampler);
        Vector2D motion2D = (Vector2D)motionSampler.Motion;
        Vector2D distance = destination - (Vector2D)enderPearl.Position;

        /* return null if the angle between motion and destination direction is larger than 30 degrees */
        if (motion2D.ComputeDotProductWith(distance) < s_cosOf30Degree * motion2D.Length * distance.Length)
            return null;

        ThrownEnderpearl tntCountDivisorSampler = new ThrownEnderpearl().WithMotion(1 , 0 , 1);
        List<SingleTntReturnFtlTntConfigResult> results = new List<SingleTntReturnFtlTntConfigResult>(maxTick * 3);
        double theoreticalSingleTickTntCountForXAlignedLanding = distance.X / motion2D.X;
        double theoreticalSingleTickTntCountForZAlignedLanding = distance.Z / motion2D.Z;
        double theoreticalSingleTickTntCountForClosestLanding = distance.Length * distance.Length / distance.ComputeDotProductWith(motion2D);
        for (int i = 1; i <= maxTick; i++)
        {
            tntCountDivisorSampler.Tick();
            double divisor = tntCountDivisorSampler.Position.X;

            int tntCountForXAligned = (int)Math.Round(theoreticalSingleTickTntCountForXAlignedLanding / divisor);
            ThrownEnderpearl enderPearlTesterForXAligned = enderPearl.DeepCopy();
            tnt.AccelerateEntity(enderPearlTesterForXAligned , tntCount: tntCountForXAligned);
            for (int j = 0; j < i; j++)
                enderPearlTesterForXAligned.Tick();
            Vector2D errorForXAligned = (Vector2D)enderPearlTesterForXAligned.Position - destination;
            if (Math.Abs(errorForXAligned.GetDominantEntry()) <= maxErrorPerAxis))
                results.Add(
                        new SingleTntReturnFtlTntConfigResult { Tick = i , Tnt = tnt , TntCount = tntCountForXAligned , Error = errorForXAligned }
                    );

            int tntCountForZAligned = (int)Math.Round(theoreticalSingleTickTntCountForZAlignedLanding / divisor);
            ThrownEnderpearl enderPearlTesterForZAligned = enderPearl.DeepCopy();
            tnt.AccelerateEntity(enderPearlTesterForZAligned , tntCount: tntCountForZAligned);
            for (int j = 0; j < i; j++)
                enderPearlTesterForZAligned.Tick();
            Vector2D errorForZAligned = (Vector2D)enderPearlTesterForZAligned.Position - destination;
            if (Math.Abs(errorForXAligned.GetDominantEntry()) <= maxErrorPerAxis)
                results.Add(
                        new SingleTntReturnFtlTntConfigResult { Tick = i , Tnt = tnt , TntCount = tntCountForZAligned , Error = errorForZAligned }
                    );

            int tntCountForClosestLanding = (int)Math.Round(theoreticalSingleTickTntCountForClosestLanding / divisor);
            ThrownEnderpearl enderPearlTesterForClosestLanding = enderPearl.DeepCopy();
            tnt.AccelerateEntity(enderPearlTesterForClosestLanding , tntCount: tntCountForClosestLanding);
            for (int j = 0; j < i; j++)
                enderPearlTesterForClosestLanding.Tick();
            Vector2D errorForClosestLanding = (Vector2D)enderPearlTesterForClosestLanding.Position - destination;
            if (Math.Abs(errorForClosestLanding.GetDominantEntry()) <= maxErrorPerAxis)
                results.Add(
                        new SingleTntReturnFtlTntConfigResult { Tick = i , Tnt = tnt , TntCount = tntCountForClosestLanding , Error = errorForClosestLanding }
                    );
        }
        return results.Distinct().ToList();
    }
}
