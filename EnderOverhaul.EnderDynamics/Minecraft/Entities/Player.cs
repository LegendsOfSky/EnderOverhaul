using System;
using System.Collections.Generic;
using System.Text;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;


public class Player : Entity , ILivingEntity
{
    #region Implements Entity
    public override void Tick(params object[]? args)
    {
        throw new NotImplementedException();
    }

    public override Vector3D GetEyePos()
    {
        throw new NotImplementedException();
    }
    #endregion
}
