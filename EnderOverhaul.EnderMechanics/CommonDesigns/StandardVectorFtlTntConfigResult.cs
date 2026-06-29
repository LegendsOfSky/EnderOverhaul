using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public record StandardVectorFtlTntConfigResult
{
    public PrimedTnt ASideTnt;
    public PrimedTnt BSideTnt;
    public CompassDirections ASideTntLocation;
    public CompassDirections BSideTntLocation;
    public int ASideTntCount;
    public int BSideTntCount;
    public int TravellingTicks;
}
