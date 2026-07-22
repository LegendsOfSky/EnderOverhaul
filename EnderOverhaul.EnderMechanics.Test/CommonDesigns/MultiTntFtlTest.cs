using System.Diagnostics;
using EnderOverhaul.EnderDynamics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.CommonDesigns;
using Xunit.Abstractions;

namespace EnderOverhaul.EnderMechanics.Test.CommonDesigns;

[Collection("MultiTntFtlTest")]
public class MultiTntFtlTest
{
    private readonly ITestOutputHelper _testOutputHelper;


    public MultiTntFtlTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        bool cannotChangeVersion = false;
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        if (cannotChangeVersion)
            throw new InvalidOperationException();
    }


    [Fact]
    public void CalculateTntAmount_ValidConfigWithOneTnt_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 16;
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
            Vector2D destination = new Vector2D(100 , 100);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination , [new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885)] , int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_ValidConfigWithTwoTnt_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 16;
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
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) , new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885)] ,
                    int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_ValidConfigWithThreeTnt_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 16;
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
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.755) ,
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.825) ,
                    ] ,
                    int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_ValidConfigWithFourTnt_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 16;
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
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                        new PrimedTnt().WithPosition(-0.335 , 170.5 , -0.885) ,
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.755) ,
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.825) ,
                    ] ,
                    int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    [Trait("Category" , "LongRunning")]
    public void CalculateTntAmount_ValidConfigWithEightTnt_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 4;
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
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) ,
                        new PrimedTnt().WithPosition(-0.335 , 170.5 , -0.885) ,
                        new PrimedTnt().WithPosition(-0.775 , 170.5 , -0.665) ,
                        new PrimedTnt().WithPosition(0 , 170.5 , -0.885) ,
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.755) ,
                        new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.825) ,
                        new PrimedTnt().WithPosition(-0.775 , 170.5 , +0.825) ,
                        new PrimedTnt().WithPosition(0 , 170.5 , +0.825) ,
                    ] ,
                    int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount , maxSearchTimeForEachTick: 5 , numberOfSearchWorkers: 1
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    [Trait("Category" , "LongRunning")]
    public void CalculateTntAmount_ValidConfigWithSixteenTnt_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 4;
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
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [
                        new PrimedTnt().WithPosition(-0.654 , 170.5 , +0.052) ,
                        new PrimedTnt().WithPosition(+0.780 , 170.5 , -0.122) ,
                        new PrimedTnt().WithPosition(-0.736 , 170.5 , +0.366) ,
                        new PrimedTnt().WithPosition(-0.922 , 170.5 , -0.728) ,

                        new PrimedTnt().WithPosition(-0.094 , 170.5 , +0.688) ,
                        new PrimedTnt().WithPosition(-0.612 , 170.5 , +0.480) ,
                        new PrimedTnt().WithPosition(-0.270 , 170.5 , -0.014) ,
                        new PrimedTnt().WithPosition(-0.090 , 170.5 , -0.092) ,

                        new PrimedTnt().WithPosition(+0.236 , 170.5 , +0.634) ,
                        new PrimedTnt().WithPosition(-0.862 , 170.5 , +0.960) ,
                        new PrimedTnt().WithPosition(+0.184 , 170.5 , +0.794) ,
                        new PrimedTnt().WithPosition(+0.736 , 170.5 , -0.102) ,

                        new PrimedTnt().WithPosition(+0.648 , 170.5 , +0.408) ,
                        new PrimedTnt().WithPosition(+0.304 , 170.5 , -0.094) ,
                        new PrimedTnt().WithPosition(-0.894 , 170.5 , -0.500) ,
                        new PrimedTnt().WithPosition(+0.516 , 170.5 , +0.104) ,
                    ] ,
                    int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount , maxSearchTimeForEachTick: 5 , numberOfSearchWorkers: 1
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_ValidInputButInfeasible_ReturnEmptyArray()
    {
        const int MaxTickCount = 16;
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
            Vector2D destination = new Vector2D(-100 , -100);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination , [new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885)] , int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount
                );
            Assert.Empty(results);
        }
    }


    [Fact]
    public void CalculateTntAmount_AllTntInSameGroup_ResultContainsOnlyOneSetOfTnt()
    {
        const int MaxTickCount = 16;
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
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [
                        new TntConfig { GroupID = 1 , MaxTntCount = 1024 , Tnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) } ,
                        new TntConfig { GroupID = 1 , MaxTntCount = 1024 , Tnt = new PrimedTnt().WithPosition(-0.335 , 170.5 , -0.885) } ,
                        new TntConfig { GroupID = 1 , MaxTntCount = 1024 , Tnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.755) } ,
                        new TntConfig { GroupID = 1 , MaxTntCount = 1024 , Tnt = new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.825) } ,
                    ] ,
                    maxTravellingTickCount: MaxTickCount
                );
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                int maxTntCount = result.TntConfig.Max(config => config.Value);
                int secondMax = result.TntConfig.Where(config => config.Value < maxTntCount).Max(config => config.Value);
                Assert.Equal(0 , secondMax);
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_DecreasingMaxTick_ResultCountDecreasing()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        IterateTestCode(16);
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        IterateTestCode(16);
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        IterateTestCode(16);
        return;

        static void IterateTestCode(int finalMaxTick)
        {
            for (int maxTick = 0; maxTick < finalMaxTick; maxTick++)
                TestCode(maxTick);
        }

        static void TestCode(int maxTickCount)
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            Vector2D destination = new Vector2D(100 , 0);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) , new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885)] ,
                    int.MaxValue ,
                    maxTravellingTickCount: maxTickCount
                );
            Assert.Equal(maxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_DecreasingMaxTntCount_ResultCountDecreasing()
    {
        const int MaxTickCount = 1;
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
            Vector2D destination = new Vector2D(100 , 0);
            int maxTnt = int.MaxValue;
            for (int i = 0; i < 8; i++)
            {
                List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                        enderPearl , destination ,
                        [new PrimedTnt().WithPosition(-0.885 , 170.5 , -0.885) , new PrimedTnt().WithPosition(-0.885 , 170.5 , +0.885)] ,
                        maxTnt - 1 ,
                        maxTravellingTickCount: MaxTickCount
                    );

                if (results is [])
                    break;

                _testOutputHelper.WriteLine($"Iteration {i}");
                foreach (MultiTntFtlTntConfigResult result in results)
                    Assert.True(result.TntConfig.Max(config => config.Value) < maxTnt);

                maxTnt = results.Max(result => result.TntConfig.Max(config => config.Value));
            }
        }
    }


    [Fact]
    public void CalculateTntAmount_LargeCoordinate_ReturnOneResultPerTick()
    {
        const int MaxTickCount = 16;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        static void TestCode()
        {
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(29999872 , 170.347226 , 29999872);
            Vector2D destination = new Vector2D(0 , 29999872);
            List<MultiTntFtlTntConfigResult> results = MultiTntFtl.CalculateTntAmount(
                    enderPearl , destination ,
                    [new PrimedTnt().WithPosition(29999872.885 , 170.5 , 29999871.115) , new PrimedTnt().WithPosition(29999872.885 , 170.5 , 29999872.885)] ,
                    int.MaxValue ,
                    maxTravellingTickCount: MaxTickCount
                );
            Assert.Equal(MaxTickCount , results.Count);
            foreach (MultiTntFtlTntConfigResult result in results)
            {
                ThrownEnderpearl testEnderPearl = enderPearl.DeepCopy();
                foreach ((PrimedTnt tnt , int count) in result.TntConfig)
                    tnt.AccelerateEntity(testEnderPearl , tntCount: count);
                for (int i = 0; i < result.TravellingTicks; i++)
                    testEnderPearl.Tick();
                Assert.Equal(result.Error , (Vector2D)testEnderPearl.Position - destination);
            }
        }
    }


    [Fact]
    [Trait("Category" , "LongRunning")]
    public void CalculateTntAmount_ChangeMaxSearchTime_DecreasingTimeCost()
    {
        const int MaxTickCount = 8;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            const int MaxVariationForElapsedDelta = 30;
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(0 , 170.347226 , 0);
            Vector2D destination = new Vector2D(100 , 0);
            List<PrimedTnt> tnts =
            [
                new PrimedTnt().WithPosition(-0.654 , 170.5 , +0.052) ,
                new PrimedTnt().WithPosition(+0.780 , 170.5 , -0.122) ,
                new PrimedTnt().WithPosition(-0.736 , 170.5 , +0.366) ,
                new PrimedTnt().WithPosition(-0.922 , 170.5 , -0.728) ,

                new PrimedTnt().WithPosition(-0.094 , 170.5 , +0.688) ,
                new PrimedTnt().WithPosition(-0.612 , 170.5 , +0.480) ,
                new PrimedTnt().WithPosition(-0.270 , 170.5 , -0.014) ,
                new PrimedTnt().WithPosition(-0.090 , 170.5 , -0.092) ,

                new PrimedTnt().WithPosition(+0.236 , 170.5 , +0.634) ,
                new PrimedTnt().WithPosition(-0.862 , 170.5 , +0.960) ,
                new PrimedTnt().WithPosition(+0.184 , 170.5 , +0.794) ,
                new PrimedTnt().WithPosition(+0.736 , 170.5 , -0.102) ,

                new PrimedTnt().WithPosition(+0.648 , 170.5 , +0.408) ,
                new PrimedTnt().WithPosition(+0.304 , 170.5 , -0.094) ,
                new PrimedTnt().WithPosition(-0.894 , 170.5 , -0.500) ,
                new PrimedTnt().WithPosition(+0.516 , 170.5 , +0.104) ,
            ];
            int previousElapsed = int.MaxValue;
            for (int maxSearchTimeForEachTick = 25; maxSearchTimeForEachTick > 0; maxSearchTimeForEachTick -= 10)
            {
                _testOutputHelper.WriteLine($"Set max search time for each tick to {maxSearchTimeForEachTick}");
                Stopwatch stopwatch = Stopwatch.StartNew();
                _ = MultiTntFtl.CalculateTntAmount(
                        enderPearl , destination , tnts , int.MaxValue ,
                        maxTravellingTickCount: MaxTickCount , maxSearchTimeForEachTick: maxSearchTimeForEachTick , numberOfSearchWorkers: 1
                    );
                stopwatch.Stop();
                int elapsed = stopwatch.Elapsed.Milliseconds;

                _testOutputHelper.WriteLine($"Previous elapsed time = {previousElapsed}, new elapsed time = {elapsed}");
                Assert.True(elapsed - previousElapsed <= MaxVariationForElapsedDelta);
                previousElapsed = elapsed;
            }
        }
    }
}
