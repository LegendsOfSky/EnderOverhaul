using System.Reflection;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using PrimedTntImpl = EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities.PrimedTnt;
using EntityImpl = EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities.Entity;
using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class PrimedTnt : Entity , IEntityBuilder<PrimedTnt>
{
    private static Type s_ImplType;
    private static MethodInfo s_AccelerateEntityMethod;
    private static MethodInfo s_ApplyRandomPrimeMovementMethod;
    private static MethodInfo s_DeepCopyMethod;


    static PrimedTnt()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    public PrimedTnt()
    {
        ImplObj = Activator.CreateInstance(s_ImplType) ?? throw new InvalidOperationException();
        EnderDynamicsConfig.OnImplementationChangedEvent += ObjectImplementationVersionChangedEventHandler;
    }

    public PrimedTnt(Vector3D position) : this()
    {
        Position = position;
        Motion = new Vector3D();
    }

    public PrimedTnt(Vector3D position , Vector3D motion) : this()
    {
        Position = position;
        Motion = motion;
    }

    internal PrimedTnt(object implObj) : base(implObj) { }


    public void AccelerateEntity(Entity entity , float explosionPower = 4.0F , int tntCount = 1)
    {
        object? targetImpl = entity?.ImplObj;
        s_AccelerateEntityMethod.Invoke(ImplObj , [targetImpl , explosionPower , tntCount]);
    }

    public PrimedTnt ApplyRandomPrimeMovement()
    {
        s_ApplyRandomPrimeMovementMethod.Invoke(ImplObj , null);
        return this;
    }

    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(PrimedTntImpl).ToString())
            ?? throw new TypeLoadException("Cannot load PrimedTnt implementation type.");

        s_AccelerateEntityMethod = s_ImplType.GetMethod(  // Find the accelerate method. Signature: void AccelerateEntity(Entity, float)
                    "AccelerateEntity" , BindingFlags.Public | BindingFlags.Instance , null ,
                    [typeof(EntityImpl) , typeof(float) , typeof(int)] , null
                )
            ?? s_ImplType.GetMethod("AccelerateEntity" , BindingFlags.Public | BindingFlags.Instance)
            ?? throw new TypeLoadException();
        s_ApplyRandomPrimeMovementMethod = s_ImplType.GetMethod("ApplyRandomPrimeMovement" , BindingFlags.Public | BindingFlags.Instance)
            ?? throw new TypeLoadException();
        s_DeepCopyMethod = s_ImplType.GetMethod("DeepCopy" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplType = args.NewImplementation.GetType(typeof(PrimedTntImpl).ToString())
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
    public override PrimedTnt DeepCopy()
    {
        return new PrimedTnt(s_DeepCopyMethod.Invoke(ImplObj , null)!);
    }

    /// <inheritdoc cref="PrimedTntImpl.Tick"/>
    public override void Tick(params object[]? args) => s_TickMethod.Invoke(ImplObj , [args]);

    public override Vector3D GetEyePos()
    {
        object? result = s_GetEyePosMethod.Invoke(ImplObj , null);
        return result is null ? throw new InvalidOperationException() : new Vector3D(result);
    }
    #endregion

    #region implements IEntityBuilder<PrimedTnt>
    public new PrimedTnt WithPosition(double x , double y , double z) => WithPosition(new Vector3D(x , y , z));
    public new PrimedTnt WithPosition(Vector3D position)
    {
        Position = position;
        return this;
    }

    public new PrimedTnt WithMotion(double x , double y , double z) => WithMotion(new Vector3D(x , y , z));
    public new PrimedTnt WithMotion(Vector3D motion)
    {
        Motion = motion;
        return this;
    }
    #endregion


    ~PrimedTnt()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
