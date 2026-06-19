namespace EnderOverhaul.EnderDynamics.Test;

public class VersionTest
{
    [Fact]
    public void TestVersion()
    {
#if VERSION_1_12_ABOVE
        Assert.Equal("VERSION_1_12_ABOVE" , EnderDynamicsInfo.Version);
#elif VERSION_1_20_2_ABOVE
        Assert.Equal("VERSION_1_20_2_ABOVE" , EnderDynamicsInfo.Version);
#else
        Assert.Equal("Latest" , EnderDynamicsInfo.Version);
#endif
    }
}
