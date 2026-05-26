using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector3I : IVector<Vector3I , int> ,
                         IAdditionOperators<Vector3I , Vector3I , Vector3I> ,
                         ISubtractionOperators<Vector3I , Vector3I , Vector3I> ,
                         IMultiplyOperators<Vector3I , int , Vector3I> ,
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



    public static explicit operator Vector2D(Vector3I vec) => new Vector2D(vec.X , vec.Z);
    public static explicit operator Vector2I(Vector3I vec) => new Vector2I(vec.X , vec.Z);
    public static implicit operator Vector3D(Vector3I vec) => new Vector3D(vec.X , vec.Y , vec.Z);


    #region Implements IVector<Vector3I , int>
    public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

    /// <summary> Check if the vector is facing at North or negative Z axis. </summary>
    public bool IsNorth()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);

        if (xMagnitude > zMagnitude)
            return false;

        return Z < 0;
    }

    /// <summary> Check if the vector is facing at South or positive Z axis. </summary>
    public bool IsSouth()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);

        if (xMagnitude > zMagnitude)
            return false;

        return Z > 0;
    }

    /// <summary> Check if the vector is facing at West or negative X axis. </summary>
    public bool IsWest()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);

        if (zMagnitude > xMagnitude)
            return false;

        return X < 0;
    }

    /// <summary> Check if the vector is facing at East or positive X axis. </summary>
    public bool IsEast()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);

        if (zMagnitude > xMagnitude)
            return false;

        return X > 0;
    }

    public int MaxEntry() => new[] { X , Y , Z }.Max();
    public int MinEntry() => new[] { X , Y , Z }.Min();

    public int DotProduct(Vector3I other) => this.X * other.X + this.Y * other.Y + this.Z * other.Z;
    public Vector3I CrossProduct(Vector3I other) => new Vector3I(
            this.Y * other.Z - this.Z * other.Y ,
            this.Z * other.X - this.X * other.Z ,
            this.X * other.Y - this.Y * other.X
        );

    public CompassDirection ToCardinalCompassDirection()
    {
        throw new NotImplementedException();
    }

    public double ToHorizontalWorldAngle() => -Math.Atan2(X , Z) / Math.PI * 180;
    public double ToVerticalWorldAngle()   => +Math.Atan2(Y , Math.Sqrt(X * X + Z * Z)) / Math.PI * 180;
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

    #region Implements IMultiplyOperators<Vector3I , double , Vector3I>
    public static Vector3I operator *(Vector3I left , int right) => new Vector3I(left.X * right , left.Y * right , left.Z * right);
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
