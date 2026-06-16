using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using System.Numerics;
using Xunit.Abstractions;

namespace EnderOverhaul.EnderDynamics.Test.Minecraft;

public class TntEntityTest(ITestOutputHelper testOutputHelper)
{
    [Theory , MemberData(nameof(TestData_TestTntEntityTicking))]
    public void TestTntTick(TntEntity tnt , TntEntity expected , int tickCount)
    {
        for (int i = 0; i < tickCount; i++)
            tnt.Tick(false);

        testOutputHelper.WriteLine($"Tick {tickCount}");
        testOutputHelper.WriteLine(
                $"Position:\n"
              + $"\tactual: ({tnt.Position.X}, {tnt.Position.Y}, {tnt.Position.Z})\n"
              + $"\texpect: ({expected.Position.X}, {expected.Position.Y}, {expected.Position.Z})"
            );
        testOutputHelper.WriteLine(
                $"Motion:\n"
              + $"\tactual: ({tnt.Motion.X}, {tnt.Motion.Y}, {tnt.Motion.Z})\n"
              + $"\texpect: ({expected.Motion.X}, {expected.Motion.Y}, {expected.Motion.Z})"
            );

        Assert.Equal(expected.Position , tnt.Position);
        Assert.Equal(expected.Motion ,   tnt.Motion);
    }
    public static TheoryData<TntEntity , TntEntity , int> TestData_TestTntEntityTicking()
    {
#if VERSION_1_12_ABOVE || VERSION_1_20_2_ABOVE
        return new TheoryData<TntEntity , TntEntity , int>
        {
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.49864933816505 , 9.160000002980233   , 255.5199543406959 ) , new Vector3D(-0.001323648598240652  , 0.1568000029206276   , 0.01955525388197186 )) , 1  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.49732568956682 , 9.27680000590086    , 255.53950959457788) , new Vector3D(-0.001297175626275839  , 0.11446400286221503  , 0.019164148804332422)) , 2  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.49475728182682 , 9.384238731568045   , 255.57745460921043) , new Vector3D(-0.0012458074714753156 , 0.03231522834887131  , 0.01840524851168086 )) , 4  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.489921565512   , 9.117593583405197   , 255.64889627459138) , new Vector3D(-0.001149093145178939  , -0.12235186868787176 , 0.016976415204061814)) , 8  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.48134720612404 , 6.8298462171677965  , 255.7755717192139 ) , new Vector3D(-9.776059574204449E-4  , -0.3965969213631235  , 0.014442906311611006)) , 16 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.467846356434   , -3.579379085221465  , 255.97502990144073) , new Vector3D(-7.075889636185623E-4  , -0.8284124153153384  , 0.010453742667075015)) , 32 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.45100160466941 , -40.64098272241724  , 256.2238900579606 ) , new Vector3D(-3.7069392832680416E-4 , -1.3671803425714235  , 0.005476539536680117)) , 64 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.001350661834939441 , 0.20000000298023224 , 0.019954340695889656)) , new TntEntity(new Vector3D(255.4461560623531  , -62.891913971867396 , 256.2954768902342 ) , new Vector3D(-2.737830820004273E-4  , -1.522161717582421   , 0.00404480289120791 )) , 79 } ,

            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(255.48011194117944 , 9.160000002980233   , 255.4978869178079 ) , new Vector3D(-0.019490297644133868 , 0.1568000029206276   , -0.0020708205482537203)) , 1  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(255.46062164353532 , 9.27680000590086    , 255.49581609725965) , new Vector3D(-0.01910049169125119  , 0.11446400286221503  , -0.002029404137288646 )) , 2  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(255.42280266998662 , 9.384238731568045   , 255.49179787706782) , new Vector3D(-0.01834411222027764  , 0.03231522834887131  , -0.0019490397334520153)) , 4  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(255.35159831074526 , 9.117593583405197   , 255.48423250003077) , new Vector3D(-0.016920025035450998 , -0.12235186868787176 , -0.0017977321927110258)) , 8  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(255.2253436410387  , 6.8298462171677965  , 255.4708180940984 ) , new Vector3D(-0.014394931641319768 , -0.3965969213631235  , -0.001529444074063413 )) , 16 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(255.02654799447637 , -3.579379085221465  , 255.44969629712432) , new Vector3D(-0.010419018710072041 , -0.8284124153153384  , -0.0011070081345807988)) , 32 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(254.7785144710248  , -40.64098272241724  , 255.4233430352913 ) , new Vector3D(-0.005458348241040542 , -1.3671803425714235  , -5.7994289792046E-4   )) , 64 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(-0.019888058820544764 , 0.20000000298023224 , -0.002113082192095633)) , new TntEntity(new Vector3D(254.7071654270884  , -62.891913971867396 , 255.41576228568042) , new Vector3D(-0.00403136736231143  , -1.522161717582421   , -4.28327905702689E-4  )) , 79 } ,

            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(255.51939831947155 , 9.160000002980233   , 255.49513120120776) , new Vector3D(0.01901035308212712  , 0.1568000029206276   , -0.004771422816399738 )) , 1  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(255.5384086725537  , 9.27680000590086    , 255.49035977839137) , new Vector3D(0.018630146020484576 , 0.11446400286221503  , -0.0046759943600717425)) , 2  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(255.57529636167425 , 9.384238731568045   , 255.48110130955843) , new Vector3D(0.017892392238073384 , 0.03231522834887131  , -0.0044908249834129015)) , 4  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(255.6447473282464  , 9.117593583405197   , 255.46366975922942) , new Vector3D(0.01650337290663003  , -0.12235186868787176 , -0.004142193976832588 )) , 8  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(255.76789300273597 , 6.8298462171677965  , 255.4327613337803 ) , new Vector3D(0.014040459416838912 , -0.3965969213631235  , -0.0035240254678501584)) , 16 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(255.96179334747896 , -3.579379085221465  , 255.38409414043477) , new Vector3D(0.010162452521979446 , -0.8284124153153384  , -0.002550681600939848 )) , 32 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(256.2037190965419  , -40.64098272241724  , 255.32337301474251) , new Vector3D(0.005323937540718837 , -1.3671803425714235  , -0.0013362590870947986)) , 64 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.019398319471558283 , 0.20000000298023224 , -0.004868798792244631)) , new TntEntity(new Vector3D(256.2733111849784  , -62.891913971867396 , 255.3059060441307 ) , new Vector3D(0.003932095771988889 , -1.522161717582421   , -9.869196748573718E-4 )) , 79 } ,

            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(255.51595053044923 , 9.160000002980233   , 255.51206567770114) , new Vector3D(0.015631519840246667 , 0.1568000029206276   , 0.011824364147131755 )) , 1  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(255.53158205028947 , 9.27680000590086    , 255.5238900418483 ) , new Vector3D(0.015318889443441733 , 0.11446400286221503  , 0.01158787686418912  )) , 2  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(255.56191345138748 , 9.384238731568045   , 255.54683403803938) , new Vector3D(0.01471226142148144  , 0.03231522834887131  , 0.01112899694036723  )) , 4  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(255.61902044762303 , 9.117593583405197   , 255.59003226353113) , new Vector3D(0.01357012149677082  , -0.12235186868787176 , 0.010265032430532152 )) , 8  } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(255.72027864339182 , 6.8298462171677965  , 255.6666283841828 ) , new Vector3D(0.011544957581394804 , -0.3965969213631235  , 0.008733110017499587 )) , 16 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(255.87971582337408 , -3.579379085221465  , 255.78723362884026) , new Vector3D(0.00835621398175061  , -0.8284124153153384  , 0.006321005124349689 )) , 32 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(256.078642541358   , -40.64098272241724  , 255.93771048432686) , new Vector3D(0.004377679622069845 , -1.3671803425714235  , 0.003311468014617263 )) , 64 } ,
            { new TntEntity(new Vector3D(255.5 , 9.0 , 255.5) , new Vector3D(0.015950530449231292 , 0.20000000298023224 , 0.012065677701154852)) , new TntEntity(new Vector3D(256.1358655769545  , -62.891913971867396 , 255.980996487058  ) , new Vector3D(0.003233218910141195 , -1.522161717582421   , 0.0024457479599948287)) , 79 } ,
        };
#else
        throw new NotSupportedException();
#endif
    }


    /*  Test TNT accelerating ender pearl with:
     *   -  Extreme far / origin / around 1024~4096 for X or Z / near world border
     *   -  +X+Z / +X-Z / -X+Z / -X-Z / +X / -X / +Z / -Z
     *   -  0 TNT / only 1 TNT / 2 TNT / 256 TNT / 1024 TNT / 4096 TNT
     */


    /*  Test TNT accelerating TNT with:
     *   -  Extreme far / origin / around 1024~4096 for X or Z / near world border
     *   -  +X+Z / +X-Z / -X+Z / -X-Z / +X / -X / +Z / -Z
     *   -  0 TNT / only 1 TNT / 2 TNT / 256 TNT / 1024 TNT / 4096 TNT
     */


    [Theory, MemberData(nameof(TestData_TestTntAccelerateEntity))]
    public void TestTntAccelerateEntity(TntEntity tnt , Entity entity , Entity expected)
    {
        tnt.AccelerateEntity(entity);
        testOutputHelper.WriteLine(
                $"TNT Position:\n"
              + $"\tactual: ({tnt.Position.X}, {tnt.Position.Y}, {tnt.Position.Z})\n"
            );
        testOutputHelper.WriteLine(
                $"Entity Position:\n"
              + $"\tactual: ({entity.Position.X}, {entity.Position.Y}, {entity.Position.Z})\n"
              + $"\texpect: ({expected.Position.X}, {expected.Position.Y}, {expected.Position.Z})"
            );
        testOutputHelper.WriteLine(
                $"Motion:\n"
              + $"\tactual: ({entity.Motion.X}, {entity.Motion.Y}, {entity.Motion.Z})\n"
              + $"\texpect: ({expected.Motion.X}, {expected.Motion.Y}, {expected.Motion.Z})"
            );

        Assert.Equal(expected.Position , entity.Position);
        Assert.Equal(expected.Motion   , entity.Motion  );
    }
    public static TheoryData<TntEntity , Entity , Entity> TestData_TestTntAccelerateEntity()
    {
#if VERSION_1_12_ABOVE
        return new TheoryData<TntEntity , Entity , Entity>
        {
            #region TNT acclerate TNT
            #region Explosion near origin
            #region (+, +) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(13.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(13.50174869814671 ,  9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.7509439029953983 , -0.023133551925841114 , -0.007553805522848947))
            } ,
            {
                new TntEntity(new Vector3D(13.509999990463257 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 15.490000009536743) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 15.490000009536743) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.498334308995103) , new Vector3D(0.0 , 0.0                   , -2.6856980163059582E-15)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.498334308995103) , new Vector3D(0.0 , -0.022827487572971927 , 0.7484934754446543     ))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.504876306201382) , new Vector3D(0.0                 , 0.0                   , 7.34657553831785E-15  )) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.504876306201382) , new Vector3D(-0.7495281073859416 , -0.022954298735448027 , -0.0019201726838157785))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 13.509999990463257) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 13.509999990463257) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.509999990463257) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.509999990463257) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 13.490000009536743) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , 15.507786290646388)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 13.490000009536743) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , 13.490000009536743) , new Vector3D(0.007406795872925919 , -0.022683334434828523 , -0.7472672676180734))
            } ,
            #endregion
            #endregion

            #region (+, -) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(13.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0               , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.490000009536743)) ,
                new TntEntity(new Vector3D(15.480998946567178 , 9.0 , -15.509999990463257) , new Vector3D(-1.7900585844615553E-14 , 0.0                   , 0.0                   )) ,
                new TntEntity(new Vector3D(15.480998946567178 , 9.0 , -15.509999990463257) , new Vector3D(0.7506018958056148      , -0.023091105754909507 , -0.0075399455621548515))
            } ,
            {
                new TntEntity(new Vector3D(13.509999990463257 , 9.0 , -15.490000009536743)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(13.501352049788592 , 9.0 , -15.490000009536743)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.7484049177512659 , -0.022821222761932356 , -0.007451820588981297))
            } ,
            #endregion

            #region Test compute acccuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.509999990463257) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.509999990463257) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -13.490000009536743) , new Vector3D(0.0                  , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -13.490000009536743) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.498185059827154) , new Vector3D(0.0                   , 0.0                  , 2.0074704782716004E-15)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.498185059827154) , new Vector3D(-0.007436170547251094 , -0.02277329446249281 , 0.7480106600443664    ))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -13.490000009536743) , new Vector3D(0.0                  , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -13.490000009536743) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0                 , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(13.509999990463257 , 9.0 , -15.490000009536743) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(13.509999990463257 , 9.0 , -15.490000009536743) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.490000009536743)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(13.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -13.509999990463257)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.490000009536743)) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.509999990463257)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(15.490000009536743 , 9.0 , -13.495640273036747)) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.007423630796427676 , -0.022734891438224682 , -0.7476938547249653))
            } ,
            #endregion
            #endregion

            #region (-, +) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.507896206577971) , new Vector3D(0.0               , 0.0                  , 1.659473937706981E-14)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.507896206577971) , new Vector3D(0.749530831815761 , -0.02295438217111287 , -7.884254427327365E-4))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 13.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.498580664985598) , new Vector3D(0.0 , 0.0                 , -2.2884828107105096E-15)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.498580664985598) , new Vector3D(0.0 , -0.0231300130906625 , 0.7509534063401444     ))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.509999990463257) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.509999990463257) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 13.509999990463257)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 13.490000009536743)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.509999990463257) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.490000009536743) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.490000009536743) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(-15.475306633714633 , 9.0 , 15.509999990463257) , new Vector3D(2.29591680615472E-14 , 0.0                   , 0.0                 )) ,
                new TntEntity(new Vector3D(-15.475306633714633 , 9.0 , 15.509999990463257) , new Vector3D(-0.7537996737246154  , -0.023492634634282798 , 0.007671056905381193))
            } ,
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 15.490000009536743) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-15.507949844177038 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 13.490000009536743) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 13.490000009536743) , new Vector3D(0.006637895027622753 , -0.022650408012238502 , -0.7470011895870158))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.490000009536743)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 13.509999990463257) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 13.509999990463257) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 13.509999990463257) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 13.509999990463257) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , 15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 13.490000009536743) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , 13.490000009536743) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            #endregion
            #endregion

            #region (-, -) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , -15.509999990463257) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.498621887153938)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , -15.499754267890875) , new Vector3D(0.0                , 0.0                   , 3.962092825636985E-16)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , -15.499754267890875) , new Vector3D(0.7495312242157317 , -0.022954394188362207 , -4.243773600170379E-4))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-13.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -13.490000009536743) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -13.490000009536743) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.509999990463257) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.509999990463257) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.490000009536743)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.490000009536743) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.490000009536743) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.490000009536743)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.505199054711303) , new Vector3D(0.0                  , 0.0                   , -7.832823983372031E-15)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.505199054711303) , new Vector3D(0.007571264562555089 , -0.023187020286973215 , 0.751373373215248     ))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.509999990463257 , 9.0 , -15.509999990463257)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.490000009536743)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.490000009536743)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.490000009536743) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.490000009536743) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -13.490000009536743)) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -15.490000009536743) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-15.490000009536743 , 9.0 , -13.490000009536743)) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-15.509999990463257 , 9.0 , -15.509999990463257) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            #endregion
            #endregion
            #endregion

            #region Explosion around 2048
            #region (+, +) quadrant around 2048
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2050.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900121587752)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0                   )) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.7495313842578036 , -0.022954399089650752 , -4.5531177755050225E-6))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2050.5099999904633) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2050.5099999904633) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2050.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2050.5099999904633) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2050.4900000095367) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2050.4900000095367) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2050.4900000095367) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2050.4900000095367) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(2050.4900000095367 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2050.4900000095367 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                  , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(2048.506651886317 ,  9.0 , 2048.5099999904633) , new Vector3D(1.0021640004435387E-14 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.506651886317 ,  9.0 , 2048.5099999904633) , new Vector3D(0.0063242360869521855  , -0.023262210799414523 , -0.7519865621239898))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.511173536464) , new Vector3D(0.0                   , 0.0                   , 1.073362119161567E-14)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , 2048.511173536464) , new Vector3D(0.0075006694716011875 , -0.022970822610536925 , -0.7496275430275939  ))
            } ,
            #endregion
            #endregion

            #region (+, -) quadrant around 2048
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , 9.0 , -2047.4900000095367) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.5079413992246) , new Vector3D(0.0                , 0.0                  , -1.1449145623683403E-14)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.5079413992246) , new Vector3D(0.7494912065559989 , -0.02295316864750904 , -0.006723456902229967  ))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.4931744445332)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.4900000095367) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.4900000095367) , new Vector3D(0.0 , -0.022905935671469063 , 0.7491360629178939))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.4900000095367) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.50540484516) , new Vector3D(0.0                   , 0.0                   , -1.187006564100552E-14)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.50540484516) , new Vector3D(-0.007517800162901857 , -0.023023285403698714 , -0.7500534623914519   ))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            #endregion
            #endregion

            #region (-, +) quadrant around 2048
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.0 ,               0.0 ,                  0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2047.501798213867 ,  9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.0 ,                0.0 ,                   0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.7505527418371833 , -0.023080328013194252 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0 ,                0.0 ,                   0.0)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.0 ,                0.0 ,                  0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2050.5099999904633) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2050.5099999904633) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.508249857802)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2050.4977551169463) , new Vector3D(0.0                  , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2050.4977551169463) , new Vector3D(0.007547475441303922 , -0.023114166032244345 , 0.7507878201938356))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2050.5099999904633) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2050.5099999904633) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2050.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2050.5099999904633) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2045.4900000095367 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-2047.4960888624205 , 9.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2048.4900000095367) , new Vector3D(-0.005144479365456078 , -0.022650885413334966 , -0.7470169340798645))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2050.4932849374827)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.5099999904633) , new Vector3D(0.007578954844463504 , -0.023210571798236587 , -0.7515620696036756))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , 2048.4900000095367) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            #endregion
            #endregion

            #region (-, -) quadrant around 2048
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.501151690126 ,  9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.7506332506454393 , -0.023090298697302974 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5002457979704 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.003891373721034705 , -0.02326288958594097 , 0.7520085049372006))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2045.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2045.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            #endregion 

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.4900000095367) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.4900000095367) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4947016699768 , 9.0 , -2047.4900000095367) , new Vector3D(7.982390796654144E-15 , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-2047.4947016699768 , 9.0 , -2047.4900000095367) , new Vector3D(-0.7513857299974211   , -0.02318856145138308 , 0.007571767799423694))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , 9.0 , -2047.5029151113492)) ,
                new TntEntity(new Vector3D(-2047.5050543583006 , 9.0 , -2047.4900000095367) , new Vector3D(-5.223770890243068E-15 , 0.0                   , 0.0                 )) ,
                new TntEntity(new Vector3D(-2047.5050543583006 , 9.0 , -2047.4900000095367) , new Vector3D(-0.7501263404782832    , -0.023029567509139582 , 0.004855986992481549))
            } ,
            #endregion

            #region Test compuate accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099451156648) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099451156648) , new Vector3D(0.007495081390739968 , -0.02295370909624565 , -0.7494882892876836))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , 9.0 , -2047.5099999904633) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , 9.0 , -2047.4900000095367) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            #endregion
            #endregion
            #endregion

            #region Explosion around world border (+/-29999968, +/-29999968)
            #region (+, +) quadrant around world border (+29999968, +29999968)
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.9999968496264227E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.023050485661220213 , 0.7503114641518467))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997050999999E7) , new Vector3D(0.0                  , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997050999999E7) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(2.999997050999999E7 ,  9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.9999968508983474E7 , 9.0 , 2.999996849000001E7) , new Vector3D(1.2951507802477447E-14 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.9999968508983474E7 , 9.0 , 2.999996849000001E7) , new Vector3D(-0.7494047954047858    , -0.02293886344236164 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                 , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            #endregion

            #region Test compute accuracy when accelerated towards north
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 ,  9.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.9999968508098595E7 , 9.0 , 2.999996850999999E7) , new Vector3D(8.009580553498627E-15 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.9999968508098595E7 , 9.0 , 2.999996850999999E7) , new Vector3D(-7.221667712969804E-4 , -0.02326328890383591 , -0.7520214134992284))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            #endregion
            #endregion

            #region (+, -) quadrant around world border (+29999968, -29999968)
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0               , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849066243E7 , 9.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.007344115077189448 , -0.02326183005513385 , 0.7519742539824662))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2.999997050999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996849000001E7) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                 , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999997050999999E7) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999997050999999E7) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 ,  9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.9999968491329677E7 , 9.0 , -2.999997049000001E7) , new Vector3D(-8.575032034169922E-15 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.9999968491329677E7 , 9.0 , -2.999997049000001E7) , new Vector3D(5.050197027358464E-4   , -0.023263296181495745 , -0.7520216487607195))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999997049000001E7) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 9.0 , -2.999997049000001E7) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 9.0 , -2.999997049000001E7) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            #endregion
            #endregion

            #region (-, +) quadrant around world border (-29999968, +29999968)
            #region Test ompute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.9999968500560973E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997050999999E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997050999999E7) , new Vector3D(0.0 , -0.022810744257725352 , 0.7483558961697714))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 ,  9.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.9999968492510002E7 , 9.0 , 2.999996850999999E7) , new Vector3D(1.0798361140149452E-14 , 0.0                   , 0.0                 )) ,
                new TntEntity(new Vector3D(-2.9999968492510002E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.749793904469761      , -0.022991292758293477 , 0.007507353594976304))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , 2.999996850999999E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996850999999E7) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , 2.999996849000001E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            #endregion
            #endregion

            #region (-, -) quadrant around world border (-29999968, -29999968)
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996848626756E7) , new Vector3D(0.0                  , 0.0                   , 1.3191781273534264E-14)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996848626756E7) , new Vector3D(0.007377717157116063 , -0.022594280780999433 , 0.7465269859095954    ))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996849000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 ,  9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.9999970488917854E7 , 9.0 , -2.999996849000001E7) , new Vector3D(1.0645823521272557E-14 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.9999970488917854E7 , 9.0 , -2.999996849000001E7) , new Vector3D(-0.7496661465878605    , -0.022970955262938648 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 9.0 , -2.999996850999999E7) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 , 9.0 , -2.999996850999999E7) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999997049000001E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999997049000001E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.9999970491047744E7) , new Vector3D(0.0                  , 0.0                  , 6.073748156371669E-15)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.9999970491047744E7) , new Vector3D(0.007489579649826437 , -0.02293685999830148 , -0.7493510340458073  ))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999997050999999E7) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999997050999999E7) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999997050999999E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 9.0 , -2.999997050999999E7) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            #endregion
            #endregion
            #endregion
            #endregion

            #region Tnt accelerate Ender Pearl
            #region Explosion near orgin
            #region (+, +) quadrant near origin
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 11.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 15.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (+, -) quadrant near origin
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -15.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -11.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion

            #region (-, +) quadrant near origin
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 11.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 15.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (-, -) quadrant near origin
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -15.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -11.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion
            #endregion

            #region Explosion around 2048
            #region (+, +) quadrant around 2048
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , 2048.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2050.5, 0.0, 2052.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5, 0.0, 2052.5) , new Vector3D(0.0, 0.07139173716009803, 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2048.5, 0.0, 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5, 0.0, 2050.5) , new Vector3D(-0.7465802392691454, 0.07139173716009803, 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2048.5, 0.0, 2052.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5, 0.0, 2052.5) , new Vector3D(-0.45605834910419196, 0.04361058072041619, 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2052.5, 0.0, 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5, 0.0, 2050.5) , new Vector3D(0.7465802392691454, 0.07139173716009803, 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2052.5, 0.0, 2052.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5, 0.0, 2052.5) , new Vector3D(0.45605834910419196, 0.04361058072041619, 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2052.5, 0.0, 2048.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5, 0.0, 2048.5) , new Vector3D(0.45605834910419196, 0.04361058072041619, -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5, -0.04, 2050.5)) ,

                new EnderPearlEntity(new Vector3D(2048.5, 0.0, 2048.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5, 0.0, 2048.5) , new Vector3D(-0.45605834910419196, 0.04361058072041619, -0.45605834910419196))
            } ,
            #endregion

            #region (+, -) quadrant around 2048
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2047.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2045.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2043.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2047.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2045.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2043.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2047.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2043.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (-, +) quadrant around 2048
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2052.5 , 0.0 , 2050.5) , new Vector3D(0.0                 , -0.029999999329447746 , 0.0)) ,
                new EnderPearlEntity(new Vector3D(-2052.5 , 0.0 , 2050.5) , new Vector3D(-0.7465802392691454 , 0.04139173783065028   , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2048.5 , 0.0 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2048.5 , 0.0 , 2050.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2050.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(-2050.5 , 0.0 , 2048.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2048.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(-2048.5 , 0.0 , 2048.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2050.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(-2050.5 , 0.0 , 2052.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2048.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(-2048.5 , 0.0 , 2052.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2052.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(-2052.5 , 0.0 , 2052.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2052.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(-2052.5 , 0.0 , 2048.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            #endregion

            #region (-, -) quadrant around 2048
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2043.5) , new Vector3D(0.0                  , -0.029999999329447746 , 0.0                )) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2043.5) , new Vector3D(-0.45605834910419196 , 0.013610581390968442  , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2043.5) , new Vector3D(0.0 , -0.029999999329447746 , 0.0               )) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2043.5) , new Vector3D(0.0 , 0.04139173783065028   , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2047.5) , new Vector3D(0.0                  , -0.029999999329447746 , 0.0                 )) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2047.5) , new Vector3D(-0.45605834910419196 , 0.013610581390968442  , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2047.5) , new Vector3D(0.0 , -0.029999999329447746 , 0.0                )) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2047.5) , new Vector3D(0.0 , 0.04139173783065028   , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2045.5) , new Vector3D(0.0                 , -0.029999999329447746 , 0.0)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2045.5) , new Vector3D(-0.7465802392691454 , 0.04139173783065028   , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2043.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2047.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2045.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            #endregion
            #endregion

            #region Explosion around world border (+/-29999968, +/-29999968)
            #region (+, +) quadrant around world border (+29999968, +29999968)
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999705E7) , new Vector3D(0.0                 , -0.029999999329447746 , 0.0)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.04139173783065028   , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999685E7) , new Vector3D(0.0                  , -0.029999999329447746 , 0.0                 )) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.013610581390968442  , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999685E7) , new Vector3D(0.0 , -0.029999999329447746 , 0.0                )) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999685E7) , new Vector3D(0.0 , 0.04139173783065028   , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999725E7) , new Vector3D(0.0                  , -0.029999999329447746 , 0.0                )) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.013610581390968442  , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999725E7) , new Vector3D(0.0 , -0.029999999329447746 , 0.0               )) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999725E7) , new Vector3D(0.0 , 0.04139173783065028   , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            #endregion

            #region (+, -) quadrant around world border (+29999968, -29999968)
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999725E7) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999685E7) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,

                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion

            #region (-, +) quadrant around world border (-29999968, +29999968)
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , 2.99999685E7) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , 2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , 2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , 2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , 2.99999725E7) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (-, -) quadrant around world border (-29999968, -29999968)
            {
                new TntEntity(new Vector3D(-2.99999705E7 ,        -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 ,   -2.99999705E7) , new Vector3D(0.0                 , -0.029999999329447746 , 0.0)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 ,   -2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.04139173783065028   , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999725E7) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999685E7) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            #endregion
            #endregion
            #endregion
        };
#elif VERSION_1_20_2_ABOVE
        return new TheoryData<TntEntity , Entity , Entity>
        {
            #region TNT accelerate TNT
            #region Explosion near origin
            #region (+, +) quadrant near origin
            #region Test compuate accuracy when acclerate towards east
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.5087943506677117)) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.49000000953674316) , new Vector3D(0.0               , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.49000000953674316) , new Vector3D(0.749487295829994 , -0.022953048881522803 , -0.007043059955578028))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , 0.49000000953674316) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , 0.49000000953674316) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.5099999904632568) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                , 0.0                   , 0.0                 )) ,
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , 0.5099999904632568) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , 0.007395950147942588))
            } ,
            #endregion

            #region Test compuate accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.509999990463257) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.509999990463257) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 2.509999990463257) , new Vector3D(0.0                  , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 2.509999990463257) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.5094340547869702) , new Vector3D(0.0                    ,  0.0                  , 2.7732020880979567E-13)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.5094340547869702) , new Vector3D(-0.0073987206148278545 , -0.022658603932837036 , 0.7470621274981442    ))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.490000009536743) , new Vector3D(0 , 0                    , 0                 )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.490000009536743) , new Vector3D(0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when acclerate towards west
            {
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.49000000953674316) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.49000000953674316) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))

            } ,
            {
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            #endregion

            #region Test compuate accuracy when acclerate towards north
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.50841051099345)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.007502748770603866 , -0.02297719046992943 , -0.7496793187533988))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.490000009536743)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 2.490000009536743)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.49000000953674316) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , 0.49000000953674316) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 2.490000009536743)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            #endregion
            #endregion

            #region (-, +) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.5099999904632568) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.49000000953674316) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.49000000953674316) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.49000000953674316) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.49000000953674316) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.490000009536743) , new Vector3D(0.0                   , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.490000009536743) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 2.490000009536743) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 2.490000009536743) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.509999990463257) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.509999990463257) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.509999990463257) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.509999990463257) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , 0.49000000953674316) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , 0.49000000953674316) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568)) ,
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , 0.5099999904632568) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , 0.5099999904632568) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , 0.49000000953674316) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , 0.49000000953674316) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.509999990463257)) ,
                new TntEntity(new Vector3D(-0.4925038021446304 , -37.0 , 0.49000000953674316) , new Vector3D(1.0369848147211355E-13 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-0.4925038021446304 , -37.0 , 0.49000000953674316) , new Vector3D(0.006470152491941777   , -0.02265046766878977 , -0.7470031570356701))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 ,  -37.0 , 2.490000009536743)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 2.490000009536743)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , 2.490000009536743)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , 0.5099999904632568) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            #endregion
            #endregion

            #region (+, -) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , -0.5099999904632568) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(0.0               , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.5099999904632568) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.5099999904632568) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -2.490000009536743)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -2.509999990463257)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.49000000953674316) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.49000000953674316) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -2.490000009536743)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -2.509999990463257)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(2.509999990463257 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5075517662484836) , new Vector3D(0.0                 , 0.0                   , -7.166448929862033E-14)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5075517662484836) , new Vector3D(-0.7470398804211061 , -0.022651581187315997 , 9.054065058280807E-4  ))
            } ,
            {
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2.490000009536743 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.49043053384987395 , -37.0 , -0.49000000953674316) , new Vector3D(-6.229702363838245E-14 , 0.0                   , 0.0                 )) ,
                new TntEntity(new Vector3D(0.49043053384987395 , -37.0 , -0.49000000953674316) , new Vector3D(-0.7495350507678448    , -0.022959453678033342 , 0.007496957170722802))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -2.509999990463257) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -2.509999990463257) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -2.490000009536743) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -2.490000009536743) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.4969699204373668)) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -2.490000009536743) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -2.490000009536743) , new Vector3D(0.0 , -0.023061348069705993 , -0.7503993420991371))
            } ,
            {
                new TntEntity(new Vector3D(0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -2.490000009536743) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(0.49000000953674316 , -37.0 , -2.490000009536743) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            #endregion
            #endregion

            #region (-, -) quadrant near origin
            #region Test compute accuracy when accelerate towards east
            {
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-0.49604033173159656 , -37.0 , -0.49000000953674316) , new Vector3D(3.7125035701427584E-11 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-0.49604033173159656 , -37.0 , -0.49000000953674316) , new Vector3D(0.7477928963421641     , -0.022742419686284755 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards south
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -2.490000009536743)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.5012737763615767)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                   , 0.0                   , 0.0            )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(-0.007538561231844622 , -0.023086866239208796 , 0.7505676840152))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.490000009536743)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.49000000953674316) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.49000000953674316) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -2.509999990463257)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards west
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , -0.49000000953674316) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.509999990463257 , -37.0 , -0.49000000953674316) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.49000000953674316) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.5099999904632568) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.490000009536743 , -37.0 , -0.5099999904632568) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            #endregion

            #region Test compute accuracy when accelerate towards north
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -2.490000009536743) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -2.490000009536743) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.509999990463257) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.509999990463257) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.49000000953674316)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.490000009536743) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.490000009536743) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-0.5099999904632568 , -37.0 , -0.5099999904632568)) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.509999990463257) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-0.49000000953674316 , -37.0 , -2.509999990463257) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            #endregion
            #endregion
            #endregion

            #region Explosion around 2048
            #region (+, +) quadrant around 2048
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.0               , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -17.0 , 2048.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -17.0 , 2048.4900000095367) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -17.0 , 2048.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -17.0 , 2048.4900000095367) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2048.5098799769366 , -17.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633) , new Vector3D(4.5582220247244974E-5 , -0.02326330309011309 , -0.7520218720923475))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(2050.4900000095367 , -17.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , 0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.4900000095367) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2050.4900000095367 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.4900000095367) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2048.5099999904633) , new Vector3D(-0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.4900000095367) , new Vector3D(0.0                   , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.4900000095367) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(2048.5094000870004 , -17.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.4900000095367) , new Vector3D(0.0                    , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.4900000095367) , new Vector3D(-0.0073678548761800244 , -0.023261820515694923 , 0.7519739456055048))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2050.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2050.5099999904633) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -17.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.5099999904633) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -17.0 , 2050.5099999904633) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            #endregion
            #endregion

            #region (+, -) quadrant around 2048
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0               , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2050.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -12.0 , -2047.4959239863165) , new Vector3D(0.0               , 0.0                   , 4.3259131169990364E-14)) ,
                new TntEntity(new Vector3D(2050.5099999904633 , -12.0 , -2047.4959239863165) , new Vector3D(0.749527003781537 , -0.022954264937562478 , -0.0022200902830519895))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2045.4900000095367) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2045.4900000095367) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2045.4900000095367) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2045.4900000095367) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(2048.509725949973 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2045.5099999904633) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2045.5099999904633) , new Vector3D(1.0408304969478038E-4 , -0.023263302850996377 , 0.7520218643625337))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.506909403479 , -12.0 , -2045.4900000095367) , new Vector3D(1.4560145806777192E-13 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2048.506909403479 , -12.0 , -2045.4900000095367) , new Vector3D(-0.0011582441277438198 , -0.02295436257645224 , 0.7495301919901203))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(2050.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2050.4900000095367 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.506312826875 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(-0.7499905482942234 , -0.023010883434308183 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5099999904633 , -12.0 , -2047.5077528464317)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(-0.7470399959542674 , -0.022651584690487447 , -8.310428139131224E-4))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(2048.491662388179 , -12.0 , -2047.4900000095367) , new Vector3D(-1.6813143193131072E-13 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.491662388179 , -12.0 , -2047.4900000095367) , new Vector3D(6.230021955968205E-4    , -0.022954388526051847 , -0.7495310393239684))
            } ,
            {
                new TntEntity(new Vector3D(2048.5099999904633 , -12.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2048.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            #endregion
            #endregion

            #region (-, +) quadrant around 2048
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.4940151276019 , -12.0 , 2048.4900000095367) , new Vector3D(5.935103494968917E-14 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.4940151276019 , -12.0 , 2048.4900000095367) , new Vector3D(0.7475406732001194    , -0.022711910177566526 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , 2048.4900000095367) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , 2048.4900000095367) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.4900000095367) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.4900000095367) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.4900000095367) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.4900000095367) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.4900000095367) , new Vector3D(0.0                  , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.4900000095367) , new Vector3D(0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2050.5099999904633) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2050.5099999904633) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , 2048.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.4900000095367) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.4900000095367) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , 2048.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4930349468948 , -12.0 , 2048.5099999904633) , new Vector3D(3.1188994253955786E-13 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4930349468948 , -12.0 , 2048.5099999904633) , new Vector3D(-0.7491534351005368    , -0.02290806212971471 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2050.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.4924097020503) , new Vector3D(0.0 , 0.0                   , -1.0500021296051667E-13)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.4924097020503) , new Vector3D(0.0 , -0.022991290043745838 , -0.749831465373622     ))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.4900000095367) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.4900000095367) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , -0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2048.5099999904633) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , 2050.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , 2048.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            #endregion
            #endregion

            #region (-, -) quadrant around 2048
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.0               , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.5099999904633) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2045.4900000095367 , -12.0 , -2047.5099999904633) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.5099999904633) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.5099999904633) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.4900000095367) , new Vector3D(0.0                   , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.4900000095367) , new Vector3D(-0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.4900000095367) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2045.4900000095367) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5099999904633 , -12.0 , -2047.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2045.5099999904633)) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2047.4900000095367) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-2047.4900000095367 , -12.0 , -2045.4900000095367)) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2047.5099999904633 , -12.0 , -2047.4900000095367) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            #endregion
            #endregion
            #endregion

            #region Explosion around world border (+/-29999968, +/-29999968)
            #region (+, +) quadrant around world border (+29999968, +29999968)
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.9999968502361342E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.7470219162215107 , -0.02265103648075311 , -0.004571379496632982))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.9999968504289474E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                   )) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.7495058975160105 , -0.02295361855816815 , -0.0053550190705545534))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997049000001E7) , new Vector3D(0.0                   , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997049000001E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996850986763E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0                  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850986763E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.007445213458696276 , -0.022952890278447644 , -0.7494821169541711))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997050999999E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997050999999E7) , new Vector3D(0.0 , -0.022651603426827455 , 0.7470406138710955))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 8.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996849000001E7) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 ,  8.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.9999968506363004E7 , 8.0 , 2.999996850999999E7) , new Vector3D(1.9546234703465E-13  , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.9999968506363004E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.006214531334730427 , -0.023262248369492578 , -0.7519877766342563))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 8.0 , 2.999996850999999E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            #endregion
            #endregion

            #region (+, -) quadrant around world border (+29999968, -29999968)
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999997050999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0 , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0 , -0.02295439909021501 , 0.7495313842762282))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996850999999E7) , new Vector3D(-0.751970935856197 , -0.02326172741107527 , -0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(2.999997050999999E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.999997049000001E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999997050999999E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999997050999999E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(2.999996849000001E7 , 11.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7) , new Vector3D(0.0                  , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(2.999996850999999E7 , 11.0 , -2.999997049000001E7) , new Vector3D(0.0 , -0.023263303146856814 , -0.7520218739266752))
            } ,
            #endregion
            #endregion

            #region (-, +) quadrant around world border (-29999968, +29999968)
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 12.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.0               , 0.0                  , 0.0                 )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.751970935856197 , -0.02326172741107527 , 0.007595658701788324))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.7470406138710955 , -0.022651603426827455 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997049000001E7 , 12.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999997050999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999997050999999E7) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7) , new Vector3D(0.0 , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7) , new Vector3D(0.0 , -0.023263303146856814 , 0.7520218739266752))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7) , new Vector3D(0.0                  , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7) , new Vector3D(0.007494807436105638 , -0.02295287010936156 , 0.7494814583717813))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0                 , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 , 12.0 , 2.999996849000001E7) , new Vector3D(-0.7520218739266752 , -0.023263303146856814 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0                 , 0.0                   , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996849000001E7) , new Vector3D(-0.7469916702756442 , -0.022650119369744263 , -0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(-0.007494807436105638 , -0.02295287010936156 , -0.7494814583717813))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , -0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , 2.999996850999999E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , 2.999996849000001E7) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            #endregion
            #endregion

            #region (-, -) quadrant around world border (-29999968, -29999968)
            #region Test compute accuracy towards east
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.0                , 0.0                   , 0.0                 )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.7469916702756442 , -0.022650119369744263 , 0.007395950147942588))
            } ,
            {
                new TntEntity(new Vector3D(-2.9999970505991884E7 , 12.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 ,  12.0 , -2.999996850999999E7) , new Vector3D(0.0                , 0.0                   , 0.0)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 ,  12.0 , -2.999996850999999E7) , new Vector3D(0.7500305150432709 , -0.023015809883308702 , 0.0))
            } ,
            #endregion

            #region Test compute accuracy towards south
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999997050999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.0                  , 0.0                   , 0.0               )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.007395950147942588 , -0.022650119369744263 , 0.7469916702756442))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.9999968494448464E7) , new Vector3D(0.0                    , 0.0                   , 5.5053721979650886E-14)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.9999968494448464E7) , new Vector3D(-0.0075170645341651795 , -0.023021032538500293 , 0.7500352026052619    ))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999997049000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(0.0                   , 0.0                  , 0.0              )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(-0.007595658701788324 , -0.02326172741107527 , 0.751970935856197))
            } ,
            #endregion

            #region Test compute accuracy towards west
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996849000001E7) , new Vector3D(0.0                 , 0.0                  , 0.0)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996849000001E7) , new Vector3D(-0.7495313842762282 , -0.02295439909021501 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(0.0                 , 0.0                  , 0.0                  )) ,
                new TntEntity(new Vector3D(-2.999997050999999E7 , 12.0 , -2.999996850999999E7) , new Vector3D(-0.7494814583717813 , -0.02295287010936156 , -0.007494807436105638))
            } ,
            {
                new TntEntity(new Vector3D(-2.9999968507425006E7 , 12.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 ,  12.0 , -2.999996849000001E7) , new Vector3D(0.0                 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999997049000001E7 ,  12.0 , -2.999996849000001E7) , new Vector3D(-0.7516504351779226 , -0.023221613295678477 , 0.00758256022787477))
            } ,
            #endregion

            #region Test compute accuracy towards north
            {
                new TntEntity(new Vector3D(-2.999996850396163E7 , 12.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999997049000001E7) , new Vector3D(0.0                   , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999997049000001E7) , new Vector3D(-0.002293409567294291 , -0.023263159501215158 , -0.7520172303614885))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999996850999999E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999997050999999E7) , new Vector3D(0.0 , 0.0                  , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999997050999999E7) , new Vector3D(0.0 , -0.02295439909021501 , -0.7495313842762282))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.9999970505076475E7) , new Vector3D(0.0 , 0.0                  , -2.369103498231045E-14)) ,
                new TntEntity(new Vector3D(-2.999996849000001E7 , 12.0 , -2.9999970505076475E7) , new Vector3D(0.0 , -0.02272558751779458 , -0.7476538071786842   ))
            } ,
            {
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999996849000001E7)) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999997050999999E7) , new Vector3D(0.0 , 0.0                   , 0.0                )) ,
                new TntEntity(new Vector3D(-2.999996850999999E7 , 12.0 , -2.999997050999999E7) , new Vector3D(0.0 , -0.022651603426827455 , -0.7470406138710955))
            } ,
            #endregion
            #endregion
            #endregion
            #endregion

            #region TNT accelerate Ender Pearl
            #region Explosion near origin
            #region (+, +) quadrant near origin
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 11.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , 15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , 15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , 15.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (+, -) quadrant near origin
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -15.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(13.5 , 0.0 , -11.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(15.5 , 0.0 , -15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(11.5 , 0.0 , -11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion

            #region (-, +) quadrant near origin
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 11.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 11.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , 15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , 15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , 13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 15.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , 15.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (-, -) quadrant near origin
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -15.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(-13.5 , 0.0 , -11.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -13.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -11.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -11.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(-11.5 , 0.0 , -15.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -15.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -15.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 , -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 , -13.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-13.5 ,        -0.04 , -13.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 ,   -11.5)) ,
                new EnderPearlEntity(new Vector3D(-15.5 , 0.0 ,   -11.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion
            #endregion

            #region Explosion around 2048
            #region (+, +) quadrant around 2048
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , 2048.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , 2050.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , 2048.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , 2050.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , 2048.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , 2052.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , 2052.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , 2052.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (+, -) quadrant around 2048
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2047.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2045.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2043.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2047.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2045.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(2052.5 , 0.0 , -2043.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(2048.5 , 0.0 , -2047.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2050.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(2050.5 , 0.0 , -2043.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (-, +) quadrant around 2048
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , 2048.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , 2050.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , 2048.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , 2050.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , 2048.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , 2048.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , 2052.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , 2052.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , 2050.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , 2052.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , 2052.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (-, -) quadrant around 2048
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2047.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2045.5) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2047.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2045.5) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2047.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2047.5) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(-2045.5 , 0.0 , -2043.5) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(-2047.5 , 0.0 , -2043.5) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2045.5 , -0.04 , -2045.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2043.5)) ,
                new EnderPearlEntity(new Vector3D(-2043.5 , 0.0 , -2043.5) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion
            #endregion

            #region Explosion around world border (+/-29999968, +/-29999968)
            #region (+, +) quadrant around world border (+29999968, +29999968)
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999685E7) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , 2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , 2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , 2.99999725E7) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            #endregion

            #region (+, -) quadrant around world border (+29999968, -29999968)
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999725E7) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999705E7 , 0.0 , -2.99999685E7) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999725E7 , 0.0 , -2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(2.99999685E7 , 0.0 , -2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            #endregion

            #region (-, +) quadrant around world border (-29999968, +29999968)
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999685E7) , new Vector3D(0.0                 , 0.0                 , 0.0                 )) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999725E7) , new Vector3D(0.0                 , 0.0                 , 0.0                )) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999705E7) , new Vector3D(0.0                , 0.0                 , 0.0)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , 2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , -0.029700000286102295 , 2.99999705E7) , new Vector3D(0.0                 , -0.029700000286102295 , 0.0)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , -0.029700000286102295 , 2.99999705E7) , new Vector3D(-0.7474843373434933 , 0.03067804873803143   , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , -0.029700000286102295 , 2.99999685E7) , new Vector3D( 0.0                , -0.029700000286102295 ,  0.0               )) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , -0.029700000286102295 , 2.99999685E7) , new Vector3D(-0.4563224990099179 , 0.0071594505941039825 , -0.4563224990099179))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , -0.029700000286102295 , 2.99999685E7) , new Vector3D(0.0 , -0.029700000286102295 , 0.0                )) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , -0.029700000286102295 , 2.99999685E7) , new Vector3D(0.0 , 0.03067804873803143   , -0.7474843373434933))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , -0.029700000286102295 , 2.99999725E7) , new Vector3D(0.0                 , -0.029700000286102295 , 0.0               )) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , -0.029700000286102295 , 2.99999725E7) , new Vector3D(-0.4563224990099179 , 0.0071594505941039825 , 0.4563224990099179))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , 2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , -0.029700000286102295 , 2.99999725E7) , new Vector3D(0.0 , -0.029700000286102295 , 0.0               )) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , -0.029700000286102295 , 2.99999725E7) , new Vector3D(0.0 , 0.03067804873803143   , 0.7474843373434933))
            } ,
            #endregion

            #region (-, -) quadrant around world border (-29999968, -29999968)
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999725E7) , new Vector3D(0.0 , 0.07139173716009803 , -0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999705E7 , 0.0 , -2.99999685E7) , new Vector3D(0.0 , 0.07139173716009803 , 0.7465802392691454))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999705E7) , new Vector3D(0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999685E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999685E7 , 0.0 , -2.99999725E7) , new Vector3D(0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999725E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999725E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , -0.45605834910419196))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999705E7) , new Vector3D(-0.7465802392691454 , 0.07139173716009803 , 0.0))
            } ,
            {
                new TntEntity(new Vector3D(-2.99999705E7 , -0.04 , -2.99999705E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999685E7)) ,
                new EnderPearlEntity(new Vector3D(-2.99999725E7 , 0.0 , -2.99999685E7) , new Vector3D(-0.45605834910419196 , 0.04361058072041619 , 0.45605834910419196))
            } ,
            #endregion
            #endregion
            #endregion
        };
#else
        throw new NotSupportedException();
#endif
    }
}
