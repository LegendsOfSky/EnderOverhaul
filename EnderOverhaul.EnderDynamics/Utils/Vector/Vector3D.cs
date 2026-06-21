using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;

using EnderOverhaul.EnderDynamics.Utils;  // for CompassDirection

using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;


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
        get => (double)(fieldInfoX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => fieldInfoX.SetValue(ImplObj , value);
    }
    public double Y
    {
        get => (double)(fieldInfoY.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => fieldInfoY.SetValue(ImplObj , value);
    }
    public double Z
    {
        get => (double)(fieldInfoZ.GetValue(ImplObj) ?? throw new InvalidOperationException());
        set => fieldInfoZ.SetValue(ImplObj , value);
    }

    internal object ImplObj;

    private static Type implType;
    private static FieldInfo fieldInfoX;
    private static FieldInfo fieldInfoY;
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


    static Vector3D()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.ImplementationLibrary);
    }

    public Vector3D(double x , double y , double z)
    {
        ImplObj = Activator.CreateInstance(implType , x , y , z) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    internal Vector3D(object implObj)
    {
        ImplObj = implObj;
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }


    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        implType = newAssembly.GetType(typeof(Vector3DImpl).ToString())
            ?? throw new TypeLoadException();
        fieldInfoX = implType.GetField("X") ?? throw new TypeLoadException();
        fieldInfoY = implType.GetField("Y") ?? throw new TypeLoadException();
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
        var currentImplType = ImplObj.GetType();
        var curFieldX = currentImplType.GetField("X") ?? throw new TypeLoadException();
        var curFieldY = currentImplType.GetField("Y") ?? throw new TypeLoadException();
        var curFieldZ = currentImplType.GetField("Z") ?? throw new TypeLoadException();

        double curX = (double)(curFieldX.GetValue(ImplObj) ?? throw new InvalidOperationException());
        double curY = (double)(curFieldY.GetValue(ImplObj) ?? throw new InvalidOperationException());
        double curZ = (double)(curFieldZ.GetValue(ImplObj) ?? throw new InvalidOperationException());

        Type type = args.NewImplementation.GetType(typeof(Vector3DImpl).ToString())
            ?? throw new TypeLoadException();
        ImplObj = Activator.CreateInstance(type , curX , curY , curZ) ?? throw new InvalidOperationException();
    }


    #region Implements IVector<Vector3D , double>
    public double Length   => (double)(lengthProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public double MaxEntry => (double)(maxEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());
    public double MinEntry => (double)(minEntryProperty.GetValue(ImplObj) ?? throw new InvalidOperationException());

    public double GetDominantEntry()
        => (double)(getDominantEntryMethod.Invoke(ImplObj , null) ?? throw new InvalidOperationException());

    public double ComputeDotProductWith(Vector3D other)
        => (double)(computeDotProductWithMethod.Invoke(ImplObj , new object?[] { other.ImplObj }) ?? throw new InvalidOperationException());

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
    public static Vector3D operator +(Vector3D left , Vector3D right)
        => new Vector3D(operatorAdditionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector3D operator -(Vector3D left , Vector3D right)
        => new Vector3D(operatorSubtractionMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());

    public static Vector3D operator *(Vector3D left , double right)
        => new Vector3D(operatorMultiplicationMethod.Invoke(null , [left.ImplObj , right]) ?? throw new InvalidOperationException());

    public static Vector3D operator -(Vector3D value)
        => new Vector3D(operatorUnaryNegationMethod.Invoke(null , [value.ImplObj]) ?? throw new InvalidOperationException());

    public static bool operator ==(Vector3D? left , Vector3D? right)
    {
        if (left is null || right is null)
            return ReferenceEquals(left, right);
        return (bool)(operatorEqualityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public static bool operator !=(Vector3D? left , Vector3D? right)
    {
        if (left is null || right is null)
            return !ReferenceEquals(left, right);
        return (bool)(operatorInequalityMethod.Invoke(null , [left.ImplObj , right.ImplObj]) ?? throw new InvalidOperationException());
    }

    public bool Equals(Vector3D? other)
    {
        if (other is null) return false;
        return (bool)(operatorEqualityMethod.Invoke(null , [ImplObj , other.ImplObj]) ?? throw new InvalidOperationException());
    }

    public override bool Equals(object? obj) => obj is Vector3D other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Y , Z);
    #endregion


    ~Vector3D()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
