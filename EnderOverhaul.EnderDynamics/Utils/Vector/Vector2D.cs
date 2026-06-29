using System.Numerics;
using System.Reflection;
using Vector2DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector2D;
using Vector2IImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector2I;
using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;
using Vector3IImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3I;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;

public class Vector2D : IVector<Vector2D , double> ,
                        IAdditionOperators<Vector2D , Vector2D , Vector2D> ,
                        ISubtractionOperators<Vector2D , Vector2D , Vector2D> ,
                        IMultiplyOperators<Vector2D , double , Vector2D> ,
                        IUnaryNegationOperators<Vector2D , Vector2D> ,
                        IEquatable<Vector2D> ,
                        IEqualityOperators<Vector2D , Vector2D , bool>
{
    public double X
    {
        get => (double)(s_FieldInfoX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => s_FieldInfoX.SetValue(ImplObj , value);
    }
    public double Z
    {
        get => (double)(s_FieldInfoZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
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
    private static MethodInfo s_ExplicitCastToVector2I;
    private static MethodInfo s_ImplicitCastToVector3D;
    private static MethodInfo s_ExplicitCastToVector3I;

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


    static Vector2D()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    public Vector2D()
    {
        ImplObj = Activator.CreateInstance(s_ImplType) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    public Vector2D(double x , double z)
    {
        ImplObj = Activator.CreateInstance(s_ImplType , x , z) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    internal Vector2D(object implObj)
    {
        ImplObj = implObj;
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }


    public static explicit operator Vector2I(Vector2D vec) => new Vector2I(s_ExplicitCastToVector2I.Invoke(null , [vec.ImplObj]) ?? throw new InvalidCastException());
    public static implicit operator Vector3D(Vector2D vec) => new Vector3D(s_ImplicitCastToVector3D.Invoke(null , [vec.ImplObj]) ?? throw new InvalidCastException());
    public static explicit operator Vector3I(Vector2D vec) => new Vector3I(s_ExplicitCastToVector3I.Invoke(null , [vec.ImplObj]) ?? throw new InvalidCastException());

    public override string ToString() => $"({X}, {Z})";

    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(Vector2DImpl).ToString())
            ?? throw new TypeLoadException();

        s_LengthProperty = s_ImplType.GetProperty("Length") ?? throw new TypeLoadException();
        s_MaxEntryProperty = s_ImplType.GetProperty("MaxEntry") ?? throw new TypeLoadException();
        s_MinEntryProperty = s_ImplType.GetProperty("MinEntry") ?? throw new TypeLoadException();

        s_FieldInfoX = s_ImplType.GetField("X") ?? throw new TypeLoadException();
        s_FieldInfoZ = s_ImplType.GetField("Z") ?? throw new TypeLoadException();

        s_OperatorAdditionMethod       = s_ImplType.GetMethod("op_Addition"      , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorSubtractionMethod    = s_ImplType.GetMethod("op_Subtraction"   , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorMultiplicationMethod = s_ImplType.GetMethod("op_Multiply"      , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorUnaryNegationMethod  = s_ImplType.GetMethod("op_UnaryNegation" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorEqualityMethod       = s_ImplType.GetMethod("op_Equality"      , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_OperatorInequalityMethod     = s_ImplType.GetMethod("op_Inequality"    , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        s_ExplicitCastToVector2I = s_ImplType.GetMethod(
                "op_Explicit" , BindingFlags.Public | BindingFlags.Static ,
                null , [newAssembly.GetType(typeof(Vector2IImpl).ToString()) ?? throw new TypeLoadException()] , null
            ) ?? throw new TypeLoadException();
        s_ImplicitCastToVector3D = s_ImplType.GetMethod(
                "op_Implicit" , BindingFlags.Public | BindingFlags.Static ,
                null , [newAssembly.GetType(typeof(Vector3DImpl).ToString()) ?? throw new TypeLoadException()] , null
            ) ?? throw new TypeLoadException();
        s_ExplicitCastToVector3I = s_ImplType.GetMethod(
                "op_Explicit" , BindingFlags.Public | BindingFlags.Static ,
                null , [newAssembly.GetType(typeof(Vector3IImpl).ToString()) ?? throw new TypeLoadException()] , null
            ) ?? throw new TypeLoadException();

        s_GetDominantEntryMethod = s_ImplType.GetMethod("GetDominantEntry" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsNorthMethod = s_ImplType.GetMethod("IsNorth" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsSouthMethod = s_ImplType.GetMethod("IsSouth" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsWestMethod  = s_ImplType.GetMethod("IsWest"  , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsEastMethod  = s_ImplType.GetMethod("IsEast"  , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ComputeDotProductWithMethod = s_ImplType.GetMethod("ComputeDotProductWith" , BindingFlags.Public | BindingFlags.Instance , null , [s_ImplType] , null)
            ?? throw new TypeLoadException();
        s_ToCardinalCompassDirectionMethod = s_ImplType.GetMethod("ToCardinalCompassDirection" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToHorizontalWorldAngleMethod = s_ImplType.GetMethod("ToHorizontalWorldAngle" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToVerticalWorldAngleMethod   = s_ImplType.GetMethod("ToVerticalWorldAngle"   , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplType = args.NewImplementation.GetType(typeof(Vector2DImpl).ToString())
            ?? throw new TypeLoadException();
        FieldInfo curFieldX = currentImplType.GetField("X") ?? throw new TypeLoadException();
        FieldInfo curFieldZ = currentImplType.GetField("Z") ?? throw new TypeLoadException();
        double curX = (double)(curFieldX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        double curZ = (double)(curFieldZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        ImplObj = Activator.CreateInstance(newImplType , curX , curZ) ?? throw new InvalidOperationException();
    }


    #region Implements IVector<Vector2D , double>
    public double Length => (double)(s_LengthProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public double MaxEntry => (double)(s_MaxEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public double MinEntry => (double)(s_MinEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());

    public double GetDominantEntry()
        => (double)(s_GetDominantEntryMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ComputeDotProductWith(Vector2D other)
        => (double)(s_ComputeDotProductWithMethod.Invoke(ImplObj , [other.ImplObj]) ?? throw new InvalidOperationException());

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
    public static Vector2D operator +(Vector2D left , Vector2D right)
        => new Vector2D(s_OperatorAdditionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector2D operator -(Vector2D left , Vector2D right)
        => new Vector2D(s_OperatorSubtractionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector2D operator *(Vector2D left , double right)
        => new Vector2D(s_OperatorMultiplicationMethod.Invoke(null , [left.ImplObj , right]) ?? throw new InvalidOperationException());

    public static Vector2D operator -(Vector2D value)
        => new Vector2D(s_OperatorUnaryNegationMethod.Invoke(null , [value.ImplObj]) ?? throw new InvalidOperationException());

    public static bool operator ==(Vector2D? left , Vector2D? right)
    {
        if (left is null || right is null)
            return ReferenceEquals(left, right);
        return (bool)(s_OperatorEqualityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public static bool operator !=(Vector2D? left , Vector2D? right)
    {
        if (left is null || right is null)
            return !ReferenceEquals(left, right);
        return (bool)(s_OperatorInequalityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public bool Equals(Vector2D? other)
        => other is not null
            && (bool)(s_OperatorEqualityMethod.Invoke(null , [ImplObj , other.ImplObj]) ?? throw new InvalidOperationException());

    public override bool Equals(object? obj) => obj is Vector2D other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Z);
    #endregion


    ~Vector2D()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
