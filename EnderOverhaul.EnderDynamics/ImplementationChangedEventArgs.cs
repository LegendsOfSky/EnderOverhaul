using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EnderOverhaul.EnderDynamics;

internal class ImplementationChangedEventArgs(Assembly oldImplementation , Assembly newImplementation) : EventArgs
{
    public Assembly OldImplementation = oldImplementation;
    public Assembly NewImplementation = newImplementation;
}
