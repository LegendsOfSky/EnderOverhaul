using EnderOverhaul.EnderDynamics;


namespace EnderOverhaul.EnderMechanics;

public static class EnderMechanicsConfig
{
    /// <remarks> You can also change this directly with EnderDynamics. </remarks>
    public static string GetEnderDynamicsLibVersion() => EnderDynamicsConfig.LibVersion;

    /// <remarks> You can also change this directly with EnderDynamics. </remarks>
    public static string GetEnderDynamicsMinecraftVersion() => EnderDynamicsConfig.MinecraftVersion;

    /// <remarks> You can also change this directly with EnderDynamics. </remarks>
    public static bool TrySetMinecraftVersion(string minecraftVersion) => EnderDynamicsConfig.TrySetMinecraftVersion(minecraftVersion);
}
