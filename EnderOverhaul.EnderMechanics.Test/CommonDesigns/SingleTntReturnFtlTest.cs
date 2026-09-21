using EnderOverhaul.EnderDynamics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.CommonDesigns;
using Xunit.Abstractions;


namespace EnderOverhaul.EnderMechanics.Test.CommonDesigns;

[Collection("SingleTntReturnFtlTest")]
public class SingleTntReturnFtlTest
{
    private readonly ITestOutputHelper _testOutputHelper;


    public SingleTntReturnFtlTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        bool cannotChangeVersion = false;
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        cannotChangeVersion |= !EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        if (cannotChangeVersion)
            throw new InvalidOperationException();
    }


    #region Test Case
    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_ValidConfigNoMotionPerfectAngle_ResultCountEqualToTickCount_TestData))]
    public void CalculateTntAmountWithFixTntLocation_ValidConfigNoMotionPerfectAngle_ResultCountEqualToTickCount(
        Vector3D enderPearlPos , Vector3D tntPos , Vector2D destination , int tickCount)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"Ender pearl position: {enderPearlPos}");
            _testOutputHelper.WriteLine($"TNT position: {tntPos}");
            _testOutputHelper.WriteLine($"Destination: {destination}");
            _testOutputHelper.WriteLine($"Tick count: {tickCount}");

            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                    maxTnt: int.MaxValue , maxTravellingTickCount: tickCount
                );

            Assert.NotNull(results);
            Assert.Equal(tickCount , results.Count);

            foreach (SingleTntReturnFtlTntConfigResult result in results)
            {
                PrimedTnt tnt = new PrimedTnt().WithPosition(tntPos);
                ThrownEnderpearl enderPearl = new ThrownEnderpearl(enderPearlPos);
                tnt.AccelerateEntity(enderPearl , tntCount: result.TntCount);
                for (int i = 0; i < result.TravellingTicks; i++)
                    enderPearl.Tick();
                Assert.Equal((Vector2D)enderPearl.Position - destination , result.Error);
            }
        }
    }
    public static TheoryData<Vector3D , Vector3D , Vector2D , int> 
        CalculateTntAmountWithFixTntLocation_ValidConfigNoMotionPerfectAngle_ResultCountEqualToTickCount_TestData()
    {
        return new TheoryData<Vector3D , Vector3D , Vector2D , int>
        {
            #region 16 Tick
            #region (-, -)
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.125 , 1) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.25  , 1) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.5   , 1) , new Vector2D(-2048 , -2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.125 , 1) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.25  , 1) , new Vector2D(-512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.5   , 1) , new Vector2D(-2048 , -2048) , 16 } ,
            #endregion

            #region (-, +)
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.125 , -1) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.25  , -1) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.5   , -1) , new Vector2D(-2048 , 2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.125 , -1) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.25  , -1) , new Vector2D(-512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.5   , -1) , new Vector2D(-2048 , 2048) , 16 } ,
            #endregion

            #region (+, -)
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(128  , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(2048 , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(8192 , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.125 , 1) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.25  , 1) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.5   , 1) , new Vector2D(2048 , -2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.125 , 1) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.25  , 1) , new Vector2D(512  , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.5   , 1) , new Vector2D(2048 , -2048) , 16 } ,
            #endregion

            #region (+, +)
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(128  , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(2048 , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(8192 , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.125 , -1) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.25  , -1) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.5   , -1) , new Vector2D(2048 , 2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.125 , -1) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.25  , -1) , new Vector2D(512  , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.5   , -1) , new Vector2D(2048 , 2048) , 16 } ,
            #endregion
            #endregion

            #region 64 Tick
            #region (-, -)
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.125 , 1) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.25  , 1) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.5   , 1) , new Vector2D(-2048 , -2048) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.125 , 1) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.25  , 1) , new Vector2D(-512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.5   , 1) , new Vector2D(-2048 , -2048) , 64 } ,
            #endregion

            #region (-, +)
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.125 , -1) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.25  , -1) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.5   , -1) , new Vector2D(-2048 , 2048) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.125 , -1) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.25  , -1) , new Vector2D(-512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.5   , -1) , new Vector2D(-2048 , 2048) , 64 } ,
            #endregion

            #region (+, -)
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(128  , -128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(2048 , -2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(8192 , -8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.125 , 1) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.25  , 1) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.5   , 1) , new Vector2D(2048 , -2048) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.125 , 1) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.25  , 1) , new Vector2D(512  , -512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.5   , 1) , new Vector2D(2048 , -2048) , 64 } ,
            #endregion

            #region (+, +)
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(128  , 128 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(2048 , 2048) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(8192 , 8192) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.125 , -1) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.25  , -1) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.5   , -1) , new Vector2D(2048 , 2048) , 64 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.125 , -1) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.25  , -1) , new Vector2D(512  , 512 ) , 64 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.5   , -1) , new Vector2D(2048 , 2048) , 64 } ,
            #endregion
            #endregion
        };
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_ValidConfigNoMotion15DegreeOff_ResultCountEqualTo3TimesTickCount_TestData))]
    public void CalculateTntAmountWithFixTntLocation_ValidConfigNoMotion15DegreeOff_ResultCountEqualTo3TimesTickCount(
        Vector3D enderPearlPos , Vector3D tntPos , Vector2D destination , int tickCount)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"Ender pearl position: {enderPearlPos}");
            _testOutputHelper.WriteLine($"TNT position: {tntPos}");
            _testOutputHelper.WriteLine($"Destination: {destination}");
            _testOutputHelper.WriteLine($"Tick count: {tickCount}");

            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                    maxTnt: int.MaxValue , maxTravellingTickCount: tickCount , maxErrorPerAxis: double.MaxValue
                );

            Assert.NotNull(results);
            Assert.Equal(3 * tickCount , results.Count);

            foreach (SingleTntReturnFtlTntConfigResult result in results)
            {
                PrimedTnt tnt = new PrimedTnt().WithPosition(tntPos);
                ThrownEnderpearl enderPearl = new ThrownEnderpearl(enderPearlPos);
                tnt.AccelerateEntity(enderPearl , tntCount: result.TntCount);
                for (int i = 0; i < result.TravellingTicks; i++)
                    enderPearl.Tick();
                Assert.Equal((Vector2D)enderPearl.Position - destination , result.Error);
            }
        }
    }
    public static TheoryData<Vector3D , Vector3D , Vector2D , int>
        CalculateTntAmountWithFixTntLocation_ValidConfigNoMotion15DegreeOff_ResultCountEqualTo3TimesTickCount_TestData()
    {
        return new TheoryData<Vector3D , Vector3D , Vector2D , int>
        {
            #region (-, -)
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , 1) , new Vector2D(-4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , 0.5) , new Vector2D(-4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , 0.25) , new Vector2D(-4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , 0.125) , new Vector2D(-4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.125 , 1) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.25  , 1) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.5   , 1) , new Vector2D(-1182.413351D , -2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.125 , 1) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.25  , 1) , new Vector2D(-295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.5   , 1) , new Vector2D(-1182.413351D , -2048) , 16 } ,
            #endregion

            #region (-, +)
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0 , -1) , new Vector2D(-4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.5 , 0 , -0.5) , new Vector2D(-4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.25 , 0 , -0.25) , new Vector2D(-4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(0.125 , 0 , -0.125) , new Vector2D(-4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.125 , -1) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.25  , -1) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , 0.5   , -1) , new Vector2D(-1182.413351D , 2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.125 , -1) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.25  , -1) , new Vector2D(-295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(1 , -0.5   , -1) , new Vector2D(-1182.413351D , 2048) , 16 } ,
            #endregion

            #region (+, -)
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , 1) , new Vector2D(4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , 0.5) , new Vector2D(4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , 0.25) , new Vector2D(4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(73.90083446D , -128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(1182.413351D , -2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , 0.125) , new Vector2D(4729.653405D , -8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.125 , 1) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.25  , 1) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.5   , 1) , new Vector2D(1182.413351D , -2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.125 , 1) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.25  , 1) , new Vector2D(295.6033378D , -512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.5   , 1) , new Vector2D(1182.413351D , -2048) , 16 } ,
            #endregion

            #region (+, +)
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.5 , 0 , -0.5) , new Vector2D(4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.25 , 0 , -0.25) , new Vector2D(4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(73.90083446D , 128 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(1182.413351D , 2048) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-0.125 , 0 , -0.125) , new Vector2D(4729.653405D , 8192) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.125 , -1) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.25  , -1) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0.5   , -1) , new Vector2D(1182.413351D , 2048) , 16 } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.125 , -1) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.25  , -1) , new Vector2D(295.6033378D , 512 ) , 16 } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , -0.5   , -1) , new Vector2D(1182.413351D , 2048) , 16 } ,
            #endregion
        };
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_ValidConfigWithMotion_ValidResult_TestData))]
    public void CalculateTntAmountWithFixTntLocation_ValidConfigWithMotion_ValidResult(
        ThrownEnderpearl enderPearl , PrimedTnt tnt , Vector2D destination , int tickCount)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"Ender pearl position: {enderPearl.Position}");
            _testOutputHelper.WriteLine($"Ender pearl motion: {enderPearl.Motion}");
            _testOutputHelper.WriteLine($"TNT position: {tnt.Position}");
            _testOutputHelper.WriteLine($"Destination: {destination}");
            _testOutputHelper.WriteLine($"Tick count: {tickCount}");

            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    enderPearl , tnt , destination , maxTnt: int.MaxValue , maxTravellingTickCount: tickCount , maxErrorPerAxis: double.MaxValue
                );

            Assert.NotNull(results);
            foreach (SingleTntReturnFtlTntConfigResult result in results)
            {
                ThrownEnderpearl enderPearlTest = enderPearl.DeepCopy();
                tnt.AccelerateEntity(enderPearlTest , tntCount: result.TntCount);
                for (int i = 0; i < result.TravellingTicks; i++)
                    enderPearlTest.Tick();
                Assert.Equal((Vector2D)enderPearlTest.Position - destination , result.Error);
            }
        }
    }
    public static TheoryData<ThrownEnderpearl , PrimedTnt , Vector2D , int>
        CalculateTntAmountWithFixTntLocation_ValidConfigWithMotion_ValidResult_TestData()
    {
        return new TheoryData<ThrownEnderpearl , PrimedTnt , Vector2D , int>
        {
            { new ThrownEnderpearl().WithMotion(1 , 0 , 1) , new PrimedTnt().WithPosition(-1 , 0 , -1) , new Vector2D(+100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(1 , 0 , 1) , new PrimedTnt().WithPosition(-1 , 0 , +1) , new Vector2D(+100 , -100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(1 , 0 , 1) , new PrimedTnt().WithPosition(+1 , 0 , -1) , new Vector2D(-100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(1 , 0 , 1) , new PrimedTnt().WithPosition(+1 , 0 , +1) , new Vector2D(-100 , -100) , 16 } ,

            { new ThrownEnderpearl().WithMotion(1 , 0 , -1) , new PrimedTnt().WithPosition(-1 , 0 , -1) , new Vector2D(+100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(1 , 0 , -1) , new PrimedTnt().WithPosition(-1 , 0 , +1) , new Vector2D(+100 , -100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(1 , 0 , -1) , new PrimedTnt().WithPosition(+1 , 0 , -1) , new Vector2D(-100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(1 , 0 , -1) , new PrimedTnt().WithPosition(+1 , 0 , +1) , new Vector2D(-100 , -100) , 16 } ,

            { new ThrownEnderpearl().WithMotion(-1 , 0 , 1) , new PrimedTnt().WithPosition(-1 , 0 , -1) , new Vector2D(+100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(-1 , 0 , 1) , new PrimedTnt().WithPosition(-1 , 0 , +1) , new Vector2D(+100 , -100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(-1 , 0 , 1) , new PrimedTnt().WithPosition(+1 , 0 , -1) , new Vector2D(-100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(-1 , 0 , 1) , new PrimedTnt().WithPosition(+1 , 0 , +1) , new Vector2D(-100 , -100) , 16 } ,

            { new ThrownEnderpearl().WithMotion(-1 , 0 , -1) , new PrimedTnt().WithPosition(-1 , 0 , -1) , new Vector2D(+100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(-1 , 0 , -1) , new PrimedTnt().WithPosition(-1 , 0 , +1) , new Vector2D(+100 , -100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(-1 , 0 , -1) , new PrimedTnt().WithPosition(+1 , 0 , -1) , new Vector2D(-100 , +100) , 16 } ,
            { new ThrownEnderpearl().WithMotion(-1 , 0 , -1) , new PrimedTnt().WithPosition(+1 , 0 , +1) , new Vector2D(-100 , -100) , 16 } ,
        };
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_CommonTestWithDestination_TestData))]
    public void CalculateTntAmountWithFixTntLocation_DecreasingMaxTnt_ResultCountDecreasing(Vector3D enderPearlPos , Vector3D tntPos , Vector2D destination)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"Ender pearl position: {enderPearlPos}");
            _testOutputHelper.WriteLine($"TNT position: {tntPos}");
            _testOutputHelper.WriteLine($"Destination: {destination}");

            int maxTnt = int.MaxValue;
            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                    maxTnt: maxTnt - 1 , maxTravellingTickCount: 3 , maxErrorPerAxis: double.MaxValue
                );
            int sizeBefore = results?.Count ?? throw new InvalidOperationException();
            maxTnt = results.Max(result => result.TntCount);
            while (true)
            {
                int numberOfResultToBeRemoved = results.Count(result => result.TntCount == maxTnt);
                results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                        new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                        maxTnt: maxTnt - 1 , maxTravellingTickCount: 3 , maxErrorPerAxis: int.MaxValue
                    );
                int sizeAfter = results?.Count ?? throw new InvalidOperationException();

                _testOutputHelper.WriteLine($"size before = {sizeBefore}, size after = {sizeAfter}, expected difference = {numberOfResultToBeRemoved}");
                Assert.True(sizeBefore - sizeAfter == numberOfResultToBeRemoved);

                if (sizeAfter == 0)
                    break;
                maxTnt = results.Max(result => result.TntCount);
                sizeBefore = sizeAfter;
            }
        }
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_CommonTestWithDestination_TestData))]
    public void CalculateTntAmountWithFixTntLocation_DecreasingMaxErrorPerAxis_ResultCountDecreasing(
        Vector3D enderPearlPos , Vector3D tntPos , Vector2D destination)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"Ender pearl position: {enderPearlPos}");
            _testOutputHelper.WriteLine($"TNT position: {tntPos}");
            _testOutputHelper.WriteLine($"Destination: {destination}");

            double maxErrorPerAxis = double.MaxValue;
            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                    maxTnt: int.MaxValue , maxTravellingTickCount: 3 , maxErrorPerAxis: maxErrorPerAxis
                );
            int sizeBefore = results?.Count ?? throw new InvalidOperationException();
            Func<SingleTntReturnFtlTntConfigResult , double> getAbsMaxMagnitude = result => Math.Abs(double.MaxMagnitudeNumber(result.Error.X , result.Error.Z));
            maxErrorPerAxis = results.Max(getAbsMaxMagnitude);
            while (true)
            {
#pragma warning disable S1244  // ReSharper disable once CompareOfFloatsByEqualityOperator
                int numberOfResultToBeRemoved = results.Count(result => Math.Abs(double.MaxMagnitudeNumber(result.Error.X , result.Error.Z)) == maxErrorPerAxis);
#pragma warning restore S1244  // no arithmetic process involve thus the value should be exact (unless bit flips)
                results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                        new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                        maxTnt: int.MaxValue , maxTravellingTickCount: 3 , maxErrorPerAxis: maxErrorPerAxis - 1E-11
                    );
                int sizeAfter = results?.Count ?? throw new InvalidOperationException();

                _testOutputHelper.WriteLine($"size before = {sizeBefore}, size after = {sizeAfter}, expected difference = {numberOfResultToBeRemoved}");
                Assert.True(sizeBefore - sizeAfter == numberOfResultToBeRemoved);

                if (sizeAfter == 0)
                    break;
                maxErrorPerAxis = results.Max(getAbsMaxMagnitude);
                sizeBefore = sizeAfter;
            }
        }
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_CommonTestWithDestination_TestData))]
    public void CalculateTntAmountWithFixTntLocation_DecreasingMaxTravellingTick_ResultCountDecreasing(
        Vector3D enderPearlPos , Vector3D tntPos , Vector2D destination)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            _testOutputHelper.WriteLine($"Ender pearl position: {enderPearlPos}");
            _testOutputHelper.WriteLine($"TNT position: {tntPos}");
            _testOutputHelper.WriteLine($"Destination: {destination}");

            int maxTicks = 8;
            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                    maxTnt: int.MaxValue - 1 , maxTravellingTickCount: maxTicks , maxErrorPerAxis: double.MaxValue
                );
            while (maxTicks >= 1)
            {
                int previousResultCount = results?.Count ?? throw new InvalidOperationException();
                results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                        new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                        maxTnt: int.MaxValue - 1 , maxTravellingTickCount: --maxTicks , maxErrorPerAxis: double.MaxValue
                    );
                int currentResultCount = results?.Count ?? throw new InvalidOperationException();
                Assert.True(previousResultCount > currentResultCount);
            }
        }
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_DeceasingMaxAngleError_LessConfigBecomeValid_TestData))]
    public void CalculateTntAmountWithFixTntLocation_DeceasingMaxAngleError_LessConfigBecomeValid(List<(Vector2D enderPearlPos , Vector2D tntPos)> configs)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            const double AngleToRadiantRatio = Math.PI / 180;
            foreach ((Vector2D enderPearlPos , Vector2D tntPos) in configs)
            {
                Vector2D distanceVector = (enderPearlPos - tntPos) * 512;
                for (int maxAngle = 90; maxAngle >= 0; maxAngle -= 15)
                {
                    List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                            new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , distanceVector + enderPearlPos ,
                            maxAngleErrorOnAccelerateDirection: maxAngle , maxErrorPerAxis: double.MaxValue
                        );
                    Assert.NotNull(results);
                    for (double angle = 7.5D; angle < 90D; angle += 15D)
                    {
                        Vector2D vectorIClockWise = new Vector2D(+Math.Cos(angle * AngleToRadiantRatio) , Math.Sin(angle * AngleToRadiantRatio));
                        Vector2D vectorKClockWise = new Vector2D(-Math.Sin(angle * AngleToRadiantRatio) , Math.Cos(angle * AngleToRadiantRatio));
                        Vector2D destinationClockWise = enderPearlPos + vectorIClockWise * distanceVector.X + vectorKClockWise * distanceVector.Z;
                        results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                                new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destinationClockWise ,
                                maxAngleErrorOnAccelerateDirection: maxAngle , maxErrorPerAxis: double.MaxValue
                            );
                        if (angle > maxAngle)  { Assert.Null(results); }
                        else                   { Assert.NotNull(results); }

                        Vector2D vectorICounterClockWise = new Vector2D(Math.Cos(angle * AngleToRadiantRatio) , -Math.Sin(angle * AngleToRadiantRatio));
                        Vector2D vectorKCounterClockWise = new Vector2D(Math.Sin(angle * AngleToRadiantRatio) , +Math.Cos(angle * AngleToRadiantRatio));
                        Vector2D destinationCounterClockWise = enderPearlPos + vectorICounterClockWise * distanceVector.X + vectorKCounterClockWise * distanceVector.Z;
                        results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                                new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destinationCounterClockWise ,
                                maxAngleErrorOnAccelerateDirection: maxAngle , maxErrorPerAxis: double.MaxValue
                            );
                        if (angle > maxAngle) { Assert.Null(results); }
                        else                  { Assert.NotNull(results); }
                    }
                }
            }
        }
    }
    public static TheoryData<List<(Vector2D enderPearlPos , Vector2D tntPos)>>
        CalculateTntAmountWithFixTntLocation_DeceasingMaxAngleError_LessConfigBecomeValid_TestData()
    {
        return new TheoryData<List<(Vector2D enderPearlPos , Vector2D tntPos)>>
        {
            new List<(Vector2D enderPearlPos , Vector2D tntPos)>
            {
                (new Vector2D(0 , 0) , new Vector2D(-1 , -1)) ,
                (new Vector2D(0 , 0) , new Vector2D(+1 , -1)) ,
                (new Vector2D(0 , 0) , new Vector2D(-1 , +1)) ,
                (new Vector2D(0 , 0) , new Vector2D(+1 , +1)) ,

                (new Vector2D(0 , 0) , new Vector2D(-1 , -1)) ,
                (new Vector2D(0 , 0) , new Vector2D(+1 , -1)) ,
                (new Vector2D(0 , 0) , new Vector2D(-1 , +1)) ,
                (new Vector2D(0 , 0) , new Vector2D(+1 , +1)) ,

                (new Vector2D(0 , 0) , new Vector2D(-1 , -1)) ,
                (new Vector2D(0 , 0) , new Vector2D(+1 , -1)) ,
                (new Vector2D(0 , 0) , new Vector2D(-1 , +1)) ,
                (new Vector2D(0 , 0) , new Vector2D(+1 , +1)) ,
            } ,
        };
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_CommonTestWithoutDestination_TestData))]
    public void CalculateTntAmountWithFixTntLocation_InfeasibleDirection_ReturnNull(Vector2D enderPearlPos , Vector2D tntPos)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            Assert.Null(
                    SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                            new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , tntPos ,
                            maxTnt: int.MaxValue , maxErrorPerAxis: double.MaxValue , maxTravellingTickCount: int.MaxValue
                        )
                );
        }
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_CommonTestWithoutDestination_TestData))]
    public void CalculateTntAmountWithFixTntLocation_TntCountSupposedToBeZero_EmptyResult(Vector2D enderPearlPos , Vector2D tntPos)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , enderPearlPos ,
                    maxTnt: int.MaxValue , maxErrorPerAxis: double.MaxValue , maxTravellingTickCount: 1
                );
            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }


    [Theory , MemberData(nameof(CalculateTntAmountWithFixTntLocation_CommonTestWithoutDestination_TestData))]
    public void CalculateTntAmountWithFixTntLocation_DuplicateResultGetRemoved_OneResult(Vector2D enderPearlPos , Vector2D tntPos)
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        TestCode();
        EnderDynamicsConfig.TrySetMinecraftVersion("Latest");
        TestCode();
        return;

        void TestCode()
        {
            PrimedTnt tnt = new PrimedTnt().WithPosition(tntPos);
            ThrownEnderpearl enderPearl = new ThrownEnderpearl().WithPosition(enderPearlPos);
            tnt.AccelerateEntity(enderPearl);
            enderPearl.Tick();
            Vector2D destination = (Vector2D)enderPearl.Position * 0.75 + enderPearlPos * 0.25;
            List<SingleTntReturnFtlTntConfigResult>? results = SingleTntReturnFtl.CalculateTntAmountWithFixTntLocation(
                    new ThrownEnderpearl().WithPosition(enderPearlPos) , new PrimedTnt().WithPosition(tntPos) , destination ,
                    maxTnt: int.MaxValue , maxErrorPerAxis: double.MaxValue , maxTravellingTickCount: 128
                );
            Assert.NotNull(results);
            Assert.Single(results);
        }
    }
    #endregion

    public static TheoryData<Vector3D , Vector3D , Vector2D> CalculateTntAmountWithFixTntLocation_CommonTestWithDestination_TestData()
    {
        return new TheoryData<Vector3D , Vector3D , Vector2D>
        {
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(+512 , +512) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(+1 , 0 , -1) , new Vector2D(-512 , +512) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , +1) , new Vector2D(+512 , -512) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(+1 , 0 , +1) , new Vector2D(-512 , -512) } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(+384 , +512) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(+1 , 0 , -1) , new Vector2D(-384 , +512) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , +1) , new Vector2D(+384 , -512) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(+1 , 0 , +1) , new Vector2D(-384 , -512) } ,

            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , -1) , new Vector2D(+512 , +384) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(+1 , 0 , -1) , new Vector2D(-512 , +384) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(-1 , 0 , +1) , new Vector2D(+512 , -384) } ,
            { new Vector3D(0 , 0 , 0) , new Vector3D(+1 , 0 , +1) , new Vector2D(-512 , -384) } ,
        };
    }

    public static TheoryData<Vector2D , Vector2D> CalculateTntAmountWithFixTntLocation_CommonTestWithoutDestination_TestData()
    {
        return new TheoryData<Vector2D , Vector2D>
        {
            { new Vector2D(0 , 0) , new Vector2D(-1 , -1) } ,
            { new Vector2D(0 , 0) , new Vector2D(+1 , -1) } ,
            { new Vector2D(0 , 0) , new Vector2D(-1 , +1) } ,
            { new Vector2D(0 , 0) , new Vector2D(+1 , +1) } ,

            { new Vector2D(0 , 0) , new Vector2D(-1 , -1) } ,
            { new Vector2D(0 , 0) , new Vector2D(+1 , -1) } ,
            { new Vector2D(0 , 0) , new Vector2D(-1 , +1) } ,
            { new Vector2D(0 , 0) , new Vector2D(+1 , +1) } ,

            { new Vector2D(0 , 0) , new Vector2D(-1 , -1) } ,
            { new Vector2D(0 , 0) , new Vector2D(+1 , -1) } ,
            { new Vector2D(0 , 0) , new Vector2D(-1 , +1) } ,
            { new Vector2D(0 , 0) , new Vector2D(+1 , +1) } ,
        };
    }
}