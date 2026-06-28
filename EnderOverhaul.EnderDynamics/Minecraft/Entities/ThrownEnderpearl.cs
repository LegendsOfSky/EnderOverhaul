using System.Reflection;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using ThrownEnderpearlImpl = EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities.ThrownEnderpearl;
using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class ThrownEnderpearl : Entity , IEntityBuilder<ThrownEnderpearl>
{
    private static Type s_ImplType;


    static ThrownEnderpearl()
    {
        // Ensure base statics are initialized too via base static ctor side effect.
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    public ThrownEnderpearl()
    {
        ImplObj = Activator.CreateInstance(s_ImplType) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    public ThrownEnderpearl(Vector3D position) : this()
    {
        Position = position;
    }

    public ThrownEnderpearl(Vector3D position , Vector3D motion) : this()
    {
        Position = position;
        Motion = motion;
    }

    internal ThrownEnderpearl(object implObj) : base(implObj)
    {

    }


    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(ThrownEnderpearlImpl).ToString())
            ?? throw new TypeLoadException("Cannot load ThrownEnderpearl implementation type.");
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplType = args.NewImplementation.GetType(typeof(ThrownEnderpearlImpl).ToString())
            ?? throw new TypeLoadException();

        /* Extract current state using old type details (vectors are value structs) */
        FieldInfo currentPositionField = currentImplType.GetField("Position") ?? throw new TypeLoadException();
        object position = currentPositionField.GetValue(ImplObj)!;
        FieldInfo currentMotionField = currentImplType.GetField("Motion"  ) ?? throw new TypeLoadException();
        object motion = currentMotionField.GetValue(ImplObj)!;
        Type oldVectorType = position.GetType();
        FieldInfo oldVectorXField = oldVectorType.GetField("X") ?? throw new TypeLoadException();
        FieldInfo oldVectorYField = oldVectorType.GetField("Y") ?? throw new TypeLoadException();
        FieldInfo oldVectorZField = oldVectorType.GetField("Z") ?? throw new TypeLoadException();
        double positionX = (double)(oldVectorXField.GetValue(position) ?? 0D);
        double positionY = (double)(oldVectorYField.GetValue(position) ?? 0D);
        double positionZ = (double)(oldVectorZField.GetValue(position) ?? 0D);
        double motionX = (double)(oldVectorXField.GetValue(motion) ?? 0D);
        double motionY = (double)(oldVectorYField.GetValue(motion) ?? 0D);
        double motionZ = (double)(oldVectorZField.GetValue(motion) ?? 0D);

        Type newVecType = args.NewImplementation.GetType(typeof(Vector3DImpl).ToString())
            ?? throw new TypeLoadException();
        ImplObj = Activator.CreateInstance(newImplType) ?? throw new InvalidOperationException();
        object newPosition = Activator.CreateInstance(newVecType , positionX , positionY , positionZ) ?? throw new InvalidOperationException();
        object newMotion = Activator.CreateInstance(newVecType , motionX , motionY , motionZ) ?? throw new InvalidOperationException();
        newImplType.GetField("Position")!.SetValue(ImplObj , newPosition);
        newImplType.GetField("Motion")!.SetValue(ImplObj , newMotion);
    }


    #region Implements Entity
    public override void Tick(params object[]? args) => s_TickMethod.Invoke(ImplObj , [args]);

    public override Vector3D GetEyePos()
    {
        object? res = s_GetEyePosMethod.Invoke(ImplObj , null);
        return res is null ? throw new InvalidOperationException() : new Vector3D(res);
    }
    #endregion

    #region Implements IEntityBuilder<ThrownEnderpearl>
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
    #endregion


    ~ThrownEnderpearl()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
