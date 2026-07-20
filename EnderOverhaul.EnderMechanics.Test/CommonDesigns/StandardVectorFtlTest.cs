using EnderOverhaul.EnderDynamics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.CommonDesigns;
using EnderOverhaul.EnderMechanics.Misc;
using Xunit.Abstractions;


namespace EnderOverhaul.EnderMechanics.Test.CommonDesigns;

[Collection("StandardVectorFtlTest")]
public class StandardVectorFtlTest
{
    private readonly ITestOutputHelper _testOutputHelper;


    public StandardVectorFtlTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        bool cannotChangeVersion = false;
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        if (cannotChangeVersion)
            throw new InvalidOperationException();
    }


    [Theory]
    [InlineData(100 , 0)]
    [InlineData(96.592583 , 25.881905)]
    [InlineData(86.602540 , 50)]
    [InlineData(70.710678 , 70.710678)]
    [InlineData(50 , 86.602540)]
    [InlineData(25.881905 , 96.592583)]
    [InlineData(0 , 100)]
    [InlineData(-25.881905 , 96.592583)]
    [InlineData(-50 , 86.602540)]
    [InlineData(-70.710678 , 70.710678)]
    [InlineData(-86.602540 , 50)]
    [InlineData(-96.592583 , 25.881905)]
    [InlineData(-100 , 0)]
    [InlineData(-96.592583 , -25.881905)]
    [InlineData(-86.602540 , -50)]
    [InlineData(-70.710678 , -70.710678)]
    [InlineData(-50 , -86.602540)]
    [InlineData(-25.881905 , -96.592583)]
    [InlineData(0 , -100)]
    [InlineData(25.881905 , -96.592583)]
    [InlineData(50 , -86.602540)]
    [InlineData(70.710678 , -70.710678)]
    [InlineData(86.602540 , -50)]
    [InlineData(96.592583 , -25.881905)]
    public void CalculateTntConfig_TypicalConfig_ReturnNonEmptyList(double destinationX , double destinationZ)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        IterateDifferentSideConfigForTestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        IterateDifferentSideConfigForTestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        IterateDifferentSideConfigForTestCode();
        return;

        void IterateDifferentSideConfigForTestCode()
        {
            TestCodeForEachSideConfig(ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide);
            TestCodeForEachSideConfig(ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide | ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.ASide , ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide);
            TestCodeForEachSideConfig(ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.BSide , ABSide.ASide | ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.BSide);
            TestCodeForEachSideConfig(ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide);
        }

        void TestCodeForEachSideConfig(ABSide northWestSide , ABSide northEastSide , ABSide southWestSide , ABSide southEastSide)
        {
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0) ,
                Destination = new Vector2D(destinationX , destinationZ) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = northWestSide ,
                NorthEastTntSide = northEastSide ,
                SouthWestTntSide = southWestSide ,
                SouthEastTntSide = southEastSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(args);
            Assert.True(results.Count > 0);
        }
    }


    [Theory]
    [InlineData(100 , 0)]
    [InlineData(96.592583 , 25.881905)]
    [InlineData(86.602540 , 50)]
    [InlineData(50 , 86.602540)]
    [InlineData(25.881905 , 96.592583)]
    [InlineData(0 , 100)]
    [InlineData(-25.881905 , 96.592583)]
    [InlineData(-50 , 86.602540)]
    [InlineData(-86.602540 , 50)]
    [InlineData(-96.592583 , 25.881905)]
    [InlineData(-100 , 0)]
    [InlineData(-96.592583 , -25.881905)]
    [InlineData(-86.602540 , -50)]
    [InlineData(-50 , -86.602540)]
    [InlineData(-25.881905 , -96.592583)]
    [InlineData(0 , -100)]
    [InlineData(25.881905 , -96.592583)]
    [InlineData(50 , -86.602540)]
    [InlineData(86.602540 , -50)]
    [InlineData(96.592583 , -25.881905)]
    public void CalculateTntConfig_NonOrdinalDirection_Return4ResultForEachTick(double destinationX , double destinationZ)
    {
        const int MaxTick = 4;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"destination = ({destinationX}, {destinationZ})");
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0) ,
                Destination = new Vector2D(destinationX , destinationZ) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(args , maxTravellingTickCount: MaxTick);
            Assert.Equal(4 * MaxTick , results.Count);
        }
    }


    [Theory]
    [InlineData(70.710678 , 70.710678)]
    [InlineData(-70.710678 , 70.710678)]
    [InlineData(-70.710678 , -70.710678)]
    [InlineData(70.710678 , -70.710678)]
    public void CalculateTntConfig_OrdinalDirection_Return2ResultForEachTick(double destinationX , double destinationZ)
    {
        const int MaxTick = 4;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"destination = ({destinationX}, {destinationZ})");
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0) ,
                Destination = new Vector2D(destinationX , destinationZ) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(args , maxTravellingTickCount: MaxTick);
            Assert.Equal(2 * MaxTick , results.Count);
        }
    }


    [Theory]
    [InlineData(100 , 0)]
    [InlineData(96.592583 , 25.881905)]
    [InlineData(86.602540 , 50)]
    [InlineData(70.710678 , 70.710678)]
    [InlineData(50 , 86.602540)]
    [InlineData(25.881905 , 96.592583)]
    [InlineData(0 , 100)]
    [InlineData(-25.881905 , 96.592583)]
    [InlineData(-50 , 86.602540)]
    [InlineData(-70.710678 , 70.710678)]
    [InlineData(-86.602540 , 50)]
    [InlineData(-96.592583 , 25.881905)]
    [InlineData(-100 , 0)]
    [InlineData(-96.592583 , -25.881905)]
    [InlineData(-86.602540 , -50)]
    [InlineData(-70.710678 , -70.710678)]
    [InlineData(-50 , -86.602540)]
    [InlineData(-25.881905 , -96.592583)]
    [InlineData(0 , -100)]
    [InlineData(25.881905 , -96.592583)]
    [InlineData(50 , -86.602540)]
    [InlineData(70.710678 , -70.710678)]
    [InlineData(86.602540 , -50)]
    [InlineData(96.592583 , -25.881905)]
    public void CalculateTntConfig_TNTOnSameSide_ReturnValidResult(double destinationX , double destinationZ)
    {
        const int MaxTick = 4;
        const double MaxErrorPerAxis = 256D;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode(ABSide.ASide);
        TestCode(ABSide.BSide);
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode(ABSide.ASide);
        TestCode(ABSide.BSide);
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode(ABSide.ASide);
        TestCode(ABSide.BSide);
        return;

        void TestCode(ABSide tntSide)
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = new Vector2D(destinationX , destinationZ) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = tntSide ,
                NorthEastTntSide = tntSide ,
                SouthWestTntSide = tntSide ,
                SouthEastTntSide = tntSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(
                    args , maxTravellingTickCount: MaxTick , maxErrorPerAxis: MaxErrorPerAxis
                );
            foreach (StandardVectorFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                result.ASideTnt.AccelerateEntity(testEnderPearl , tntCount: result.ASideTntCount);
                result.BSideTnt.AccelerateEntity(testEnderPearl , tntCount: result.BSideTntCount);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.True(testEnderPearl.Position.X <= MaxErrorPerAxis);
                Assert.True(testEnderPearl.Position.Z <= MaxErrorPerAxis);
                Assert.True(Math.Abs(testEnderPearl.Position.X - (result.Error.X + destinationX)) <= 1E-6);
                Assert.True(Math.Abs(testEnderPearl.Position.Z - (result.Error.Z + destinationZ)) <= 1E-6);
            }
        }
    }


    [Fact]
    public void CalculateTntConfig_EnderPearlOffCenterAndTntValid_Return4ResultPerTick()
    {
        const int MaxTick = 4;
        const double MaxErrorPerAxis = 256D;
        List<(Vector3D , ABSide , ABSide , ABSide , ABSide , Vector2D)> testDataSet
            = CalculateTntConfig_EnderPearlOffCenterAndTntValid_Return4ResultPerTick_TestData();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestOverEntireTestDataSet();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestOverEntireTestDataSet();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestOverEntireTestDataSet();
        return;

        void TestOverEntireTestDataSet()
        {
            foreach ((Vector3D, ABSide, ABSide, ABSide, ABSide, Vector2D) testData in testDataSet)
            {
                (Vector3D enderPearlPos , ABSide northWestSide , ABSide northEastSide , ABSide southWestSide , ABSide southEastSide , Vector2D destination)
                    = testData;
                TestCode(enderPearlPos , northWestSide , northEastSide , southWestSide , southEastSide , destination);
            }
        }

        static void TestCode(
            Vector3D enderPearlPos ,
            ABSide northWestSide , ABSide northEastSide , ABSide southWestSide , ABSide southEastSide ,
            Vector2D destination)
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(enderPearlPos);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = destination ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = northWestSide ,
                NorthEastTntSide = northEastSide ,
                SouthWestTntSide = southWestSide ,
                SouthEastTntSide = southEastSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(
                    args , maxTravellingTickCount: MaxTick , maxErrorPerAxis: MaxErrorPerAxis
                );
            Assert.NotEmpty(results);
        }
    }
    public static List<(Vector3D , ABSide , ABSide , ABSide , ABSide , Vector2D)>
        CalculateTntConfig_EnderPearlOffCenterAndTntValid_Return4ResultPerTick_TestData()
    {
        List<(Vector3D , ABSide , ABSide , ABSide , ABSide , Vector2D)> testData = [];
        foreach (Vector2D destination in EnumerateDestination(100))
            foreach (Vector3D enderPearlPos in EnumerateEnderPearlPos(-0.88 , 0.88 , 170.347226 , -0.88 , 0.88 , 16 , 16))
                foreach ((ABSide northWestSide , ABSide northEastSide , ABSide southWestSide , ABSide southEastSide) in EnumerateTntSides())
                    testData.Add((enderPearlPos , northWestSide , northEastSide , southWestSide , southEastSide , destination));
        return testData;

        static IEnumerable<(ABSide , ABSide , ABSide , ABSide)> EnumerateTntSides()
        {
            yield return (ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.BSide);
            yield return (ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide);
            yield return (ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide | ABSide.BSide);
            yield return (ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide);
            yield return (ABSide.ASide , ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide);
            yield return (ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide);
            yield return (ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.BSide);
            yield return (ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide);
            yield return (ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.BSide , ABSide.ASide | ABSide.BSide);
            yield return (ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide , ABSide.ASide | ABSide.BSide);
            yield return (ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.ASide , ABSide.BSide);
            yield return (ABSide.ASide | ABSide.BSide , ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.ASide);
        }

        static IEnumerable<Vector3D> EnumerateEnderPearlPos(double startX , double endX , double y , double startZ , double endZ , double countX , double countZ)
        {
            double xInterval = (endX - startX) / countX;
            double zInterval = (endZ - startZ) / countZ;
            for (double x = startX + xInterval / 2; x < endX; x += xInterval)
                for (double z = startZ + zInterval / 2; z < endX; z += zInterval)
                    yield return new Vector3D(x , y , z);
        }

        static IEnumerable<Vector2D> EnumerateDestination(double radius)
        {
            const double AngleToRadiantRatio = Math.PI / 180;
            for (int angle = 0; angle < 360; angle += 15)
                yield return new Vector2D(Math.Sin(angle * AngleToRadiantRatio) , Math.Cos(angle * AngleToRadiantRatio)) * radius;
        }
    }


    [Theory , MemberData(nameof(CalculateTntConfig_NonSquareTntLocationAndTntValid_Return4ResultPerTick_TestData))]
    public void CalculateTntConfig_NonSquareTntLocationAndTntValid_Return4ResultPerTick(
        Vector3D enderPearlPos ,
        Vector3D northWestTntPos , Vector3D northEastTntPos , Vector3D southWestTntPos , Vector3D southEastTntPos ,
        Vector2D destination)
    {
        const int MaxTick = 4;
        const double MaxErrorPerAxis = 256D;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(enderPearlPos);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = destination ,
                NorthWestTnt = new PrimedTnt().WithPosition(northWestTntPos) ,
                NorthEastTnt = new PrimedTnt().WithPosition(northEastTntPos) ,
                SouthWestTnt = new PrimedTnt().WithPosition(southWestTntPos) ,
                SouthEastTnt = new PrimedTnt().WithPosition(southEastTntPos) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(
                    args , maxTravellingTickCount: MaxTick , maxErrorPerAxis: MaxErrorPerAxis
                );
            Assert.NotEmpty(results);
        }
    }
    public static TheoryData<Vector3D , Vector3D , Vector3D , Vector3D , Vector3D , Vector2D>
        CalculateTntConfig_NonSquareTntLocationAndTntValid_Return4ResultPerTick_TestData()
    {
        return new TheoryData<Vector3D , Vector3D , Vector3D , Vector3D , Vector3D , Vector2D>
        {
            {  // non-typical location for northwest TNT
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.9) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.9 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.9 , 170.5 , -0.9) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {  // non-typical location for northeast TNT
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.9 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(0 , 100)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.9) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(0 , 100)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.9 , 170.5 , -0.9) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(0 , 100)
            } ,
            {  // non-typical location for southwest TNT
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.9 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.9) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.9 , 170.5 , +0.9) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {  // non-typical location for southeast TNT
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.9 , 170.5 , +0.885) ,
                new Vector2D(0 , 100)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.9) ,
                new Vector2D(0 , 100)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.9 , 170.5 , +0.9) ,
                new Vector2D(0 , 100)
            } ,
        };
    }


    [Theory , MemberData(nameof(CalculateTntConfig_InvalidTntLocation_ThrowArgumentException_TestData))]
    public void CalculateTntConfig_InvalidTntLocation_ThrowArgumentException(
        Vector3D enderPearlPos ,
        Vector3D northWestTntPos , Vector3D northEastTntPos , Vector3D southWestTntPos , Vector3D southEastTntPos ,
        Vector2D destination)
    {
        const int MaxTick = 4;
        const double MaxErrorPerAxis = 256D;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(enderPearlPos);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = destination ,
                NorthWestTnt = new PrimedTnt().WithPosition(northWestTntPos) ,
                NorthEastTnt = new PrimedTnt().WithPosition(northEastTntPos) ,
                SouthWestTnt = new PrimedTnt().WithPosition(southWestTntPos) ,
                SouthEastTnt = new PrimedTnt().WithPosition(southEastTntPos) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            Assert.Throws<ArgumentException>(() => StandardVectorFtl.CalculateTntConfig(
                        args , maxTravellingTickCount: MaxTick , maxErrorPerAxis: MaxErrorPerAxis
                    )
                );
        }
    }
    public static TheoryData<Vector3D , Vector3D , Vector3D , Vector3D , Vector3D , Vector2D>
        CalculateTntConfig_InvalidTntLocation_ThrowArgumentException_TestData()
    {
        return new TheoryData<Vector3D , Vector3D , Vector3D , Vector3D , Vector3D , Vector2D>
        {
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(+0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(-0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(+0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(-0.885 , 170.5 , +0.885) ,
                new Vector2D(100 , 0)
            } ,
            {
                new Vector3D(0 , 170.347226 , 0) ,
                new Vector3D(-0.885 , 170.5 , -0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector3D(-0.885 , 170.5 , +0.885) , new Vector3D(+0.885 , 170.5 , -0.885) ,
                new Vector2D(100 , 0)
            } ,
        };
    }


    [Theory]
    [InlineData(ABSide.NotAssigned , ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.BSide , 0 , +100)]
    [InlineData(ABSide.ASide , ABSide.NotAssigned , ABSide.ASide | ABSide.BSide , ABSide.BSide , 0 , +100)]
    [InlineData(ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.NotAssigned , ABSide.BSide , 0 , -100)]
    [InlineData(ABSide.ASide , ABSide.ASide | ABSide.BSide , ABSide.BSide , ABSide.NotAssigned , 0 , -100)]
    public void CalculateTntConfig_InvalidTntSide_ThrowArgumentException(
        ABSide northWestSide , ABSide northEastSide , ABSide southWestSide , ABSide southEastSide , double destinationX , double destinationZ)
    {
        const int MaxTick = 4;
        const double MaxErrorPerAxis = 256D;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = new Vector2D(destinationX , destinationZ) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = northWestSide ,
                NorthEastTntSide = northEastSide ,
                SouthWestTntSide = southWestSide ,
                SouthEastTntSide = southEastSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            Assert.Throws<ArgumentException>(() => StandardVectorFtl.CalculateTntConfig(
                        args , maxTravellingTickCount: MaxTick , maxErrorPerAxis: MaxErrorPerAxis
                    )
                );
        }
    }


    [Fact]
    public void CalculateTntConfig_DecreasingMaxTnt_DecreasingResultCount()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        static void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = new Vector2D(1024 , 1024) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(
                    args , maxTravellingTickCount: 16 , maxErrorPerAxis: double.MaxValue
                );
            while (results.Count > 0)
            {
                int oldResultsCount = results.Count;
                int maxTnt = results.Max(result => Math.Max(result.ASideTntCount , result.BSideTntCount));
                int maxTntResultCount = results.Count(result => Math.Max(result.ASideTntCount , result.BSideTntCount) == maxTnt);
                results = StandardVectorFtl.CalculateTntConfig(
                        args with { MaxTntForOneSide = maxTnt - 1 } , maxTravellingTickCount: 16 , maxErrorPerAxis: double.MaxValue
                    );
                int newResultsCount = results.Count;
                Assert.Equal(maxTntResultCount , oldResultsCount - newResultsCount);
            }
        }
    }


    [Fact]
    public void CalculateTntConfig_DecreasingMaxError_DecreasingResultCount()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        static void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = new Vector2D(1024 , 1024) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(
                    args , maxTravellingTickCount: 16 , maxErrorPerAxis: double.MaxValue
                );
            while (results.Count > 0)
            {
                int oldResultsCount = results.Count;
                double maxError = results.Max(result => Math.Abs(double.MaxMagnitudeNumber(result.Error.X , result.Error.Z)));
                List<StandardVectorFtlTntConfigResult> nonMaxErrorResults = results.Where(
                        result => Math.Abs(double.MaxMagnitudeNumber(result.Error.X , result.Error.Z)) - maxError >= 1E-9
                    ).ToList();
                if (nonMaxErrorResults.Count == 0)
                    break;
                double nextMaxError = nonMaxErrorResults.Max(result => Math.Abs(double.MaxMagnitudeNumber(result.Error.X , result.Error.Z)));
                results = StandardVectorFtl.CalculateTntConfig(
                        args , maxTravellingTickCount: 16 , maxErrorPerAxis: (maxError + nextMaxError) / 2
                    );
                int newResultsCount = results.Count;
                Assert.True(oldResultsCount > newResultsCount);
            }
        }
    }


    [Fact]
    public void CalculateTntConfig_DecreasingMaxTick_DecreasingResultCount()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        static void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            StandardVectorFtlArgs args = new StandardVectorFtlArgs
            {
                EnderPearl = enderPearl ,
                Destination = new Vector2D(1024 , 1024) ,
                NorthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                NorthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , -0.885) ,
                SouthWestTnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885) ,
                SouthEastTnt = new PrimedTnt().WithPosition(+0.885 , 170.5 , +0.885) ,
                NorthWestTntSide = ABSide.ASide ,
                NorthEastTntSide = ABSide.ASide | ABSide.BSide ,
                SouthWestTntSide = ABSide.ASide | ABSide.BSide ,
                SouthEastTntSide = ABSide.BSide ,
                MaxTntForOneSide = int.MaxValue ,
            };
            List<StandardVectorFtlTntConfigResult> results = StandardVectorFtl.CalculateTntConfig(
                    args , maxTravellingTickCount: 16 , maxErrorPerAxis: double.MaxValue
                );
            for (int i = 16; i > 0; i--)
            {
                int oldResultsCount = results.Count;
                int maxTickResultCount = results.Count(result => result.TravellingTicks == i);
                results = StandardVectorFtl.CalculateTntConfig(
                        args , maxTravellingTickCount: i - 1 , maxErrorPerAxis: double.MaxValue
                    );
                int newResultsCount = results.Count;
                Assert.Equal(maxTickResultCount , oldResultsCount - newResultsCount);
            }
        }
    }
}
