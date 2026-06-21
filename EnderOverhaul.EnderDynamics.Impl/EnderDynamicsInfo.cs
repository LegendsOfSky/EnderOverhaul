namespace EnderOverhaul.EnderDynamics.Impl;

public static class EnderDynamicsInfo
{
    public static string Version
    {
        get
        {
#if VERSION_1_12_ABOVE
            return "VERSION_1_12_ABOVE";
#elif VERSION_1_20_2_ABOVE
            return "VERSION_1_20_2_ABOVE";
#else
            return "DUMMY_REF_ONLY";
#endif
        }
    }
}
