using EnderOverhaul.EnderDynamics.Utils.Vector;

namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public abstract class Entity
{
    public Vector3D Position;
    public Vector3D Motion;



    protected Entity()
    {

    }

    protected Entity(Vector3D position)
    {
        Position = position;
    }

    protected Entity(Vector3D position , Vector3D motion)
    {
        Position = position;
        Motion = motion;
    }



    public abstract void Tick(params object[]? args);
}
