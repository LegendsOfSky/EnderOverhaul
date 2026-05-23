using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector3D : IVector<Vector3D , double> ,
                         IAdditionOperators<Vector3D , Vector3D , Vector3D> ,
                         ISubtractionOperators<Vector3D , Vector3D , Vector3D> ,
                         IUnaryNegationOperators<Vector3D , Vector3D> ,
                         IEquatable<Vector3D> , IEqualityOperators<Vector3D , Vector3D , bool>
{
    public double X;
    public double Y;
    public double Z;



    public Vector3D(double x , double y , double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    

    #region Implements IVector<Vector3D , double>
    public double Length()
    {
        throw new NotImplementedException();
    }

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

    public double MaxEntry()
    {
        throw new NotImplementedException();
    }

    public double DotProduct()
    {
        throw new NotImplementedException();
    }

    public Vector3D CrossProduct()
    {
        throw new NotImplementedException();
    }

    public CompassDirection ToCompassDirection()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IAdditionOperators<Vector3D , Vector3D , Vector3D>
    public static Vector3D operator +(Vector3D left , Vector3D right)
    {
        return new Vector3D(left.X + right.X , left.Y + right.Y , left.Z + right.Z);
    }
    #endregion

    #region Implements ISubtractionOperators<Vector3D , Vector3D , Vector3D>
    public static Vector3D operator -(Vector3D left , Vector3D right)
    {
        return new Vector3D(left.X - right.X , left.Y - right.Y , left.Z - right.Z);
    }
    #endregion

    #region Implements IUnaryNegationOperators<Vector3D , Vector3D>
    public static Vector3D operator -(Vector3D value)
    {
        return new Vector3D(-value.X , -value.Y , -value.Z);
    }
    #endregion

    #region IEquatable<Vector3D>
    public bool Equals(Vector3D other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector3D other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X , Y , Z);
    }
    #endregion

    #region IEqualityOperators<Vector3D , Vector3D , bool>
    public static bool operator ==(Vector3D left , Vector3D right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector3D left , Vector3D right)
    {
        return !left.Equals(right);
    }
    #endregion
}
