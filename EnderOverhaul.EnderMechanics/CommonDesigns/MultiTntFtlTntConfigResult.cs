using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public record MultiTntFtlTntConfigResult
{
    public Dictionary<PrimedTnt , int> TntConfig;
    public int TravellingTicks;
    public Vector2D Error;
}
