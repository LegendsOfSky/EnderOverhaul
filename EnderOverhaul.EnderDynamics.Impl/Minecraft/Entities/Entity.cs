using EnderOverhaul.EnderDynamics.Impl.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities;


public abstract class Entity : IEntityBuilder<Entity>
{
    public Vector3D Position;
    public Vector3D Motion;


    protected Entity() : this(new Vector3D() , new Vector3D()) { }

    protected Entity(Vector3D position) : this(position , new Vector3D()) { }

    protected Entity(Vector3D position , Vector3D motion)
    {
        Position = position;
        Motion = motion;
    }


    public abstract Entity DeepCopy();

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
