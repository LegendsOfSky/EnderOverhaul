using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class ThrownEnderpearl : Entity , IEntityBuilder<ThrownEnderpearl>
{
    public ThrownEnderpearl()
    {

    }

    public ThrownEnderpearl(Vector3D position) : base(position) { }
    public ThrownEnderpearl(Vector3D position , Vector3D motion) : base(position , motion) { }



    #region Implements Entity
    /// <remarks> No argument is needed. </remarks>
    public override void Tick(params object[]? args)
    {
#if VERSION_1_12_ABOVE
        Position += Motion;
        Motion   *= 0.99F;
        Motion.Y -= 0.03F;
#elif VERSION_1_20_2_ABOVE
        Motion.Y -= 0.03D;
        Motion   *= 0.99F;
        Position += Motion;
#else
        throw new NotSupportedException()
#endif
    }

    public override Vector3D GetEyePos()
    {
        return new Vector3D(Position.X , Position.Y + (0.25D * 0.85F) , Position.Z);
    }
    #endregion

    public new ThrownEnderpearl WithPosition(double x , double y , double z) => WithPosition(new Vector3D(x , y , z));
    public new ThrownEnderpearl WithPosition(Vector3D position)
    {
        Position = position;
        return this;
    }

    public new ThrownEnderpearl WithMotion(double x , double y , double z) => WithMotion(new Vector3D(x , y , z));
    public new ThrownEnderpearl WithMotion(Vector3D motion)
    {
        Motion = motion;
        return this;
    }
}
