using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector3I : IVector<Vector3I , int> ,
                         IAdditionOperators<Vector3I , Vector3I , Vector3I> ,
                         ISubtractionOperators<Vector3I , Vector3I , Vector3I> ,
                         IUnaryNegationOperators<Vector3I , Vector3I> ,
                         IEquatable<Vector3I> , IEqualityOperators<Vector3I , Vector3I , bool>
{
    public int X;
    public int Y;
    public int Z;



    public Vector3I(int x , int y , int z)
    {
        X = x;
        Y = y;
        Z = z;
    }



    #region Implements IVector<Vector3I , int>
    public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

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

    public int MaxEntry()
    {
        throw new NotImplementedException();
    }

    public int DotProduct()
    {
        throw new NotImplementedException();
    }

    public Vector3I CrossProduct()
    {
        throw new NotImplementedException();
    }

    public CompassDirection ToCompassDirection()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IAdditionOperators<Vector3I , Vector3I , Vector3I>
    public static Vector3I operator +(Vector3I left , Vector3I right)
    {
        return new Vector3I(left.X + right.X , left.Y + right.Y , left.Z + right.Z);
    }
    #endregion

    #region Implements ISubtractionOperators<Vector3I , Vector3I , Vector3I>
    public static Vector3I operator -(Vector3I left , Vector3I right)
    {
        return new Vector3I(left.X - right.X , left.Y - right.Y , left.Z - right.Z);
    }
    #endregion

    #region Implements IUnaryNegationOperators<Vector3I , Vector3I>
    /// <remarks> Never use when .X, .Y or .Z equal to Int.MinValue. </remarks>
    public static Vector3I operator -(Vector3I value)
    {
        return new Vector3I(-value.X , -value.Y , -value.Z);
    }
    #endregion

    #region Implements IEquatable<Vector3I>
    public bool Equals(Vector3I other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector3I other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X , Y , Z);
    }
    #endregion

    #region IEqualityOperators<Vector3I , Vector3I , bool>
    public static bool operator ==(Vector3I left , Vector3I right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector3I left , Vector3I right)
    {
        return !left.Equals(right);
    }
    #endregion
}
