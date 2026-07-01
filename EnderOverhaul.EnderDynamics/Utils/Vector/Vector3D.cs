using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using Vector2DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector2D;
using Vector2IImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector2I;
using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;
using Vector3IImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3I;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;

public class Vector3D : IVector<Vector3D , double> ,
                        IAdditionOperators<Vector3D , Vector3D , Vector3D> ,
                        ISubtractionOperators<Vector3D , Vector3D , Vector3D> ,
                        IMultiplyOperators<Vector3D , double , Vector3D> ,
                        IUnaryNegationOperators<Vector3D , Vector3D> ,
                        IEquatable<Vector3D> ,
                        IEqualityOperators<Vector3D , Vector3D , bool>
{
    public double X
    {
        get => (double)(s_FieldInfoX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => s_FieldInfoX.SetValue(ImplObj , value);
    }
    public double Y
    {
        get => (double)(s_FieldInfoY.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => s_FieldInfoY.SetValue(ImplObj , value);
    }
    public double Z
    {
        get => (double)(s_FieldInfoZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => s_FieldInfoZ.SetValue(ImplObj , value);
    }

    internal object ImplObj;

    private static Type s_ImplType;
    private static FieldInfo s_FieldInfoX;
    private static FieldInfo s_FieldInfoY;
    private static FieldInfo s_FieldInfoZ;
    private static MethodInfo s_OperatorAdditionMethod;
    private static MethodInfo s_OperatorSubtractionMethod;
    private static MethodInfo s_OperatorMultiplicationMethod;
    private static MethodInfo s_OperatorUnaryNegationMethod;
    private static MethodInfo s_OperatorEqualityMethod;
    private static MethodInfo s_OperatorInequalityMethod;
    private static MethodInfo s_ExplicitCastToVector2D;
    private static MethodInfo s_ExplicitCastToVector2I;
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


    static Vector3D()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    public Vector3D()
    {
        ImplObj = Activator.CreateInstance(s_ImplType) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    public Vector3D(double x , double y , double z)
    {
        ImplObj = Activator.CreateInstance(s_ImplType , x , y , z) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    internal Vector3D(object implObj)
    {
        ImplObj = implObj;
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }


    public static explicit operator Vector2D(Vector3D vec) => new Vector2D(s_ExplicitCastToVector2D.Invoke(null , [vec.ImplObj]) ?? throw new InvalidCastException());
    public static explicit operator Vector2I(Vector3D vec) => new Vector2I(s_ExplicitCastToVector2I.Invoke(null , [vec.ImplObj]) ?? throw new InvalidCastException());
    public static explicit operator Vector3I(Vector3D vec) => new Vector3I(s_ExplicitCastToVector3I.Invoke(null , [vec.ImplObj]) ?? throw new InvalidCastException());

    public override string ToString() => $"({X}, {Y}, {Z})";

    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(Vector3DImpl).ToString())
            ?? throw new TypeLoadException();

        s_LengthProperty = s_ImplType.GetProperty("Length") ?? throw new TypeLoadException();
        s_MaxEntryProperty = s_ImplType.GetProperty("MaxEntry") ?? throw new TypeLoadException();
        s_MinEntryProperty = s_ImplType.GetProperty("MinEntry") ?? throw new TypeLoadException();

        s_FieldInfoX = s_ImplType.GetField("X") ?? throw new TypeLoadException();
        s_FieldInfoY = s_ImplType.GetField("Y") ?? throw new TypeLoadException();
        s_FieldInfoZ = s_ImplType.GetField("Z") ?? throw new TypeLoadException();

        MethodInfo[] publicStaticMethods = s_ImplType.GetMethods(BindingFlags.Public | BindingFlags.Static);
        s_OperatorAdditionMethod       = publicStaticMethods.First(method => method.Name == "op_Addition"     );
        s_OperatorSubtractionMethod    = publicStaticMethods.First(method => method.Name == "op_Subtraction"  );
        s_OperatorMultiplicationMethod = publicStaticMethods.First(method => method.Name == "op_Multiply"     );
        s_OperatorUnaryNegationMethod  = publicStaticMethods.First(method => method.Name == "op_UnaryNegation");
        s_OperatorEqualityMethod       = publicStaticMethods.First(method => method.Name == "op_Equality"     );
        s_OperatorInequalityMethod     = publicStaticMethods.First(method => method.Name == "op_Inequality"   );
        s_ExplicitCastToVector2D = publicStaticMethods.First(method => method.Name == "op_Explicit" && method.ReturnType.FullName == typeof(Vector2DImpl).ToString());
        s_ExplicitCastToVector2I = publicStaticMethods.First(method => method.Name == "op_Explicit" && method.ReturnType.FullName == typeof(Vector2IImpl).ToString());
        s_ExplicitCastToVector3I = publicStaticMethods.First(method => method.Name == "op_Explicit" && method.ReturnType.FullName == typeof(Vector3IImpl).ToString());
        
        s_GetDominantEntryMethod = s_ImplType.GetMethod("GetDominantEntry" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ComputeDotProductWithMethod = s_ImplType.GetMethod("ComputeDotProductWith" , BindingFlags.Public | BindingFlags.Instance , null , [s_ImplType] , null)
            ?? throw new TypeLoadException();
        s_IsNorthMethod = s_ImplType.GetMethod("IsNorth" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsSouthMethod = s_ImplType.GetMethod("IsSouth" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsWestMethod  = s_ImplType.GetMethod("IsWest"  , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_IsEastMethod  = s_ImplType.GetMethod("IsEast"  , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToCardinalCompassDirectionMethod = s_ImplType.GetMethod("ToCardinalCompassDirection" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToHorizontalWorldAngleMethod = s_ImplType.GetMethod("ToHorizontalWorldAngle" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_ToVerticalWorldAngleMethod   = s_ImplType.GetMethod("ToVerticalWorldAngle"   , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplType = args.NewImplementation.GetType(typeof(Vector3DImpl).ToString())
            ?? throw new TypeLoadException();
        FieldInfo curFieldX = currentImplType.GetField("X") ?? throw new TypeLoadException();
        FieldInfo curFieldY = currentImplType.GetField("Y") ?? throw new TypeLoadException();
        FieldInfo curFieldZ = currentImplType.GetField("Z") ?? throw new TypeLoadException();
        double curX = (double)(curFieldX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        double curY = (double)(curFieldY.GetValue(ImplObj) ?? throw new InvalidOperationException());
        double curZ = (double)(curFieldZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        ImplObj = Activator.CreateInstance(newImplType , curX , curY , curZ) ?? throw new InvalidOperationException();
    }


    #region Implements IVector<Vector3D , double>
    public double Length => (double)(s_LengthProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public double MaxEntry => (double)(s_MaxEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public double MinEntry => (double)(s_MinEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());

    public double GetDominantEntry()
        => (double)(s_GetDominantEntryMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ComputeDotProductWith(Vector3D other)
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
    public static Vector3D operator +(Vector3D left , Vector3D right)
        => new Vector3D(s_OperatorAdditionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector3D operator -(Vector3D left , Vector3D right)
        => new Vector3D(s_OperatorSubtractionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector3D operator *(Vector3D left , double right)
        => new Vector3D(s_OperatorMultiplicationMethod.Invoke(null , [left.ImplObj , right]) ?? throw new InvalidOperationException());

    public static Vector3D operator -(Vector3D value)
        => new Vector3D(s_OperatorUnaryNegationMethod.Invoke(null , [value.ImplObj]) ?? throw new InvalidOperationException());

    public static bool operator ==(Vector3D? left , Vector3D? right)
    {
        if (left is null || right is null)
            return ReferenceEquals(left, right);
        return (bool)(s_OperatorEqualityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public static bool operator !=(Vector3D? left , Vector3D? right)
    {
        if (left is null || right is null)
            return !ReferenceEquals(left, right);
        return (bool)(s_OperatorInequalityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public bool Equals(Vector3D? other)
        => other is not null
            && (bool)(s_OperatorEqualityMethod.Invoke(null , [ImplObj , other.ImplObj]) ?? throw new InvalidOperationException());

    public override bool Equals(object? obj) => obj is Vector3D other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Y , Z);
    #endregion


    ~Vector3D()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
