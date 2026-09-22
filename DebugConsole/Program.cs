using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics;
using EnderOverhaul.EnderMechanics.CommonDesigns;
using EnderOverhaul.EnderMechanics.Misc;


namespace DebugConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        EnderMechanicsConfig.TrySetMinecraftVersion("1.12.2");

        List<StandardVectorFtlTntConfigResult> result = StandardVectorFtl.CalculateTntConfig(new StandardVectorFtlArgs
        {
            Destination = new Vector2D(100 , 0) ,
            EnderPearl = new ThrownEnderpearl() ,
            MaxTntForOneSide = int.MaxValue ,
            NorthWestTnt = new PrimedTnt().WithPosition(-1 , 0 , -1) , NorthWestTntSide = ABSide.ASide ,
            NorthEastTnt = new PrimedTnt().WithPosition(+1 , 0 , -1) , NorthEastTntSide = ABSide.NotAssigned ,
            SouthWestTnt = new PrimedTnt().WithPosition(-1 , 0 , +1) , SouthWestTntSide = ABSide.BSide ,
            SouthEastTnt = new PrimedTnt().WithPosition(+1 , 0 , +1) , SouthEastTntSide = ABSide.NotAssigned ,
        });

        //var tmp = MultiTntFtl.CalculateOptimalAmountForSpecificMotion(
        //        new Vector3D() , new Vector2D(100 , 0) , [
        //            new TntConfig { GroupID = 0 , MaxTntCount = 1024 , Tnt = new PrimedTnt().WithPosition(-1 , 0 , -1) } ,
        //            new TntConfig { GroupID = 1 , MaxTntCount = 1024 , Tnt = new PrimedTnt().WithPosition(-1 , 0 , +1) } ,
        //        ]
        //    );

        var tmp = MultiTntFtl.CalculateTntAmount(
                new ThrownEnderpearl() , new Vector2D(100 , 0) ,
                [new PrimedTnt().WithPosition(-1 , 0 , -1) , new PrimedTnt().WithPosition(-1 , 0 , +1)] ,
                1024
            );

        int i = 0;
    }
}