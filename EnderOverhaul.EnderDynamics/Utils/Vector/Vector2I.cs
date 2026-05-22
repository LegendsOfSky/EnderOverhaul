using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector2I : IVector<Vector2I , int> ,
                         IAdditionOperators<Vector2I , Vector2I , Vector2I> ,
                         ISubtractionOperators<Vector2I , Vector2I , Vector2I> ,
                         IUnaryNegationOperators<Vector2I , Vector2I>
{
    public int X;
    public int Z;


    #region Implements IVector<Vector2I , int>
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

    public int MaxEntry()
    {
        throw new NotImplementedException();
    }

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
    #endregion

    #region Implements IAdditionOperators<Vector2I , Vector2I , Vector2I>
    public static Vector2I operator +(Vector2I left , Vector2I right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements ISubtractionOperators<Vector2I , Vector2I , Vector2I>
    public static Vector2I operator -(Vector2I left , Vector2I right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region IUnaryNegationOperators<Vector2I , Vector2I>
    public static Vector2I operator -(Vector2I value)
    {
        throw new NotImplementedException();
    }
    #endregion
}
