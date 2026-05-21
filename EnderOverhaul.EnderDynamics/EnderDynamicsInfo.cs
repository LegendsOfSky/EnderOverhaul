namespace EnderOverhaul.EnderDynamics;

public static class EnderDynamicsInfo
{
    public static string Version
    {
        get
        {
#if VERSION_1_12_ABOVE
            return "VERSION_1_12_ABOVE";
#else
            return "Latest";
#endif
        }
    }
}
