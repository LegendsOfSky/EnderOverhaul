using System.Numerics;


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

    public Vector3I CrossProduct(Vector3I other) => new Vector3I(
            this.Y * other.Z - this.Z * other.Y ,
            this.Z * other.X - this.X * other.Z ,
            this.X * other.Y - this.Y * other.X
        );

    public override string ToString() => $"({X}, {Y}, {Z})";


    #region Implements IVector<Vector3I , int>
    public double Length   => Math.Sqrt(X * X + Y * Y + Z * Z);
    public int    MaxEntry => new[] { X , Y , Z }.Max();
    public int    MinEntry => new[] { X , Y , Z }.Min();


    public int GetDominantEntry()
    {
        int absX = Math.Abs(X) , absY = Math.Abs(Y) , absZ = Math.Abs(Z);
        if (absX > absY && absX > absZ) { return X; }
        return absY > absZ ? Y : Z;
    }

    public int ComputeDotProductWith(Vector3I other) => this.X * other.X + this.Y * other.Y + this.Z * other.Z;

    /// <summary> Check if the vector is facing at North or negative Z axis. </summary>
    public bool IsNorth()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);
        return zMagnitude >= xMagnitude && Z < 0;
    }

    /// <summary> Check if the vector is facing at South or positive Z axis. </summary>
    public bool IsSouth()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);
        return zMagnitude >= xMagnitude && Z > 0;
    }

    /// <summary> Check if the vector is facing at West or negative X axis. </summary>
    public bool IsWest()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);
        return xMagnitude >= zMagnitude && X < 0;
    }

    /// <summary> Check if the vector is facing at East or positive X axis. </summary>
    public bool IsEast()
    {
        int xMagnitude = Math.Abs(X);
        int zMagnitude = Math.Abs(Z);
        return xMagnitude >= zMagnitude && X > 0;
    }

    public CompassDirection ToCardinalCompassDirection() =>
        Math.Abs(X) > Math.Abs(Z) 
            ? X > 0 ? CompassDirection.East  : CompassDirection.West
            : Z > 0 ? CompassDirection.South : CompassDirection.North;

    public double ToHorizontalWorldAngle() => -Math.Atan2(X , Z) / Math.PI * 180;

    public double ToVerticalWorldAngle()   => +Math.Atan2(Y , Math.Sqrt(X * X + Z * Z)) / Math.PI * 180;
    #endregion

    #region Implements other inheritances
    public static Vector3I operator +(Vector3I left , Vector3I right) => new(left.X + right.X , left.Y + right.Y , left.Z + right.Z);

    public static Vector3I operator -(Vector3I left , Vector3I right) => new(left.X - right.X , left.Y - right.Y , left.Z - right.Z);

    public static Vector3I operator *(Vector3I left , int right) => new Vector3I(left.X * right , left.Y * right , left.Z * right);

    /// <remarks> Never use when .X, .Y or .Z equal to Int.MinValue. </remarks>
    public static Vector3I operator -(Vector3I value) => new(-value.X , -value.Y , -value.Z);

    public bool Equals(Vector3I other) => X == other.X && Y == other.Y && Z == other.Z;

    public override bool Equals(object? obj) => obj is Vector3I other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Y , Z);

    public static bool operator ==(Vector3I left , Vector3I right) => left.Equals(right);

    public static bool operator !=(Vector3I left , Vector3I right) => !left.Equals(right);
    #endregion
}
