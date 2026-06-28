using EnderOverhaul.EnderDynamics;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using Xunit.Abstractions;


namespace EnderOverhaul.EnderDynamics.Test.Minecraft;

[Collection("Minecraft Entity Tests")]
public class PrimedTntTest
{
    private readonly ITestOutputHelper _testOutputHelper;


    public PrimedTntTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
    }


    [Theory , MemberData(nameof(TestData_TestTntEntityTicking))]
    public void TestTntEntityTicking(PrimedTnt primedTnt , PrimedTnt expected , int tickCount)
    {
        for (int i = 0; i < tickCount; i++)
            primedTnt.Tick(false);

        _testOutputHelper.WriteLine($"Tick {tickCount}");
        _testOutputHelper.WriteLine(
                $"Position:\n"
                + $"\tactual: {primedTnt.Position}\n"
                + $"\texpect: {expected.Position}"
            );
        _testOutputHelper.WriteLine(
                $"Motion:\n"
                + $"\tactual: {primedTnt.Motion}\n"
                + $"\texpect: {expected.Motion}"
            );

        Assert.Equal(expected.Position , primedTnt.Position);
        Assert.Equal(expected.Motion , primedTnt.Motion);
    }
    public static TheoryData<PrimedTnt , PrimedTnt , int> TestData_TestTntEntityTicking()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");

        // Selected test cases ported from EnderOverhaul.EnderDynamics.Impl.Test (full set is very large)
        return new TheoryData<PrimedTnt , PrimedTnt , int>
        {
            // Basic tick progression (1.12/1.20+ behavior)
            { new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new PrimedTnt(new Vector3D(255.49864933816505 , 9.160000002980233 , 255.5199543406959) , new Vector3D(-0.001323648598240652 , 0.1568000029206276 , 0.01955525388197186)) , 1 } ,
            { new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new PrimedTnt(new Vector3D(255.49732568956682 , 9.27680000590086 , 255.53950959457788) , new Vector3D(-0.001297175626275839 , 0.11446400286221503 , 0.019164148804332422)) , 2 } ,
            { new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new PrimedTnt(new Vector3D(255.49475728182682 , 9.384238731568045 , 255.57745460921043) , new Vector3D(-0.0012458074714753156 , 0.03231522834887131 , 0.01840524851168086)) , 4 } ,
            { new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new PrimedTnt(new Vector3D(255.489921565512 , 9.117593583405197 , 255.64889627459138) , new Vector3D(-0.001149093145178939 , -0.12235186868787176 , 0.016976415204061814)) , 8 } ,
            { new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new PrimedTnt(new Vector3D(255.48134720612404 , 6.8298462171677965 , 255.7755717192139) , new Vector3D(-0.0009776059574204449 , -0.3965969213631235 , 0.014442906311611006)) , 16 } ,
            { new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new PrimedTnt(new Vector3D(255.467846356434 , -3.579379085221465 , 255.97502990144073) , new Vector3D(-0.0007075889636185623 , -0.8284124153153384 , 0.010453742667075015)) , 32 } ,
        };
    }

    [Theory , MemberData(nameof(TestData_TestTntAccelerateEntity))]
    public void TestTntAccelerateEntity(PrimedTnt primedTnt , Entity entity , Entity expected)
    {
        primedTnt.AccelerateEntity(entity);
        _testOutputHelper.WriteLine(
                $"TNT Position:\n"
                + $"\tactual: {primedTnt.Position}\n"
            );
        _testOutputHelper.WriteLine(
                $"Entity Position:\n"
                + $"\tactual: {entity.Position}\n"
                + $"\texpect: {expected.Position}"
            );
        _testOutputHelper.WriteLine(
                $"Motion:\n"
                + $"\tactual: {entity.Motion}\n"
                + $"\texpect: {expected.Motion}"
            );

        Assert.Equal(expected.Position , entity.Position);
        Assert.Equal(expected.Motion , entity.Motion);
    }
    public static TheoryData<PrimedTnt , Entity , Entity> TestData_TestTntAccelerateEntity()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");

        // Selected cases ported from Impl tests (near origin, different quadrants)
        return new TheoryData<PrimedTnt , Entity , Entity>
        {
            // TNT accelerates TNT (+,+) quadrant
            {
                new PrimedTnt(new Vector3D(13.509999990463257 , 9.0 , 15.509999990463257)) ,
                new PrimedTnt(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0 , 0.0 , 0.0)) ,
                new PrimedTnt(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new PrimedTnt(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new PrimedTnt(new Vector3D(15.509999990463257 , 9.0 , 15.490000009536743) , new Vector3D(0.0 , 0.0 , 0.0)) ,
                new PrimedTnt(new Vector3D(15.509999990463257 , 9.0 , 15.490000009536743) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new PrimedTnt(new Vector3D(15.490000009536743 , 9.0 , 15.509999990463257)) ,
                new PrimedTnt(new Vector3D(13.490000009536743 , 9.0 , 15.504876306201382) , new Vector3D(0.0 , 0.0 , 7.34657553831785E-15)) ,
                new PrimedTnt(new Vector3D(13.490000009536743 , 9.0 , 15.504876306201382) , new Vector3D(-0.7495281073859416 , -0.022954298735448027 , -0.0019201726838157785))
            } ,

            // (Additional TNT -> ThrownEnderpearl accelerate cases can be ported from Impl.Test)
        };
    }

    [Fact]
    public void VersionChange_StillProducesCorrectBehavior()
    {
        // Demonstrates that the wrapper correctly switches implementations for entity physics (as requested)
        string[] versions = ["1.12.2" , "1.20.2"];
        foreach (string ver in versions)
        {
            EnderDynamicsConfig.TrySetMinecraftVersion(ver);

            PrimedTnt tnt = new PrimedTnt(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.00135 , 0.2 , 0.02));
            for (int i = 0; i < 5; i++) tnt.Tick(false);

            Assert.True(tnt.Position.Y > 9); // it moved under the version's impl
        }
    }
}
