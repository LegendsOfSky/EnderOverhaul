using System.Numerics;


namespace EnderOverhaul.EnderDynamics.Impl.Utils.Vector;


public struct Vector2D : IVector<Vector2D , double> ,
                         IAdditionOperators<Vector2D , Vector2D , Vector2D> ,
                         ISubtractionOperators<Vector2D , Vector2D , Vector2D> ,
                         IMultiplyOperators<Vector2D , double , Vector2D> ,
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


    public static explicit operator Vector2I(Vector2D vec) => new Vector2I((int)Math.Round(vec.X) , (int)Math.Round(vec.Z));
    public static implicit operator Vector3D(Vector2D vec) => new Vector3D(vec.X , 0 , vec.Z);
    public static explicit operator Vector3I(Vector2D vec) => new Vector3I((int)Math.Round(vec.X) , 0 , (int)Math.Round(vec.Z));

    public double Determinant(Vector2D other) => this.X * other.Z - this.Z * other.X;

    public override string ToString() => $"({X}, {Z})";


    #region Implements IVector<Vector2D , double>
    public double Length   => Math.Sqrt(X * X + Z * Z);
    public double MaxEntry => new[] { X , Z }.Max();
    public double MinEntry => new[] { X , Z }.Min();


    public double GetDominantEntry()
    {
        return Math.Abs(X) > Math.Abs(Z) ? X : Z;
    }

    public CompassDirection ToCardinalCompassDirection() =>
        Math.Abs(X) > Math.Abs(Z)
            ? X > 0 ? CompassDirection.East : CompassDirection.West
            : Z > 0 ? CompassDirection.South : CompassDirection.North;

    /// <summary> Check if the vector is facing at North or negative Z axis. </summary>
    public bool IsNorth()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);
        return zMagnitude >= xMagnitude && Z < 0;
    }

    /// <summary> Check if the vector is facing at South or positive Z axis. </summary>
    public bool IsSouth()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);
        return zMagnitude >= xMagnitude && Z > 0;
    }

    /// <summary> Check if the vector is facing at West or negative X axis. </summary>
    public bool IsWest()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);
        return xMagnitude >= zMagnitude && X < 0;
    }

    /// <summary> Check if the vector is facing at East or positive X axis. </summary>
    public bool IsEast()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);
        return xMagnitude >= zMagnitude && X > 0;
    }

    public double ComputeDotProductWith(Vector2D other) => this.X * other.X + this.Z * other.Z;

    // positive Z = 0
    // negative X = 90
    // negative Z = -180
    // positive X = -90
    public double ToHorizontalWorldAngle() => -Math.Atan2(X , Z) / Math.PI * 180;

    public double ToVerticalWorldAngle() => 0;
    #endregion

    #region Implements for other inheritances
    public static Vector2D operator +(Vector2D left , Vector2D right) => new Vector2D(left.X + right.X , left.Z + right.Z);

    public static Vector2D operator -(Vector2D left , Vector2D right) => new Vector2D(left.X - right.X , left.Z - right.Z);

    public static Vector2D operator *(Vector2D left , double right) => new Vector2D(left.X * right , left.Z * right);

    public static Vector2D operator -(Vector2D value) => new Vector2D(-value.X , -value.Z);

    public bool Equals(Vector2D other) => X.Equals(other.X) && Z.Equals(other.Z);

    public override bool Equals(object? obj) => obj is Vector2D other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Z);

    public static bool operator ==(Vector2D left , Vector2D right) => left.Equals(right);

    public static bool operator !=(Vector2D left , Vector2D right) => !left.Equals(right);
    #endregion
}
