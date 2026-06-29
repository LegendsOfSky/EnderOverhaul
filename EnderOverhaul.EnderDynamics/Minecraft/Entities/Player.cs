using System.Diagnostics;
using System.Reflection;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using PlayerImpl = EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities.Player;
using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class Player : Entity , ILivingEntity
{
    public Pose Posture
    {
        get => (Pose)(s_PostureField.GetValue(ImplObj) ?? Pose.DEFAULT);
        set => s_PostureField.SetValue(ImplObj , value);
    }

    private static Type s_ImplType;
    private static FieldInfo s_PostureField;
    private static MethodInfo s_DeepCopyMethod;


    static Player()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    public Player()
    {
        ImplObj = Activator.CreateInstance(s_ImplType) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    internal Player(object implObj) : base(implObj)
    {

    }


    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(PlayerImpl).ToString())
            ?? throw new TypeLoadException("Cannot load Player implementation type.");
        s_PostureField = s_ImplType.GetField("Posture") ?? throw new TypeLoadException();
        s_DeepCopyMethod = s_ImplType.GetMethod("DeepCopy" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplType = args.NewImplementation.GetType(typeof(PlayerImpl).ToString())
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
    public override Player DeepCopy()
    {
        return new Player(s_DeepCopyMethod.Invoke(ImplObj , null)!);
    }

    public override void Tick(params object[]? args)
    {
        s_TickMethod.Invoke(ImplObj , [args]);
    }

    public override Vector3D GetEyePos()
    {
        object? res = s_GetEyePosMethod.Invoke(ImplObj , null);
        return res is null ? throw new InvalidOperationException() : new Vector3D(res);
    }
    #endregion


    ~Player()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }


    public enum Pose
    {
        DEFAULT,
        SWIMMING,
        FALL_FLYING,
        SPIN_ATTACK,
        CROUCHING,
    }
}
