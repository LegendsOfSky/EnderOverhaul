namespace EnderOverhaul.EnderDynamics.Test;


[Collection("Config Tests")]
public class EnderDynamicConfigTest
{
    [Fact]
    public void TrySetMinecraftVersion_InvalidVersion_ReturnsFalse()
    {
        bool result = EnderDynamicsConfig.TrySetMinecraftVersion("not.a.real.version");
        Assert.False(result);
    }

    [Fact]
    public void TrySetMinecraftVersion_Valid_1_12_SetsPropertiesAndLibrary()
    {
        bool result = EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        Assert.True(result);
        Assert.Equal("1.12.2" , EnderDynamicsConfig.MinecraftVersion);
        Assert.Equal("VERSION_1_12_ABOVE" , EnderDynamicsConfig.LibVersion);
        Assert.NotNull(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    [Fact]
    public void TrySetMinecraftVersion_Valid_1_20_SetsPropertiesAndLibrary()
    {
        bool result = EnderDynamicsConfig.TrySetMinecraftVersion("1.20.2");
        Assert.True(result);
        Assert.Equal("1.20.2" , EnderDynamicsConfig.MinecraftVersion);
        Assert.Equal("VERSION_1_20_2_ABOVE" , EnderDynamicsConfig.LibVersion);
        Assert.NotNull(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    [Fact]
    public void TrySetMinecraftVersion_ChangesVersion_UpdatesState()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
        string firstLib = EnderDynamicsConfig.LibVersion;

        bool changed = EnderDynamicsConfig.TrySetMinecraftVersion("1.21.1");
        Assert.True(changed);
        Assert.Equal("1.21.1" , EnderDynamicsConfig.MinecraftVersion);
        Assert.Equal("VERSION_1_20_2_ABOVE" , EnderDynamicsConfig.LibVersion);
        Assert.NotEqual(firstLib , EnderDynamicsConfig.LibVersion);
    }

    [Fact]
    public void TrySetMinecraftVersion_FiresOnImplementationChangedEvent()
    {
        // Ensure a starting state
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");

        ImplementationChangedEventArgs? received = null;
        EventHandler<ImplementationChangedEventArgs> handler = (_ , e) => received = e;

        EnderDynamicsConfig.OnImplementationChangedEvent += handler;

        try
        {
            bool ok = EnderDynamicsConfig.TrySetMinecraftVersion("1.20.4");
            Assert.True(ok);
            Assert.NotNull(received);
            Assert.NotNull(received!.OldImplementation);
            Assert.NotNull(received.NewImplementation);
            Assert.NotSame(received.OldImplementation , received.NewImplementation);
        }
        finally
        {
            EnderDynamicsConfig.OnImplementationChangedEvent -= handler;
        }
    }

    [Fact]
    public void GetImplementationVersion_AfterTrySet_ReturnsExpected()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.19.4");
        string version = EnderDynamicsInfo.GetImplementationVersion();
        Assert.Equal("VERSION_1_12_ABOVE" , version);

        EnderDynamicsConfig.TrySetMinecraftVersion("1.21.3");
        version = EnderDynamicsInfo.GetImplementationVersion();
        Assert.Equal("VERSION_1_20_2_ABOVE" , version);
    }

    [Fact]
    public void TrySetMinecraftVersion_SameVersionMultipleTimes_Succeeds()
    {
        Assert.True(EnderDynamicsConfig.TrySetMinecraftVersion("1.16.5"));
        Assert.True(EnderDynamicsConfig.TrySetMinecraftVersion("1.16.5"));
        Assert.Equal("1.16.5" , EnderDynamicsConfig.MinecraftVersion);
    }
}
