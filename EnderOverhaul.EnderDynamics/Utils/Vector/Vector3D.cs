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



    public static explicit operator Vector2D(Vector3D vec) => new Vector2D(vec.X , vec.Z);
    public static explicit operator Vector2I(Vector3D vec) => new Vector2I((int)Math.Round(vec.X) , (int)Math.Round(vec.Z));
    public static explicit operator Vector3I(Vector3D vec) => new Vector3I((int)Math.Round(vec.X) , (int)Math.Round(vec.Y) , (int)Math.Round(vec.Z));


    #region Implements IVector<Vector3D , double>
    public double Length() => Math.Sqrt(X * X + Y * Y + Z * Z);

    /// <summary> Check if the vector is facing at North or negative Z axis. </summary>
    public bool IsNorth()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);

        if (xMagnitude > zMagnitude)
            return false;

        return Z < 0;
    }

    /// <summary> Check if the vector is facing at South or positive Z axis. </summary>
    public bool IsSouth()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);

        if (xMagnitude > zMagnitude)
            return false;

        return Z > 0;
    }

    /// <summary> Check if the vector is facing at West or negative X axis. </summary>
    public bool IsWest()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);

        if (zMagnitude > xMagnitude)
            return false;

        return X < 0;
    }

    /// <summary> Check if the vector is facing at East or positive X axis. </summary>
    public bool IsEast()
    {
        double xMagnitude = Math.Abs(X);
        double zMagnitude = Math.Abs(Z);

        if (zMagnitude > xMagnitude)
            return false;

        return X > 0;
    }

    public double MaxEntry() => new[] { X , Y , Z }.Max();
    public double MinEntry() => new[] { X , Y , Z }.Min();

    public double DotProduct(Vector3D other) => this.X * other.X + this.Y * other.Y + this.Z * other.Z;
    public Vector3D CrossProduct(Vector3D other) => new Vector3D(
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
