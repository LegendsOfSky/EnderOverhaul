using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EnderOverhaul.EnderDynamics;

public static class EnderDynamicsInfo
{
    public static string GetImplementationVersion()
    {
        Type enderDynamicsInfoT = EnderDynamicsConfig.ImplementationLibrary.GetType(typeof(Impl.EnderDynamicsInfo).ToString())
            ?? throw new TypeLoadException("Cannot load type EnderDynamicsInfo inside implementation assembly.");
        MemberAccessException exception = new("Cannot access versions inside EnderDynamicsInfo.");
        PropertyInfo? versionProperty = enderDynamicsInfoT.GetProperty(nameof(Impl.EnderDynamicsInfo.Version));
        return (string?)(versionProperty ?? throw exception).GetValue(null) ?? throw exception;
    }
}
