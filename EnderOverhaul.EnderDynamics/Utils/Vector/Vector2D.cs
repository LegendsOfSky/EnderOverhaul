using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector2D : IVector<Vector2D , double> ,
                         IAdditionOperators<Vector2D , Vector2D , Vector2D> ,
                         ISubtractionOperators<Vector2D , Vector2D , Vector2D> ,
                         IUnaryNegationOperators<Vector2D , Vector2D>
{
    public double X;
    public double Z;


    #region Implements IVector<Vector2D , double>
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

    public Vector2D CrossProduct()
    {
        throw new NotImplementedException();
    }

    public CompassDirection ToCompassDirection()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IAdditionOperators<Vector2D , Vector2D , Vector2D>
    public static Vector2D operator +(Vector2D left , Vector2D right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements ISubtractionOperators<Vector2D , Vector2D , Vector2D>
    public static Vector2D operator -(Vector2D left , Vector2D right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IUnaryNegationOperators<Vector2D , Vector2D>
    public static Vector2D operator -(Vector2D value)
    {
        throw new NotImplementedException();
    }
    #endregion
}
