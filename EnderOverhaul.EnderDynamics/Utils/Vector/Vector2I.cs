using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;

using EnderOverhaul.EnderDynamics.Utils;  // for CompassDirection

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
        get => (int)(fieldInfoX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => fieldInfoX.SetValue(ImplObj , value);
    }
    public int Z
    {
        get => (int)(fieldInfoZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => fieldInfoZ.SetValue(ImplObj , value);
    }

    internal object ImplObj;

    private static Type implType;
    private static FieldInfo fieldInfoX;
    private static FieldInfo fieldInfoZ;
    private static MethodInfo operatorAdditionMethod;
    private static MethodInfo operatorSubtractionMethod;
    private static MethodInfo operatorMultiplicationMethod;
    private static MethodInfo operatorUnaryNegationMethod;
    private static MethodInfo operatorEqualityMethod;
    private static MethodInfo operatorInequalityMethod;

    // IVector members (delegated to Impl)
    private static PropertyInfo lengthProperty;
    private static PropertyInfo maxEntryProperty;
    private static PropertyInfo minEntryProperty;
    private static MethodInfo getDominantEntryMethod;
    private static MethodInfo computeDotProductWithMethod;
    private static MethodInfo isNorthMethod;
    private static MethodInfo isSouthMethod;
    private static MethodInfo isWestMethod;
    private static MethodInfo isEastMethod;
    private static MethodInfo toCardinalCompassDirectionMethod;
    private static MethodInfo toHorizontalWorldAngleMethod;
    private static MethodInfo toVerticalWorldAngleMethod;


    static Vector2I()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.ImplementationLibrary);
    }

    public Vector2I(int x , int z)
    {
        ImplObj = Activator.CreateInstance(implType , x , z) ?? throw new InvalidOperationException();
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
        implType = newAssembly.GetType(typeof(Vector2IImpl).ToString())
            ?? throw new TypeLoadException();
        fieldInfoX = implType.GetField("X") ?? throw new TypeLoadException();
        fieldInfoZ = implType.GetField("Z") ?? throw new TypeLoadException();
        operatorAdditionMethod = implType.GetMethod("op_Addition" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        operatorSubtractionMethod = implType.GetMethod("op_Subtraction" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        operatorMultiplicationMethod = implType.GetMethod("op_Multiply" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        operatorUnaryNegationMethod = implType.GetMethod("op_UnaryNegation" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        operatorEqualityMethod = implType.GetMethod("op_Equality" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();
        operatorInequalityMethod = implType.GetMethod("op_Inequality" , BindingFlags.Public | BindingFlags.Static) ?? throw new TypeLoadException();

        // IVector
        lengthProperty = implType.GetProperty("Length") ?? throw new TypeLoadException();
        maxEntryProperty = implType.GetProperty("MaxEntry") ?? throw new TypeLoadException();
        minEntryProperty = implType.GetProperty("MinEntry") ?? throw new TypeLoadException();
        getDominantEntryMethod = implType.GetMethod("GetDominantEntry", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        computeDotProductWithMethod = implType.GetMethod("ComputeDotProductWith", BindingFlags.Public | BindingFlags.Instance, null, new[] { implType }, null) ?? throw new TypeLoadException();
        isNorthMethod = implType.GetMethod("IsNorth", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        isSouthMethod = implType.GetMethod("IsSouth", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        isWestMethod = implType.GetMethod("IsWest", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        isEastMethod = implType.GetMethod("IsEast", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        toCardinalCompassDirectionMethod = implType.GetMethod("ToCardinalCompassDirection", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        toHorizontalWorldAngleMethod = implType.GetMethod("ToHorizontalWorldAngle", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        toVerticalWorldAngleMethod = implType.GetMethod("ToVerticalWorldAngle", BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        // Re-resolve field info from the *actual* current ImplObj's type to avoid
        // type identity issues when the Impl assembly may have been loaded multiple times.
        var currentImplType = ImplObj.GetType();
        var curFieldX = currentImplType.GetField("X") ?? throw new TypeLoadException();
        var curFieldZ = currentImplType.GetField("Z") ?? throw new TypeLoadException();

        int curX = (int)(curFieldX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        int curZ = (int)(curFieldZ.GetValue(ImplObj) ?? throw new InvalidOperationException());

        Type type = args.NewImplementation.GetType(typeof(Vector2IImpl).ToString())
            ?? throw new TypeLoadException();
        ImplObj = Activator.CreateInstance(type , curX , curZ) ?? throw new InvalidOperationException();
    }


    #region Implements IVector<Vector2I , int>
    public double Length   => (double)(lengthProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public int    MaxEntry => (int)(maxEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public int    MinEntry => (int)(minEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());

    public int GetDominantEntry()
        => (int)(getDominantEntryMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public int ComputeDotProductWith(Vector2I other)
        => (int)(computeDotProductWithMethod.Invoke(ImplObj , new object?[] { other.ImplObj }) ?? throw new InvalidOperationException());

    public bool IsNorth() => (bool)(isNorthMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    public bool IsSouth() => (bool)(isSouthMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    public bool IsWest()  => (bool)(isWestMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    public bool IsEast()  => (bool)(isEastMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public CompassDirection ToCardinalCompassDirection()
        => (CompassDirection)(toCardinalCompassDirectionMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ToHorizontalWorldAngle()
        => (double)(toHorizontalWorldAngleMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ToVerticalWorldAngle()
        => (double)(toVerticalWorldAngleMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());
    #endregion

    #region Implementations for other interfaces
    public static Vector2I operator +(Vector2I left , Vector2I right)
        => new Vector2I(operatorAdditionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector2I operator -(Vector2I left , Vector2I right)
        => new Vector2I(operatorSubtractionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector2I operator *(Vector2I left , int right)
        => new Vector2I(operatorMultiplicationMethod.Invoke(null , [left.ImplObj , right]) ?? throw new InvalidOperationException());

    public static Vector2I operator -(Vector2I value)
        => new Vector2I(operatorUnaryNegationMethod.Invoke(null , [value.ImplObj]) ?? throw new InvalidOperationException());

    public static bool operator ==(Vector2I? left , Vector2I? right)
    {
        if (left is null || right is null)
            return ReferenceEquals(left, right);
        return (bool)(operatorEqualityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public static bool operator !=(Vector2I? left , Vector2I? right)
    {
        if (left is null || right is null)
            return !ReferenceEquals(left, right);
        return (bool)(operatorInequalityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public bool Equals(Vector2I? other)
    {
        if (other is null) return false;
        return (bool)(operatorEqualityMethod.Invoke(null , [ImplObj , other.ImplObj]) ?? throw new InvalidOperationException());
    }

    public override bool Equals(object? obj) => obj is Vector2I other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Z);
    #endregion


    ~Vector2I()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
