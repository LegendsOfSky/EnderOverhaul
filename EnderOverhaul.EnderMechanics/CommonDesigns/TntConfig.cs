using EnderOverhaul.EnderDynamics.Minecraft.Entities;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public record TntConfig
{
    public PrimedTnt Tnt;
    public int MaxTntCount;
    /// <summary> Specified which group the TNT belongs to. Only one set of TNT can be applied in each group. </summary>
    public int GroupID;
}
