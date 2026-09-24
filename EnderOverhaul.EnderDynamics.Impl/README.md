# EnderOverhaul.EnderDynamics.Impl
An implementation library that holds different version of algorithm for different minecraft version using different preprocessor directives. Use [wrapper library](../EnderOverhaul.EnderDynamics/README.md) for most cases and only use this when performance is a concern.

> [!IMPORTANT]
> Read [wrapper library](../EnderOverhaul.EnderDynamics/README.md) before reading this.


## Usage
**Typical usage**
```cs
Vector3D tntPos = new Vector3D(0.6 , 127.0 , 0.6);
PrimedTnt tnt = new PrimedTnt(tntPos);

Vector3D initialEnderPearlPos = new Vector3D(0.2 , 127.2 , -0.3);
Vector3D initialEnderPearlMotion = new Vector3D(0.0 , -0.1 , 0.2);
ThrownEnderPearl enderPearl = new ThrownEnderPearl(initialEnderPearlPos , initialEnderPearlMotion);

tnt.AccelerateEntity(enderPearl , tntCount: 10);
Vector3D motionOfTotalAcceleration = enderPearl.Motion - initialEnderPearlMotion;

for (int i = 0; i < 10; i++)
    enderPearl.Tick();

Vector3D currentPos = enderPearl.Position;
Vector3D currentMotion = enderPearl.Motion;
```
