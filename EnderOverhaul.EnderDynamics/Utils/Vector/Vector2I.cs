using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector2I : IVector<Vector2I , int> ,
                         IAdditionOperators<Vector2I , Vector2I , Vector2I> ,
                         ISubtractionOperators<Vector2I , Vector2I , Vector2I> ,
                         IUnaryNegationOperators<Vector2I , Vector2I> ,
                         IEquatable<Vector2I> , IEqualityOperators<Vector2I , Vector2I , bool>
{
    public int X;
    public int Z;



    public Vector2I(int x , int z)
    {
        X = x;
        Z = z;
    }



    #region Implements IVector<Vector2I , int>
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

    public int MaxEntry() => new[] { X , Z }.Max();
    public int MinEntry() => new[] { X , Z }.Min();

    public int DotProduct()
    {
        throw new NotImplementedException();
    }

    public Vector2I CrossProduct()
    {
        throw new NotImplementedException();
    }

    public CompassDirection ToCompassDirection()
    {
        throw new NotImplementedException();
    }

    public double ToHorizontalWorldAngle() => -Math.Atan2(X , Z) / Math.PI * 180;
    public double ToVerticalWorldAngle() => 0;
    #endregion

    #region Implements IAdditionOperators<Vector2I , Vector2I , Vector2I>
    public static Vector2I operator +(Vector2I left , Vector2I right)
    {
        return new Vector2I(left.X + right.X , left.Z + right.Z);
    }
    #endregion

    #region Implements ISubtractionOperators<Vector2I , Vector2I , Vector2I>
    public static Vector2I operator -(Vector2I left , Vector2I right)
    {
        return new Vector2I(left.X - right.X , left.Z - right.Z);
    }
    #endregion

    #region IUnaryNegationOperators<Vector2I , Vector2I>
    /// <remarks> Never use when .X or .Z equal to Int.MinValue. </remarks>
    public static Vector2I operator -(Vector2I value)
    {
        return new Vector2I(-value.X , -value.Z);
    }
    #endregion

    #region IEquatable<Vector2I>
    public bool Equals(Vector2I other)
    {
        return X == other.X && Z == other.Z;
    }

    public override bool Equals(object? obj)
    {
        return obj is Vector2I other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X , Z);
    }
    #endregion

    #region IEqualityOperators<Vector2I , Vector2I , bool>
    public static bool operator ==(Vector2I left , Vector2I right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector2I left , Vector2I right)
    {
        return !left.Equals(right);
    }
    #endregion
}
