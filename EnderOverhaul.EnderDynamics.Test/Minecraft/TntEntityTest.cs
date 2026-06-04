using Xunit.Abstractions;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;

namespace EnderOverhaul.EnderDynamics.Test.Minecraft;

public class TntEntityTest(ITestOutputHelper testOutputHelper)
{
    [Theory, MemberData(nameof(TestData_TestTntEntityTicking))]
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
                $"Position:\n"
              + $"\tactual: ({tnt.Motion.X}, {tnt.Motion.Y}, {tnt.Motion.Z})\n"
              + $"\texpect: ({expected.Motion.X}, {expected.Motion.Y}, {expected.Motion.Z})"
            );

        Assert.Equal(expected.Position , tnt.Position);
        Assert.Equal(expected.Motion ,   tnt.Motion);
    }
    public static TheoryData<TntEntity , TntEntity , int> TestData_TestTntEntityTicking()
    {
#if VERSION_1_12_ABOVE
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
        throw new NotImplementedException();
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
}
