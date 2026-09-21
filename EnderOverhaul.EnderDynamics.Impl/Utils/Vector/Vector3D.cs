using System.Numerics;


namespace EnderOverhaul.EnderDynamics.Impl.Utils.Vector;


public class Vector3D : IVector<Vector3D , double> ,
                         IAdditionOperators<Vector3D , Vector3D , Vector3D> ,
                         ISubtractionOperators<Vector3D , Vector3D , Vector3D> ,
                         IMultiplyOperators<Vector3D , double , Vector3D> ,
                         IUnaryNegationOperators<Vector3D , Vector3D> ,
                         IEquatable<Vector3D> , IEqualityOperators<Vector3D , Vector3D , bool>
{
    public double X;
    public double Y;
    public double Z;


    public Vector3D() { }

    public Vector3D(double x , double y , double z)
    {
        X = x;
        Y = y;
        Z = z;
    }


    public static explicit operator Vector2D(Vector3D vec) => new Vector2D(vec.X , vec.Z);
    public static explicit operator Vector2I(Vector3D vec) => new Vector2I((int)Math.Round(vec.X) , (int)Math.Round(vec.Z));
    public static explicit operator Vector3I(Vector3D vec) => new Vector3I((int)Math.Round(vec.X) , (int)Math.Round(vec.Y) , (int)Math.Round(vec.Z));

    public Vector3D DeepCopy() => new Vector3D(X , Y , Z);

    public Vector3D CrossProduct(Vector3D other) => new Vector3D(
            this.Y * other.Z - this.Z * other.Y ,
            this.Z * other.X - this.X * other.Z ,
            this.X * other.Y - this.Y * other.X
        );

    public override string ToString() => $"({X}, {Y}, {Z})";


    #region Implements IVector<Vector3D , double>
    public double Length   => Math.Sqrt(X * X + Y * Y + Z * Z);
    public double MaxEntry => new[] { X , Y , Z }.Max();
    public double MinEntry => new[] { X , Y , Z }.Min();


    public double GetDominantEntry()
    {
        double absX = Math.Abs(X) , absY = Math.Abs(Y) , absZ = Math.Abs(Z);
        if (absX    > absY && absX > absZ) { return X; }
        return absY > absZ ? Y : Z;
    }

    public double ComputeDotProductWith(Vector3D other) => this.X * other.X + this.Y * other.Y + this.Z * other.Z;

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

    public CompassDirections ToCardinalCompassDirection() =>
        Math.Abs(X) > Math.Abs(Z)
            ? X > 0 ? CompassDirections.East  : CompassDirections.West
            : Z > 0 ? CompassDirections.South : CompassDirections.North;

    public double ToHorizontalWorldAngle() => -Math.Atan2(X , Z) / Math.PI * 180;

    public double ToVerticalWorldAngle()   => +Math.Atan2(Y , Math.Sqrt(X * X + Z * Z)) / Math.PI * 180;
    #endregion

    #region Implements for other inheritances
    public static Vector3D operator +(Vector3D left , Vector3D right) => new(left.X + right.X , left.Y + right.Y , left.Z + right.Z);

    public static Vector3D operator -(Vector3D left , Vector3D right) => new(left.X - right.X , left.Y - right.Y , left.Z - right.Z);

    public static Vector3D operator *(Vector3D left , double right) => new Vector3D(left.X * right , left.Y * right , left.Z * right);

    public static Vector3D operator -(Vector3D value) => new(-value.X , -value.Y , -value.Z);

    public bool Equals(Vector3D other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

    public override bool Equals(object? obj) => obj is Vector3D other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X , Y , Z);

    public static bool operator ==(Vector3D left , Vector3D right) => left.Equals(right);

    public static bool operator !=(Vector3D left , Vector3D right) => !left.Equals(right);
    #endregion
}
