using Xunit.Abstractions;


namespace EnderOverhaul.EnderDynamics.Impl.Test;

public class VersionTest(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void TestVersion()
    {
        string version = EnderDynamicsInfo.Version;
        testOutputHelper.WriteLine(version);

#if VERSION_1_12_ABOVE
        Assert.Equal("VERSION_1_12_ABOVE" , version);
#elif VERSION_1_20_2_ABOVE
        Assert.Equal("VERSION_1_20_2_ABOVE" , version);
#else
        Assert.Equal("DUMMY_REF_ONLY" , version);
#endif
    }
}
