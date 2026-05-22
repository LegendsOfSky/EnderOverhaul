using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector3D : IVector<Vector3D , double> ,
                         IAdditionOperators<Vector3D , Vector3D , Vector3D> ,
                         ISubtractionOperators<Vector3D , Vector3D , Vector3D> ,
                         IUnaryNegationOperators<Vector3D , Vector3D>
{
    public double X;
    public double Y;
    public double Z;


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
        throw new NotImplementedException();
    }
    #endregion

    #region Implements ISubtractionOperators<Vector3D , Vector3D , Vector3D>
    public static Vector3D operator -(Vector3D left , Vector3D right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IUnaryNegationOperators<Vector3D , Vector3D>
    public static Vector3D operator -(Vector3D value)
    {
        throw new NotImplementedException();
    }
    #endregion
}
