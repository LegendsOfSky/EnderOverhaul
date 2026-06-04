using System.Diagnostics;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class TntEntity : Entity
{
    public TntEntity()
    {

    }

    public TntEntity(Vector3D position) : base(position) { }
    public TntEntity(Vector3D position , Vector3D motion) : base(position , motion) { }



    public void AccelerateEntity(Entity entity)
    {
        switch (entity)
        {
            case EnderPearlEntity enderPearl:
                throw new NotImplementedException();

            case TntEntity tnt:
                throw new NotImplementedException();


            default:
                throw new UnreachableException();
        }
    }


    public void GenerateRandomPrimeMovement()
    {
        throw new NotImplementedException();
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


#if VERSION_1_12_ABOVE
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
        throw new NotImplementedException();
#endif
    }
    #endregion
}
