using EnderOverhaul.EnderDynamics;
using EnderOverhaul.EnderDynamics.Utils;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Test.Utils;

[Collection("IVector Tests")]
/// <summary>
/// Tests for the IVector contract on the wrapper vector types (EnderDynamics).
/// These exercise the reflection-based delegation to the underlying implementation.
/// </summary>
public class VectorTest
{
    private static bool _configInitialized;

    public VectorTest()
    {
        // Ensure an implementation is loaded. Do it only once to avoid
        // repeated ImplementationChanged events + reflection type mismatches
        // during a single test process run.
        if (!_configInitialized)
        {
            EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
            _configInitialized = true;
        }
    }

    #region Length
    [Theory]
    [InlineData(0, 0)]
    [InlineData(3, 4)]
    [InlineData(-3, 4)]
    [InlineData(5, 12)]
    public void TestVector2DLength(double x, double z)
    {
        double expected = Math.Sqrt(x * x + z * z);
        IVector<Vector2D, double> v = new Vector2D(x, z);
        Assert.Equal(expected, v.Length);
        Assert.Equal(expected, new Vector2D(x, z).Length);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(3, 4)]
    [InlineData(-5, 12)]
    public void TestVector2ILength(int x, int z)
    {
        double expected = Math.Sqrt(x * x + z * z);
        IVector<Vector2I, int> v = new Vector2I(x, z);
        Assert.Equal(expected, v.Length);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 2)]
    [InlineData(3, 4, 12)]
    public void TestVector3DLength(double x, double y, double z)
    {
        double expected = Math.Sqrt(x * x + y * y + z * z);
        IVector<Vector3D, double> v = new Vector3D(x, y, z);
        Assert.Equal(expected, v.Length);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(3, 4, 12)]
    public void TestVector3ILength(int x, int y, int z)
    {
        double expected = Math.Sqrt(x * x + y * y + z * z);
        IVector<Vector3I, int> v = new Vector3I(x, y, z);
        Assert.Equal(expected, v.Length);
    }
    #endregion

    #region Max / Min Entry
    [Theory]
    [InlineData(1, 2)]
    [InlineData(-5, 3)]
    [InlineData(0, 0)]
    public void TestVector2DMaxMinEntry(double x, double z)
    {
        var vec = new Vector2D(x, z);
        Assert.Equal(Math.Max(x, z), vec.MaxEntry);
        Assert.Equal(Math.Min(x, z), vec.MinEntry);
    }

    [Theory]
    [InlineData(10, -4)]
    public void TestVector2IMaxMinEntry(int x, int z)
    {
        IVector<Vector2I, int> vec = new Vector2I(x, z);
        Assert.Equal(Math.Max(x, z), vec.MaxEntry);
        Assert.Equal(Math.Min(x, z), vec.MinEntry);
    }

    [Theory]
    [InlineData(1, 5, 3)]
    [InlineData(-2, 0, -10)]
    public void TestVector3DMaxMinEntry(double x, double y, double z)
    {
        var vec = new Vector3D(x, y, z);
        double[] vals = { x, y, z };
        Assert.Equal(vals.Max(), vec.MaxEntry);
        Assert.Equal(vals.Min(), vec.MinEntry);
    }

    [Theory]
    [InlineData(7, 1, -3)]
    public void TestVector3IMaxMinEntry(int x, int y, int z)
    {
        IVector<Vector3I, int> vec = new Vector3I(x, y, z);
        int[] vals = { x, y, z };
        Assert.Equal(vals.Max(), vec.MaxEntry);
        Assert.Equal(vals.Min(), vec.MinEntry);
    }
    #endregion

    #region GetDominantEntry
    [Theory]
    [InlineData(5, 3, 5)]
    [InlineData(3, 5, 5)]
    [InlineData(-10, 2, -10)]
    [InlineData(1, -4, -4)]
    public void TestVector2DGetDominantEntry(double x, double z, double expected)
    {
        var vec = new Vector2D(x, z);
        Assert.Equal(expected, vec.GetDominantEntry());
    }

    [Theory]
    [InlineData(5, 3, 5)]
    [InlineData(-1, -10, -10)]
    public void TestVector2IGetDominantEntry(int x, int z, int expected)
    {
        IVector<Vector2I, int> vec = new Vector2I(x, z);
        Assert.Equal(expected, vec.GetDominantEntry());
    }

    [Theory]
    [InlineData(5, 1, 2, 5)]
    [InlineData(1, 8, 3, 8)]
    [InlineData(2, 3, 9, 9)]
    [InlineData(-4, -1, -2, -4)]
    public void TestVector3DGetDominantEntry(double x, double y, double z, double expected)
    {
        var vec = new Vector3D(x, y, z);
        Assert.Equal(expected, vec.GetDominantEntry());
    }

    [Theory]
    [InlineData(1, 10, 2, 10)]
    [InlineData(5, 5, 10, 10)]
    public void TestVector3IGetDominantEntry(int x, int y, int z, int expected)
    {
        IVector<Vector3I, int> vec = new Vector3I(x, y, z);
        Assert.Equal(expected, vec.GetDominantEntry());
    }
    #endregion

    #region ComputeDotProductWith
    [Theory]
    [InlineData(1, 2, 3, 4, 11)]      // 1*3 + 2*4
    [InlineData(0, 0, 5, 6, 0)]
    [InlineData(-1, 4, 2, -3, -14)]
    public void TestVector2DDotProduct(double x1, double z1, double x2, double z2, double expected)
    {
        var a = new Vector2D(x1, z1);
        var b = new Vector2D(x2, z2);
        Assert.Equal(expected, a.ComputeDotProductWith(b));
        Assert.Equal(expected, ((IVector<Vector2D, double>)a).ComputeDotProductWith(b));
    }

    [Theory]
    [InlineData(2, 3, 4, 5, 23)]
    public void TestVector2IDotProduct(int x1, int z1, int x2, int z2, int expected)
    {
        IVector<Vector2I, int> a = new Vector2I(x1, z1);
        var b = new Vector2I(x2, z2);
        Assert.Equal(expected, a.ComputeDotProductWith(b));
    }

    [Theory]
    [InlineData(1, 2, 3, 1, 2, 3, 14)]
    [InlineData(1, 0, 0, 0, 1, 0, 0)]
    public void TestVector3DDotProduct(double x1, double y1, double z1, double x2, double y2, double z2, double expected)
    {
        var a = new Vector3D(x1, y1, z1);
        var b = new Vector3D(x2, y2, z2);
        Assert.Equal(expected, a.ComputeDotProductWith(b));
    }

    [Theory]
    [InlineData(1, 1, 1, 2, 3, 4, 9)]
    public void TestVector3IDotProduct(int x1, int y1, int z1, int x2, int y2, int z2, int expected)
    {
        IVector<Vector3I, int> a = new Vector3I(x1, y1, z1);
        var b = new Vector3I(x2, y2, z2);
        Assert.Equal(expected, a.ComputeDotProductWith(b));
    }
    #endregion

    #region Cardinal Directions
    [Theory]
    [InlineData(1, 0, CompassDirection.East)]
    [InlineData(0, 1, CompassDirection.South)]
    [InlineData(-5, 0, CompassDirection.West)]
    [InlineData(0, -3, CompassDirection.North)]
    [InlineData(10, 1, CompassDirection.East)]   // |X| > |Z|
    [InlineData(1, 10, CompassDirection.South)]  // |X| < |Z|
    [InlineData(5, 5, CompassDirection.South)]   // equal -> vertical
    public void TestVector2DToCardinalCompassDirection(double x, double z, CompassDirection expected)
    {
        var vec = new Vector2D(x, z);
        Assert.Equal(expected, vec.ToCardinalCompassDirection());
        Assert.Equal(expected, ((IVector<Vector2D, double>)vec).ToCardinalCompassDirection());
    }

    [Theory]
    [InlineData(-2, 0, CompassDirection.West)]
    [InlineData(0, 7, CompassDirection.South)]
    public void TestVector2IToCardinalCompassDirection(int x, int z, CompassDirection expected)
    {
        IVector<Vector2I, int> vec = new Vector2I(x, z);
        Assert.Equal(expected, vec.ToCardinalCompassDirection());
    }

    [Theory]
    [InlineData(0, 100, 1, CompassDirection.South)]
    [InlineData(0, 0, -1, CompassDirection.North)]
    public void TestVector3DToCardinalCompassDirection(double x, double y, double z, CompassDirection expected)
    {
        var vec = new Vector3D(x, y, z);
        Assert.Equal(expected, vec.ToCardinalCompassDirection());
    }

    [Theory]
    [InlineData(99, 0, -1, CompassDirection.East)]
    public void TestVector3IToCardinalCompassDirection(int x, int y, int z, CompassDirection expected)
    {
        IVector<Vector3I, int> vec = new Vector3I(x, y, z);
        Assert.Equal(expected, vec.ToCardinalCompassDirection());
    }
    #endregion

    #region IsNorth / IsSouth / IsWest / IsEast
    [Theory]
    [InlineData(0, -1, true, false, false, false)]
    [InlineData(0, 1, false, true, false, false)]
    [InlineData(-2, 0, false, false, true, false)]
    [InlineData(3, 0, false, false, false, true)]
    [InlineData(1, -1, true, false, false, true)]   // |Z|==|X|, Z<0 → N, X>0 and |X|>=|Z| → E
    public void TestVector2DCardinalFlags(double x, double z, bool n, bool s, bool w, bool e)
    {
        var vec = new Vector2D(x, z);
        Assert.Equal(n, vec.IsNorth());
        Assert.Equal(s, vec.IsSouth());
        Assert.Equal(w, vec.IsWest());
        Assert.Equal(e, vec.IsEast());
    }

    [Theory]
    [InlineData(-1, -1, true, false, true, false)]  // Z<0 → N, X<0 → W
    [InlineData(1, 0, false, false, false, true)]
    public void TestVector2ICardinalFlags(int x, int z, bool n, bool s, bool w, bool e)
    {
        var vec = new Vector2I(x, z);
        Assert.Equal(n, vec.IsNorth());
        Assert.Equal(s, vec.IsSouth());
        Assert.Equal(w, vec.IsWest());
        Assert.Equal(e, vec.IsEast());
    }

    [Theory]
    [InlineData(0, 5, -3, true, false, false, false)]
    [InlineData(4, 99, 0, false, false, false, true)]
    public void TestVector3DCardinalFlags(double x, double y, double z, bool n, bool s, bool w, bool e)
    {
        IVector<Vector3D, double> vec = new Vector3D(x, y, z);
        Assert.Equal(n, vec.IsNorth());
        Assert.Equal(s, vec.IsSouth());
        Assert.Equal(w, vec.IsWest());
        Assert.Equal(e, vec.IsEast());
    }

    [Theory]
    [InlineData(-5, 0, 2, false, false, true, false)]
    public void TestVector3ICardinalFlags(int x, int y, int z, bool n, bool s, bool w, bool e)
    {
        var vec = new Vector3I(x, y, z);
        Assert.Equal(n, vec.IsNorth());
        Assert.Equal(s, vec.IsSouth());
        Assert.Equal(w, vec.IsWest());
        Assert.Equal(e, vec.IsEast());
    }
    #endregion

    #region World Angles
    [Theory]
    [InlineData(1, 0, -90)]
    [InlineData(-1, 0, 90)]
    [InlineData(0, 1, 0)]
    [InlineData(0, -1, -180)]
    [InlineData(1, 1, -45)]
    public void TestVectorHorizontalWorldAngle(double x, double z, double expected)
    {
        Assert.Equal(expected, new Vector2D(x, z).ToHorizontalWorldAngle());
        Assert.Equal(expected, new Vector2I((int)x, (int)z).ToHorizontalWorldAngle());
        Assert.Equal(expected, new Vector3D(x, 0, z).ToHorizontalWorldAngle());
        Assert.Equal(expected, new Vector3I((int)x, 0, (int)z).ToHorizontalWorldAngle());
    }

    [Theory]
    [InlineData(0, 1, 0, 90)]      // straight up
    [InlineData(0, -1, 0, -90)]    // straight down
    [InlineData(0, 1, 1, 45)]      // 45 deg (horizontal mag = y)
    [InlineData(0, 0, 1, 0)]
    public void TestVectorVerticalWorldAngle(double x, double y, double z, double expected)
    {
        // 2D vectors always return 0 for vertical
        Assert.Equal(0, new Vector2D(x, z).ToVerticalWorldAngle());
        Assert.Equal(0, new Vector2I((int)x, (int)z).ToVerticalWorldAngle());

        Assert.Equal(expected, new Vector3D(x, y, z).ToVerticalWorldAngle());
        Assert.Equal(expected, new Vector3I((int)x, (int)y, (int)z).ToVerticalWorldAngle());
    }
    #endregion
}
