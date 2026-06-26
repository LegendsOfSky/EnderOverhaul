using System.Numerics;


namespace EnderOverhaul.EnderDynamics.Impl.Utils.Vector;


// @formatter:off
public interface IVector<in TVector , out TValue>
    where TVector : IAdditionOperators<TVector , TVector , TVector> ,
                    ISubtractionOperators<TVector , TVector , TVector> ,
                    IMultiplyOperators<TVector , TValue , TVector> ,
                    IUnaryNegationOperators<TVector , TVector> ,
                    IEquatable<TVector> , IEqualityOperators<TVector , TVector , bool>
// @formatter:on
{
    public double Length   { get; }
    public TValue MaxEntry { get; }
    public TValue MinEntry { get; }


    public TValue GetDominantEntry();

    public TValue ComputeDotProductWith(TVector other);

    public bool IsNorth();
    public bool IsSouth();
    public bool IsWest();
    public bool IsEast();

    public CompassDirections ToCardinalCompassDirection();

    public double ToHorizontalWorldAngle();
    public double ToVerticalWorldAngle();
}
