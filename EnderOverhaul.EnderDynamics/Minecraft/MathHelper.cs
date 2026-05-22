using System;
using System.Collections.Generic;
using System.Text;

namespace EnderOverhaul.EnderDynamics.Minecraft;

/// <summary>
/// The same math function that is used in Minecraft java edition.
/// </summary>
internal static class MathHelper
{
    public static float Sqrt(double value) => (float)Math.Sqrt(value);

    public static double DegreeToRadiant(double degree) => degree * Math.PI / 180;

    public static double RadiantToDegree(double radiant) => radiant * 180 / Math.PI;

    public static bool IsInside(double border1 , double border2 , double num)
        => num <= Math.Max(border1 , border2) && num >= Math.Min(border1 , border2);
}
