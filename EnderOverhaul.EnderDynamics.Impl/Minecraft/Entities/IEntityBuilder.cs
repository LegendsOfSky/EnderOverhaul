using EnderOverhaul.EnderDynamics.Impl.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities;


public interface IEntityBuilder<out T> where T : Entity
{
    public T WithPosition(double x , double y , double z);
    public T WithPosition(Vector3D position);

    public T WithMotion(double x , double y , double z);
    public T WithMotion(Vector3D motion);
}
