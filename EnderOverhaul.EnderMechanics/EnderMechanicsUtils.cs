using System;
using System.Collections.Generic;
using System.Text;
using EnderOverhaul.EnderDynamics.Minecraft.Entities;
using EnderOverhaul.EnderDynamics.Utils.Vector;


namespace EnderOverhaul.EnderMechanics;

public static class EnderMechanicsUtils
{
    public static Vector3D CalculateMotionOfEnderPearlAcceleratedTnt(PrimedTnt tnt , Vector3D position)
    {
        ThrownEnderpearl enderPearl = new ThrownEnderpearl(position);
        tnt.AccelerateEntity(enderPearl);
        return enderPearl.Motion;
    }
}
