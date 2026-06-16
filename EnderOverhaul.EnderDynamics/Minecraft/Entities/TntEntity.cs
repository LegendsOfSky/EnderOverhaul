using System.Diagnostics;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class TntEntity : Entity , IEntityBuilder<TntEntity>
{
    private Random rng = new Random();

    public TntEntity()
    {

    }

    public TntEntity(Vector3D position) : base(position) { }
    public TntEntity(Vector3D position , Vector3D motion) : base(position , motion) { }


    public void AccelerateEntity(Entity entity , float explosionPower = 4.0F)
    {
#if VERSION_1_12_ABOVE || VERSION_1_20_2_ABOVE
        Vector3D centerOfExplosion = new Vector3D(Position.X , Position.Y + 0.98F * 0.0625D , Position.Z);  // assume center of explosion is correct

        double ratioOfDistanceToDiameter = (entity.Position - centerOfExplosion).Length() / (explosionPower * 2.0F);
        if (ratioOfDistanceToDiameter > 1.0D)
            return;

        Vector3D distance          = (entity is TntEntity ? entity.Position : entity.GetEyePos()) - centerOfExplosion;
        double   euclideanDistance = distance.Length();
        if (euclideanDistance == 0.0D)
            return;

        distance.X /= euclideanDistance;
        distance.Y /= euclideanDistance;
        distance.Z /= euclideanDistance;

        /* Compute seenPercent */
        float seenPercent = GetSeenPercent(entity);

        /* Damage entity */
        //    maybe a future feature.

        /* Compute knockback multiplier */
        float  knockbackBaseMultiplier         = 1.0F;
        double dampingCoefficient              = 1.0D;
        double knockbackIntermediateMultiplier = (1.0D - ratioOfDistanceToDiameter) * (double)seenPercent * (double)knockbackBaseMultiplier;
        double knockbackEffectiveMultiplier = entity is ILivingEntity livingEntity
            ? knockbackIntermediateMultiplier * dampingCoefficient
            : knockbackIntermediateMultiplier;

        Vector3D motion = distance * knockbackEffectiveMultiplier;
        entity.Motion += motion;
#else
        throw new NotSupportedException();
#endif
    }


    private float GetSeenPercent(Entity other)
    {
        return 1.0F;
    }

    private float GetKnockbackMultiplier()
    {
        return 1.0F;
    }


    public void ApplyRandomPrimeMovement()
    {
        double angle = rng.NextDouble() * ((float)Math.PI * 2F);
        Motion = new Vector3D(-Math.Sin(angle) * 0.02D , 0.2F , -Math.Cos(angle) * 0.02D);
    }


    #region Implements Entity
    /// <param name="args">
    ///     You must exactly provide all required arguments.
    ///     <list type="table">
    ///         <listheader>
    ///             <term> Variable Name </term>
    ///             <term> Variable Type </term>
    ///             <term> Description </term>
    ///         </listheader>
    ///
    ///         <item>
    ///             <term> onGroundArg </term>
    ///             <term> <seealso cref="bool"/> </term>
    ///             <term> whether the ender pearl is on top of the ground. </term>
    ///         </item>
    ///     </list>
    /// </param>
    public override void Tick(params object[]? args)
    {
        const int argCount = 1;

        #region Handle tick args
        if (args?.Length != argCount)
            return;

        bool isNoGravity = false;
        if (args[0] is not bool onGroundArg)
            return;
        isNoGravity |= onGroundArg;
        #endregion


#if VERSION_1_12_ABOVE || VERSION_1_20_2_ABOVE
        if (!isNoGravity)
            Motion.Y -= 0.04D;

        Position += Motion;
        Motion   *= 0.98D;

        if (onGroundArg)
        {
            Motion.X *=  0.7D;
            Motion.Y *= -0.5D;
            Motion.Z *=  0.7D;
        }
#else
        throw new NotSupportedException();
#endif
    }

    public override Vector3D GetEyePos()
    {
        throw new NotSupportedException();
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
}
