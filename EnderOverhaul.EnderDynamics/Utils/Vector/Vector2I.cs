using System.Numerics;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector2I : IVector<Vector2I , int> ,
                         IAdditionOperators<Vector2I , Vector2I , Vector2I> ,
                         ISubtractionOperators<Vector2I , Vector2I , Vector2I> ,
                         IMultiplyOperators<Vector2I , int , Vector2I> ,
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



    public static implicit operator Vector2D(Vector2I vec) => new Vector2D(vec.X , vec.Z);
    public static implicit operator Vector3D(Vector2I vec) => new Vector3D(vec.X , 0 , vec.Z);
    public static implicit operator Vector3I(Vector2I vec) => new Vector3I(vec.X , 0 , vec.Z);


    #region Implements IVector<Vector2I , int>
    public double Length() => Math.Sqrt(X * X + Z * Z);

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

    public int MaxEntry() => new[] { X , Z }.Max();
    public int MinEntry() => new[] { X , Z }.Min();

    public int DotProduct(Vector2I other) => this.X * other.X + this.Z * other.Z;

    public int Determinant(Vector2I other) => this.X * other.Z - this.Z * other.X;

    public CompassDirection ToCardinalCompassDirection()
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

    #region Implements IMultiplyOperators<Vector2I , double , Vector2I>
    public static Vector2I operator *(Vector2I left , int right) => new(left.X * right , left.Z * right);
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
