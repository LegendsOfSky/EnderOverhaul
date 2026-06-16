using EnderOverhaul.EnderDynamics.Utils.Vector;

namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public abstract class Entity : IEntityBuilder<Entity>
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

    public abstract Vector3D GetEyePos();


    #region Implements IEntityBuilder<Entity>
    public Entity WithPosition(double x , double y , double z) => WithPosition(new Vector3D(x , y , z));
    public Entity WithPosition(Vector3D position)
    {
        Position = position;
        return this;
    }

    public Entity WithMotion(double x , double y , double z) => WithMotion(new Vector3D(x , y , z));
    public Entity WithMotion(Vector3D motion)
    {
        Motion = motion;
        return this;
    }
    #endregion
}
