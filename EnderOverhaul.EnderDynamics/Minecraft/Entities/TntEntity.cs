using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public class TntEntity : Entity
{
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


    #region Implements Entity
    public override void Tick()
    {
        throw new NotImplementedException();
    }
    #endregion
}
