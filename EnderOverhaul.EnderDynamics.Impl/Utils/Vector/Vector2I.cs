using System.Numerics;


namespace EnderOverhaul.EnderDynamics.Impl.Utils.Vector;


public class Vector2I : IVector<Vector2I , int> ,
                         IAdditionOperators<Vector2I , Vector2I , Vector2I> ,
                         ISubtractionOperators<Vector2I , Vector2I , Vector2I> ,
                         IMultiplyOperators<Vector2I , int , Vector2I> ,
                         IUnaryNegationOperators<Vector2I , Vector2I> ,
                         IEquatable<Vector2I> , IEqualityOperators<Vector2I , Vector2I , bool>
{
    public int X;
    public int Z;


    public Vector2I() { }

    public Vector2I(int x , int z)
    {
        X = x;
        Z = z;
    }


    public static implicit operator Vector2D(Vector2I vec) => new Vector2D(vec.X , vec.Z);
    public static implicit operator Vector3D(Vector2I vec) => new Vector3D(vec.X , 0 , vec.Z);
    public static implicit operator Vector3I(Vector2I vec) => new Vector3I(vec.X , 0 , vec.Z);

    public Vector2I DeepCopy() => new Vector2I(X , Z);

    public int Determinant(Vector2I other) => this.X * other.Z - this.Z * other.X;

    public override string ToString() => $"({X}, {Z})";


    #region Implements IVector<Vector2I , int>
    public double Length   => Math.Sqrt(X * X + Z * Z);
    public int    MaxEntry => new[] { X , Z }.Max();
    public int    MinEntry => new[] { X , Z }.Min();


    public int GetDominantEntry()
    {
        return Math.Abs(X) > Math.Abs(Z) ? X : Z;
    }

    public CompassDirections ToCardinalCompassDirection() =>
        Math.Abs(X) > Math.Abs(Z)
            ? X > 0 ? CompassDirections.East : CompassDirections.West
            : Z > 0 ? CompassDirections.South : CompassDirections.North;

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

    public int ComputeDotProductWith(Vector2I other) => this.X * other.X + this.Z * other.Z;

    public double ToHorizontalWorldAngle() => -Math.Atan2(X , Z) / Math.PI * 180;

    public double ToVerticalWorldAngle() => 0;
    #endregion

    #region Implements for other inheritances
    public static Vector2I operator +(Vector2I left , Vector2I right) => new(left.X + right.X , left.Z + right.Z);

    public static Vector2I operator -(Vector2I left , Vector2I right) => new(left.X - right.X , left.Z - right.Z);

    public static Vector2I operator *(Vector2I left , int right) => new(left.X * right , left.Z * right);

    /// <remarks> Never use when .X or .Z equal to Int.MinValue. </remarks>
    public static Vector2I operator -(Vector2I value) => new(-value.X , -value.Z);

    public bool Equals(Vector2I other) => X == other.X && Z == other.Z;

    public override bool Equals(object? obj) => obj is Vector2I other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Z);

    public static bool operator ==(Vector2I left , Vector2I right) => left.Equals(right);

    public static bool operator !=(Vector2I left , Vector2I right) => !left.Equals(right);
    #endregion

}
