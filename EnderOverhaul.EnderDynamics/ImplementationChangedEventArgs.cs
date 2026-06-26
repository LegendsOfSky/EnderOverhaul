using System.Reflection;


namespace EnderOverhaul.EnderDynamics;

internal class ImplementationChangedEventArgs(Assembly oldImplementation , Assembly newImplementation) : EventArgs
{
    public Assembly OldImplementation = oldImplementation;
    public Assembly NewImplementation = newImplementation;
}
