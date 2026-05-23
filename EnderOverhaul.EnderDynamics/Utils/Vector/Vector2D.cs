using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector2D : IVector<Vector2D , double> ,
                         IAdditionOperators<Vector2D , Vector2D , Vector2D> ,
                         ISubtractionOperators<Vector2D , Vector2D , Vector2D> ,
                         IUnaryNegationOperators<Vector2D , Vector2D> ,
                         IEquatable<Vector2D> , IEqualityOperators<Vector2D , Vector2D , bool>
{
    public double X;
    public double Z;



    public Vector2D(double x , double z)
    {
        X = x;
        Z = z;
    }



    #region Implements IVector<Vector2D , double>
    public double Length() => Math.Sqrt(X * X + Z * Z);

    public bool IsNorth()
    {
        throw new NotImplementedException();
    }

    public bool IsSouth()
    {
        throw new NotImplementedException();
    }

    public bool IsWest()
    {
        throw new NotImplementedException();
    }

    public bool IsEast()
    {
        throw new NotImplementedException();
    }

    public double MaxEntry() => new[] { X , Z }.Max();
    public double MinEntry() => new[] { X , Z }.Min();

    public double DotProduct()
    {
        throw new NotImplementedException();
    }

    public Vector2D CrossProduct()
    {
        throw new NotImplementedException();
    }

    public CompassDirection ToCompassDirection()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IAdditionOperators<Vector2D , Vector2D , Vector2D>
    public static Vector2D operator +(Vector2D left , Vector2D right)
    {
        return new Vector2D(left.X + right.X , left.Z + right.Z);
    }
    #endregion

    #region Implements ISubtractionOperators<Vector2D , Vector2D , Vector2D>
    public static Vector2D operator -(Vector2D left , Vector2D right)
    {
        return new Vector2D(left.X - right.X , left.Z - right.Z);
    }
    #endregion

    #region Implements IUnaryNegationOperators<Vector2D , Vector2D>
    public static Vector2D operator -(Vector2D value)
    {
        return new Vector2D(-value.X , -value.Z);
    }
    #endregion

    #region Implements IEquatable<Vector2D>
    public bool Equals(Vector2D other)
    {
        return X.Equals(other.X) && Z.Equals(other.Z);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2D other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X , Z);
    }
    #endregion

    #region IEqualityOperators<Vector2D , Vector2D , bool>
    public static bool operator ==(Vector2D left , Vector2D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector2D left , Vector2D right)
    {
        return !left.Equals(right);
    }
    #endregion
}
