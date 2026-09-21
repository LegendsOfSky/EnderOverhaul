using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public record SingleTntReturnFtlTntConfigResult
{
    public PrimedTnt Tnt;
    public int TntCount;
    public int TravellingTicks;
    public Vector2D Error;
}
