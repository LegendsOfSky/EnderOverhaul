using System;
using System.Collections.Generic;
using System.Text;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class EnderPearlEntity : Entity
{
    public EnderPearlEntity()
    {

    }

    public EnderPearlEntity(Vector3D position) : base(position) { }
    public EnderPearlEntity(Vector3D position , Vector3D motion) : base(position , motion) { }



    #region Implements Entity
    public override void Tick()
    {
#if VERSION_1_12_ABOVE
        Position += Motion;
        Motion   *= 0.99F;
        Motion.Y -= 0.03F;
#else
        throw new NotImplementedException();
#endif
    }
    #endregion
}
