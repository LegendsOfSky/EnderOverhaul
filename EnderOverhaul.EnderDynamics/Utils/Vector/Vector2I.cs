using System.Numerics;
using System.Reflection;
using Vector2IImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector2I;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;

public class Vector2I : IVector<Vector2I , int> ,
                        IAdditionOperators<Vector2I , Vector2I , Vector2I> ,
                        ISubtractionOperators<Vector2I , Vector2I , Vector2I> ,
                        IMultiplyOperators<Vector2I , int , Vector2I> ,
                        IUnaryNegationOperators<Vector2I , Vector2I> ,
                        IEquatable<Vector2I> ,
                        IEqualityOperators<Vector2I , Vector2I , bool>
{
    public int X
    {
        get => (int)(s_FieldInfoX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => s_FieldInfoX.SetValue(ImplObj , value);
    }
    public int Z
    {
        get => (int)(s_FieldInfoZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => s_FieldInfoZ.SetValue(ImplObj , value);
    }

    internal object ImplObj;

    private static Type s_ImplType;
    private static FieldInfo s_FieldInfoX;
    private static FieldInfo s_FieldInfoZ;
    private static MethodInfo s_OperatorAdditionMethod;
    private static MethodInfo s_OperatorSubtractionMethod;
    private static MethodInfo s_OperatorMultiplicationMethod;
    private static MethodInfo s_OperatorUnaryNegationMethod;
    private static MethodInfo s_OperatorEqualityMethod;
    private static MethodInfo s_OperatorInequalityMethod;

    /* IVector members (delegated to Impl) */
    private static PropertyInfo s_LengthProperty;
    private static PropertyInfo s_MaxEntryProperty;
    private static PropertyInfo s_MinEntryProperty;
    private static MethodInfo s_GetDominantEntryMethod;
    private static MethodInfo s_ComputeDotProductWithMethod;
    private static MethodInfo s_IsNorthMethod;
    private static MethodInfo s_IsSouthMethod;
    private static MethodInfo s_IsWestMethod;
    private static MethodInfo s_IsEastMethod;
    private static MethodInfo s_ToCardinalCompassDirectionMethod;
    private static MethodInfo s_ToHorizontalWorldAngleMethod;
    private static MethodInfo s_ToVerticalWorldAngleMethod;


    static Vector2I()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    public Vector2I(int x , int z)
    {
        ImplObj = Activator.CreateInstance(s_ImplType , x , z) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    internal Vector2I(object implObj)
    {
        ImplObj = implObj;
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }


    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(Vector2IImpl).ToString())
            ?? throw new TypeLoadException();
        s_FieldInfoX = s_ImplType.GetField("X") ?? throw new TypeLoadException();
        s_FieldInfoZ = s_ImplType.GetField("Z") ?? throw new TypeLoadException();
        s_OperatorAdditionMethod       = s_ImplType.GetMethod("op_Addition"      , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorSubtractionMethod    = s_ImplType.GetMethod("op_Subtraction"   , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorMultiplicationMethod = s_ImplType.GetMethod("op_Multiply"      , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorUnaryNegationMethod  = s_ImplType.GetMethod("op_UnaryNegation" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorEqualityMethod       = s_ImplType.GetMethod("op_Equality"      , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorInequalityMethod     = s_ImplType.GetMethod("op_Inequality"    , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_LengthProperty   = s_ImplType.GetProperty("Length"  ) ?? throw new TypeLoadException();
        s_MaxEntryProperty = s_ImplType.GetProperty("MaxEntry") ?? throw new TypeLoadException();
        s_MinEntryProperty = s_ImplType.GetProperty("MinEntry") ?? throw new TypeLoadException();
        s_GetDominantEntryMethod = s_ImplType.GetMethod("GetDominantEntry", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsNorthMethod = s_ImplType.GetMethod("IsNorth" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsSouthMethod = s_ImplType.GetMethod("IsSouth" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsWestMethod  = s_ImplType.GetMethod("IsWest"  , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsEastMethod  = s_ImplType.GetMethod("IsEast"  , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ComputeDotProductWithMethod = s_ImplType.GetMethod("ComputeDotProductWith" , BindingFlags.Public | BindingFlags.Instance , null , [s_ImplType] , null)
            ?? throw new TypeLoadException();
        s_ToCardinalCompassDirectionMethod = s_ImplType.GetMethod("ToCardinalCompassDirection", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToHorizontalWorldAngleMethod = s_ImplType.GetMethod("ToHorizontalWorldAngle" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToVerticalWorldAngleMethod   = s_ImplType.GetMethod("ToVerticalWorldAngle"   , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplyType = args.NewImplementation.GetType(typeof(Vector2IImpl).ToString())
            ?? throw new TypeLoadException();
        FieldInfo curFieldX = currentImplType.GetField("X") ?? throw new TypeLoadException();
        FieldInfo curFieldZ = currentImplType.GetField("Z") ?? throw new TypeLoadException();
        int curX = (int)(curFieldX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        int curZ = (int)(curFieldZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        ImplObj = Activator.CreateInstance(newImplyType , curX , curZ) ?? throw new InvalidOperationException();
    }


    #region Implements IVector<Vector2I , int>
    public double Length => (double)(s_LengthProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public int MaxEntry => (int)(s_MaxEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public int MinEntry => (int)(s_MinEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());

    public int GetDominantEntry()
        => (int)(s_GetDominantEntryMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public int ComputeDotProductWith(Vector2I other)
        => (int)(s_ComputeDotProductWithMethod.Invoke(ImplObj , [other.ImplObj]) ?? throw new InvalidOperationException());

    public bool IsNorth() => (bool)(s_IsNorthMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    public bool IsSouth() => (bool)(s_IsSouthMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    public bool IsWest()  => (bool)(s_IsWestMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    public bool IsEast()  => (bool)(s_IsEastMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public CompassDirections ToCardinalCompassDirection()
        => (CompassDirections)(s_ToCardinalCompassDirectionMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ToHorizontalWorldAngle()
        => (double)(s_ToHorizontalWorldAngleMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ToVerticalWorldAngle()
        => (double)(s_ToVerticalWorldAngleMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    #endregion

    #region Implementations for other interfaces
    public static Vector2I operator +(Vector2I left , Vector2I right)
        => new Vector2I(s_OperatorAdditionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector2I operator -(Vector2I left , Vector2I right)
        => new Vector2I(s_OperatorSubtractionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector2I operator *(Vector2I left , int right)
        => new Vector2I(s_OperatorMultiplicationMethod.Invoke(null , [left.ImplObj , right]) ?? throw new InvalidOperationException());

    public static Vector2I operator -(Vector2I value)
        => new Vector2I(s_OperatorUnaryNegationMethod.Invoke(null , [value.ImplObj]) ?? throw new InvalidOperationException());

    public static bool operator ==(Vector2I? left , Vector2I? right)
    {
        if (left is null || right is null)
            return ReferenceEquals(left, right);
        return (bool)(s_OperatorEqualityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public static bool operator !=(Vector2I? left , Vector2I? right)
    {
        if (left is null || right is null)
            return !ReferenceEquals(left, right);
        return (bool)(s_OperatorInequalityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public bool Equals(Vector2I? other)
        => other is not null
            && (bool)(s_OperatorEqualityMethod.Invoke(null , [ImplObj , other.ImplObj]) ?? throw new InvalidOperationException());

    public override bool Equals(object? obj) => obj is Vector2I other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Z);
    #endregion


    ~Vector2I()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
