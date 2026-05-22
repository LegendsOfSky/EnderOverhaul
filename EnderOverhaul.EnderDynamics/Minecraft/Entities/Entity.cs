using System;
using System.Collections.Generic;
using System.Text;
using EnderOverhaul.EnderDynamics.Utils.Vector;

namespace EnderOverhaul.EnderDynamics.Minecraft.Entities;

public abstract class Entity
{
    public Vector3D Position;
    public Vector3D Motion;

    public abstract void Tick();
}
