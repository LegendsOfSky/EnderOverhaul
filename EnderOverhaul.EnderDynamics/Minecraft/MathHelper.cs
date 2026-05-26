using System;
using System.Collections.Generic;
using System.Text;

namespace EnderOverhaul.EnderDynamics.Minecraft;

/// <summary>
/// The same math function that is used in Minecraft java edition with some additional helper function.
/// </summary>
internal static class MathHelper
{
    /// <remarks> Obtained from minecraft. </remarks>
    public static float Sqrt(double value) => (float)Math.Sqrt(value);

    /// <remarks> Custom helper function that does not exist in minecraft. </remarks>
    public static double DegreeToRadiant(double degree) => degree * Math.PI / 180;

    /// <remarks> Custom helper function that does not exist in minecraft. </remarks>
    public static double RadiantToDegree(double radiant) => radiant * 180 / Math.PI;

    /// <remarks> Custom helper function that does not exist in minecraft. </remarks>
    public static bool IsInside(double border1 , double border2 , double num)
        => num <= Math.Max(border1 , border2) && num >= Math.Min(border1 , border2);
}
