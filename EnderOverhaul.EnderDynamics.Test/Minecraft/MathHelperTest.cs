using EnderOverhaul.EnderDynamics;
using EnderOverhaul.EnderDynamics.Minecraft;


namespace EnderOverhaul.EnderDynamics.Test.Minecraft;

[Collection("MathHelper Tests")]
public class MathHelperTest
{
    public MathHelperTest()
    {
        // Ensure an implementation is active
        EnderDynamicsConfig.TrySetMinecraftVersion("1.12.2");
    }

    [Fact]
    public void Sqrt_Works()
    {
        Assert.Equal(4f, MathHelper.Sqrt(16));
        Assert.Equal(0f, MathHelper.Sqrt(0));
        Assert.True(MathHelper.Sqrt(2) > 1.4f && MathHelper.Sqrt(2) < 1.5f);
    }

    [Fact]
    public void DegreeRadiant_Conversions_AreInverses()
    {
        double deg = 45.0;
        double rad = MathHelper.DegreeToRadiant(deg);
        double back = MathHelper.RadiantToDegree(rad);
        Assert.True(Math.Abs(back - deg) < 1e-10);
    }

    [Fact]
    public void IsInside_Works()
    {
        Assert.True(MathHelper.IsInside(1, 10, 5));
        Assert.True(MathHelper.IsInside(10, 1, 5));
        Assert.False(MathHelper.IsInside(1, 10, 0));
        Assert.False(MathHelper.IsInside(1, 10, 11));
        Assert.True(MathHelper.IsInside(5, 5, 5));
    }

    [Fact]
    public void Works_After_Version_Switch()
    {
        EnderDynamicsConfig.TrySetMinecraftVersion("1.21.1");
        Assert.Equal(1.4142135f, MathHelper.Sqrt(2), 1e-6f);
        Assert.True(MathHelper.IsInside(0, 1, 0.5));
    }
}
