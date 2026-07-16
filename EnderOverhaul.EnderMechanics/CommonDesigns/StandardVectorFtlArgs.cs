using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EnderOverhaul.EnderMechanics.Misc;


namespace EnderOverhaul.EnderMechanics.CommonDesigns;

public record StandardVectorFtlArgs
{
    public ThrownEnderpearl EnderPearl;
    public Vector2D Destination;

    /// <summary> (-, -) </summary>
    public PrimedTnt NorthWestTnt;
    /// <summary> (+, -) </summary>
    public PrimedTnt NorthEastTnt;
    /// <summary> (-, +) </summary>
    public PrimedTnt SouthWestTnt;
    /// <summary> (+, +) </summary>
    public PrimedTnt SouthEastTnt;
    
    public ABSide NorthWestTntSide;
    public ABSide NorthEastTntSide;
    public ABSide SouthWestTntSide;
    public ABSide SouthEastTntSide;

    public int NorthWestTntCount;
    public int NorthEastTntCount;
    public int SouthWestTntCount;
    public int SouthEastTntCount;

    public int MaxTntForOneSide;
}
