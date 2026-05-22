using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace EnderOverhaul.EnderDynamics.Utils.Vector;


public struct Vector3I : IVector<Vector3I , int> ,
                         IAdditionOperators<Vector3I , Vector3I , Vector3I> ,
                         ISubtractionOperators<Vector3I , Vector3I , Vector3I> ,
                         IUnaryNegationOperators<Vector3I , Vector3I>
{
    public int X;
    public int Y;
    public int Z;


    #region Implements IVector<Vector3I , int>
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

    public Vector3I CrossProduct()
    {
        throw new NotImplementedException();
    }

    public CompassDirection ToCompassDirection()
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IAdditionOperators<Vector3I , Vector3I , Vector3I>
    public static Vector3I operator +(Vector3I left , Vector3I right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements ISubtractionOperators<Vector3I , Vector3I , Vector3I>
    public static Vector3I operator -(Vector3I left , Vector3I right)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Implements IUnaryNegationOperators<Vector3I , Vector3I>
    public static Vector3I operator -(Vector3I value)
    {
        throw new NotImplementedException();
    }
    #endregion
}
