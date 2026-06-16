using System;
using System.Collections.Generic;
using System.Text;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;


public class Player : Entity , ILivingEntity
{
    public Pose Posture = Pose.DEFAULT;


    #region Implements Entity
    public override void Tick(params object[]? args)
    {
        throw new NotSupportedException();
    }

    public override Vector3D GetEyePos()
    {
        float relativeEyeHeight = Posture switch
        {
            Pose.DEFAULT     => 1.62F ,
            Pose.SWIMMING    => 0.4F ,
            Pose.FALL_FLYING => 0.4F ,
            Pose.SPIN_ATTACK => 0.4F ,
            Pose.CROUCHING   => 1.27F ,
            _            => throw new ArgumentOutOfRangeException() ,
        };

        return new Vector3D(Position.X , Position.Y + relativeEyeHeight , Position.Z);
    }
    #endregion

    public enum Pose
    {
        DEFAULT     ,
        SWIMMING    ,
        FALL_FLYING ,
        SPIN_ATTACK ,
        CROUCHING  ,
    }
}
