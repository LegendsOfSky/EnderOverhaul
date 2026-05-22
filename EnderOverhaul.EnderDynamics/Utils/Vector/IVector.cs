using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace EnderOverhaul.EnderDynamics.Utils.Vector;


// @formatter:off
internal interface IVector<TVector , out TValue>
    where TVector : IAdditionOperators<TVector , TVector , TVector> ,
                    ISubtractionOperators<TVector , TVector , TVector> ,
                    IUnaryNegationOperators<TVector , TVector>
// @formatter:on
{
    public double Length();

    public bool IsNorth();
    public bool IsSouth();
    public bool IsWest();
    public bool IsEast();

    public TValue MaxEntry();

    public TValue DotProduct();
    public TVector CrossProduct();

    public CompassDirection ToCompassDirection();
}
