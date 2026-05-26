using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace EnderOverhaul.EnderDynamics.Utils.Vector;


// @formatter:off
internal interface IVector<TVector , out TValue>
    where TVector : IAdditionOperators<TVector , TVector , TVector> ,
                    ISubtractionOperators<TVector , TVector , TVector> ,
                    IMultiplyOperators<TVector , TValue , TVector> ,
                    IUnaryNegationOperators<TVector , TVector> ,
                    IEquatable<TVector> , IEqualityOperators<TVector , TVector , bool>
    // @formatter:on
{
    public double Length();

    public bool IsNorth();
    public bool IsSouth();
    public bool IsWest();
    public bool IsEast();

    public TValue MaxEntry();
    public TValue MinEntry();

    public TValue DotProduct(TVector other);

    public CompassDirection ToCardinalCompassDirection();

    public double ToHorizontalWorldAngle();
    public double ToVerticalWorldAngle();
}
