# EnderOverhaul.EnderDynamics
A wrapper library to select implementations for different minecraft and load them dynamically. All function call to this library will be passed to the actual implementation library via C# reflection. All implementation libraries are located within `./lib` directory (relative to application root) should be automatically built when building this library.

> [!WARNING]
> Do not include `EnderOverhaul.EnderDynamics.Impl` with this wrapper at the same time. This causes type confusion and reduce code readability since both library has identical type names.


## Usage
When using `EnderDynamics` for wrapping multiple version of Minecraft behaviour, use `EnderDynamicsConfig.TrySetMinecraftVersion(string minecraftVersion)` to set which implementation library to use (**Default set to `Latest`**). All supported minecraft versions can be found in `MinecraftVersionMapping.toml`.

**Typical usage**
```cs
EnderDynamicsConfig.TrySetMinecraftVersion("Latest");

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

If performance or overhead is a concern, a direct call to the underlying library (`EnderOverhaul.EnderDynamics.Impl`) can be performed with correct preprocessor directive symbols. All symbols can be find in `MinecraftVersionMapping.toml`.


The `EnderOverhaul.EnderDynamics.Minecraft.Entities` namespace abstracts most of the version dependent algorithms. There are two important thing to be aware of:
- Within every class inherited from `Entity`, a `Tick()` method is provided to simulate movement exactly as Minecraft implementation. Please refer to the XML summary for what argument can be passed, or ignore it for typical use case.
- Within `PrimedTnt` class, a instance method `AccelerateEntity(Entity , float , int)` can be called to perform acceleration. All entities can be accelerated, including `PrimedTnt`. However, do not assume `explosionPower` scale up only the acceleration. Use only for debug purpose or simulate Minecraft Carpet mod's `mergeTnt` feature.


### Common example / snippet
**Compute acceleration one TNT stack applies to a pearl.**
```cs
Vector3D tntPos;
Vector3D initialEnderPearlPos;
PrimedTnt tnt = new PrimedTnt(tntPos);
ThrownEnderPearl motionSampler = new ThrownEnderPearl(initialEnderPearlPos);
tnt.AccelerateEntity(motionSampler);
Vector3D accelerateMotion = motionSampler.Motion;
```

**Given target destination and initial ender pearl state, compute how much acceleration is needed for a particular tick To travel.**
```cs
Vector2D destination;
ThrownEnderPearl initialEnderPearl;
int tickToTravel;
Vector2D totalOffset = destination - (Vector2D)initialEnderPearl.Position;
ThrownEnderPearl divisorSampler = new ThrownEnderPearl(new Vector3D() , new Vector3D(1.0 , 0.0 , 1.0));
for (int i = 0; i < tickToTravel; i++)
    divisorSampler.Tick();
Vector2D requiredMotion = totalOffset * (1 / divisorSampler.Position.X) - (Vector2D)initialEnderPearl.Motion;
```
