using System.Reflection;
using MathHelperImpl = EnderOverhaul.EnderDynamics.Impl.Minecraft.MathHelper;


namespace EnderOverhaul.EnderDynamics.Minecraft;

/// <summary>
/// Minecraft math helpers (and a few additional utilities), available in a version-independent way.
/// </summary>
public static class MathHelper
{
    private static MethodInfo s_SqrtMethod = null!;
    private static MethodInfo s_DegreeToRadiantMethod = null!;
    private static MethodInfo s_RadiantToDegreeMethod = null!;
    private static MethodInfo s_IsInsideMethod = null!;

    static MathHelper()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += OnImplementationChanged;
        UpdateMethodInfos(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    private static void OnImplementationChanged(object? sender, ImplementationChangedEventArgs args)
    {
        UpdateMethodInfos(args.NewImplementation);
    }

    private static void UpdateMethodInfos(Assembly assembly)
    {
        Type t = assembly.GetType(typeof(MathHelperImpl).ToString())
            ?? throw new TypeLoadException("Cannot load MathHelper implementation type.");

        s_SqrtMethod = t.GetMethod(nameof(Sqrt) , BindingFlags.Public | BindingFlags.Static)
            ?? throw new TypeLoadException();
        s_DegreeToRadiantMethod = t.GetMethod(nameof(DegreeToRadiant) , BindingFlags.Public | BindingFlags.Static)
            ?? throw new TypeLoadException();
        s_RadiantToDegreeMethod = t.GetMethod(nameof(RadiantToDegree) , BindingFlags.Public | BindingFlags.Static)
            ?? throw new TypeLoadException();
        s_IsInsideMethod = t.GetMethod(nameof(IsInside) , BindingFlags.Public | BindingFlags.Static)
            ?? throw new TypeLoadException();
    }

    /* the following methods mirrors the original methods instead of reflection to save overheads */

    /// <remarks> Obtained from minecraft. </remarks>
    public static float Sqrt(double value)
        => (float)(s_SqrtMethod.Invoke(null , [value]) ?? throw new InvalidOperationException());

    /// <remarks> Custom helper function that does not exist in minecraft. </remarks>
    public static double DegreeToRadiant(double degree) => degree * Math.PI / 180;

    /// <remarks> Custom helper function that does not exist in minecraft. </remarks>
    public static double RadiantToDegree(double radiant) => radiant * 180 / Math.PI;

    /// <remarks> Custom helper function that does not exist in minecraft. </remarks>
    public static bool IsInside(double border1 , double border2 , double num)
        => num <= Math.Max(border1 , border2) && num >= Math.Min(border1 , border2);
}
