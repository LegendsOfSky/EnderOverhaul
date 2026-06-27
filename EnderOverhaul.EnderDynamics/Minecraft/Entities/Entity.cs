using System.Reflection;
using EnderOverhaul.EnderDynamics.Utils.Vector;
using EntityImpl = EnderOverhaul.EnderDynamics.Impl.Minecraft.Entities.Entity;
using Vector3DImpl = EnderOverhaul.EnderDynamics.Impl.Utils.Vector.Vector3D;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public abstract class Entity : IEntityBuilder<Entity>
{
    public Vector3D Position
    {
        get
        {
            object? implVec = s_PositionField.GetValue(ImplObj);
            return implVec is null ? throw new InvalidOperationException() : new Vector3D(implVec);
        }
        set => s_PositionField.SetValue(ImplObj, value?.ImplObj);
    }

    public Vector3D Motion
    {
        get
        {
            object? implVec = s_MotionField.GetValue(ImplObj);
            return implVec is null ? throw new InvalidOperationException() : new Vector3D(implVec);
        }
        set => s_MotionField.SetValue(ImplObj, value?.ImplObj);
    }

    internal object ImplObj;

    protected static MethodInfo s_TickMethod;
    protected static MethodInfo s_GetEyePosMethod;

    private static Type s_ImplType;
    private static FieldInfo s_PositionField;
    private static FieldInfo s_MotionField;
    private static MethodInfo s_WithPositionDouble3Method;
    private static MethodInfo s_WithPositionVectorMethod;
    private static MethodInfo s_WithMotionDouble3Method;
    private static MethodInfo s_WithMotionVectorMethod;


    static Entity()
    {
        _ = typeof(EnderDynamicsConfig);
        EnderDynamicsConfig.OnImplementationChangedEvent += TypeImplementationVersionChangedEventHandler;
        UpdateImplementationDetailsForType(EnderDynamicsConfig.S_ImplementationLibrary);
    }

    protected Entity()
    {
        // Subclasses must set ImplObj. Abstract cannot be instantiated directly.
        // Per-instance migration handled in concrete derived types.
    }

    protected Entity(object implObj)
    {
        ImplObj = implObj ?? throw new ArgumentNullException(nameof(implObj));
        // Per-instance migration handled in concrete derived types.
    }


    public abstract void Tick(params object[]? args);

    public abstract Vector3D GetEyePos();

    private static void TypeImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
        => UpdateImplementationDetailsForType(args.NewImplementation);

    private static void UpdateImplementationDetailsForType(Assembly newAssembly)
    {
        s_ImplType = newAssembly.GetType(typeof(EntityImpl).ToString())
            ?? throw new TypeLoadException("Cannot load Entity implementation type.");
        s_PositionField = s_ImplType.GetField("Position") ?? throw new TypeLoadException();
        s_MotionField = s_ImplType.GetField("Motion") ?? throw new TypeLoadException();

        Type runtimeVec3D = newAssembly.GetType(typeof(Vector3DImpl).ToString())
            ?? throw new TypeLoadException("Cannot load Vector3D implementation type for method lookup.");

        s_WithPositionDouble3Method = s_ImplType.GetMethod(
                "WithPosition" , BindingFlags.Public | BindingFlags.Instance , null , [typeof(double) , typeof(double) , typeof(double)] , null
            ) ?? throw new TypeLoadException();
        s_WithPositionVectorMethod = s_ImplType.GetMethod(
                "WithPosition" , BindingFlags.Public | BindingFlags.Instance , null , [runtimeVec3D] , null
            ) ?? throw new TypeLoadException();
        s_WithMotionDouble3Method = s_ImplType.GetMethod(
                "WithMotion" , BindingFlags.Public | BindingFlags.Instance , null , [typeof(double) , typeof(double) , typeof(double)] , null
            ) ?? throw new TypeLoadException();
        s_WithMotionVectorMethod = s_ImplType.GetMethod(
                "WithMotion" , BindingFlags.Public | BindingFlags.Instance , null , [runtimeVec3D] , null
            ) ?? throw new TypeLoadException();

        s_TickMethod = s_ImplType.GetMethod("Tick" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
        s_GetEyePosMethod = s_ImplType.GetMethod("GetEyePos" , BindingFlags.Public | BindingFlags.Instance) ?? throw new TypeLoadException();
    }

    private void ObjectImplementationVersionChangedEventHandler(object? sender , ImplementationChangedEventArgs args)
    {
        Type currentImplType = ImplObj.GetType();
        Type newImplType = args.NewImplementation.GetType(typeof(EntityImpl).ToString())
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
        object newPosition = Activator.CreateInstance(newVecType , positionX , positionY , positionZ) ?? throw new InvalidOperationException();
        object newMotion = Activator.CreateInstance(newVecType , motionX , motionY , motionZ) ?? throw new InvalidOperationException();

        if (!newImplType.IsAbstract)
        {
            ImplObj = Activator.CreateInstance(newImplType) ?? throw new InvalidOperationException();
            newImplType.GetField("Position")!.SetValue(ImplObj , newPosition);
            newImplType.GetField("Motion")!.SetValue(ImplObj , newMotion);
        }
        // If abstract, derived wrapper's override is responsible for setting the correct concrete ImplObj.
    }


    #region Implements IEntityBuilder<Entity>
    public Entity WithPosition(double x, double y, double z) => WithPosition(new Vector3D(x, y, z));
    public Entity WithPosition(Vector3D position)
    {
        Position = position;
        return this;
    }

    public Entity WithMotion(double x, double y, double z) => WithMotion(new Vector3D(x, y, z));
    public Entity WithMotion(Vector3D motion)
    {
        Motion = motion;
        return this;
    }
    #endregion


    ~Entity()
    {
        EnderDynamicsConfig.OnImplementationChangedEvent -= ObjectImplementationVersionChangedEventHandler;
    }
}
