# Ender Overhaul
A rework of the previous [PearlCalculatorCore](https://github.com/LegendsOfSky/PearlCalculatorCore).

This project simulates TNT explosions and the flight of players and ender pearls in Minecraft. Quirks and bugs that exist in vanilla Java Edition are preserved on purpose and treated as technical features. The main use case is helping technical players design ender pearl cannons that accelerate pearls to a chosen location for fast travel.

> [!WARNING]
> This project is only for Minecraft Java Edition and not for Minecraft Bedrock Edition

Licensed under the [MIT License](LICENSE).

## Table of Contents
- [Glossary](#glossary)
- [Background](#background)
- [C# projects within this solution](#c-projects-within-this-solution)
- [Install](#install)
- [Usage](#usage)
- [Common example / snippet](#common-example--snippet)
- [Credits](#credits)


## Glossary
| Term | Definition |
|------------|------------|
| FTL | Ender pearl cannon |
| Vectorized FTL | Ender pearl cannon that uses multiple TNT, and each TNT creates an acceleration vector to accelerate an ender pearl in an arbitrary direction and motion. By changing how much TNT is used, users can change where the ender pearl lands. |
| Return FTL | Ender pearl cannon that can only hit a specific target with all FTL configuration hardcoded into the design. |


## Background
The primary motivation to create and rework the existing `PearlCalculatorCore` is that Mojang has changed the behaviour of entity-movement-related logic. Currently, entity movement logic is divided into `pre-1.21.2 (< 1.21.2)` and `post-1.21.2 (>= 1.21.2)`. Project `PearlCalculatorCore` does not support multiple version switching.

Furthermore, multiple downstream projects have ported `PearlCalculatorCore` in their own design but misused the implementation provided within that project (*i.e. using an optimized version of the algorithm to calculate raw values instead of using the native ported version*). Modifying `PearlCalculatorCore` would mean other projects may fail or break apart.

All of those issues caused us to give up on maintaining `PearlCalculatorCore` and to create a rework of it with flexible libraries that can be loaded dynamically.


## C# projects within this solution
| name | Description | Status |
|------|-------------|--------|
| `EnderOverhaul` | Repo name | WIP |
| `EnderBlackout` | CLI application for creating ender pearl cannon config templates | Pending |
| `EnderTinker` | Cross platform calculator | Pending |
| `EnderDynamics` | Wrapper library that select and wraps different version of `EnderDynamics.Impl` | Finished |
| `EnderDynamics.Impl` | Implementation library containing ported Minecraft sourced code for different version | Continuously maintaining |
| `EnderMechanics` | Calculator library for optimizing least errors and explore ender pearl cannon solutions | Finished |
| `EnderOverflow` | Library to handle various ender pearl cannon config files | Pending |
| `DebugConsole` | Console for debug or committing sample code | — |


## Install
**Requirement**
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

**Build**
```bash
git clone https://github.com/LegendsOfSky/EnderOverhaul.git
cd EnderOverhaul
dotnet build -c Release
```


## Usage
### EnderDynamics
When using `EnderDynamics` for wrapping multiple version of Minecraft behaviour, use `EnderDynamicsConfig.TrySetMinecraftVersion(string minecraftVersion)` to set which implementation library to use. All supported minecraft versions can be found in `MinecraftVersionMapping.toml`.

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


### EnderMechanics
There exist two common design calculator and a generic solver:
| Class name | Description | Important |
|------------|-------------|----------|
| `StandardVectorFtl` | Calculator for vectorized ender pearl cannon with four TNT locations. It can compute how much TNT should be used and the trajectory of such TNT configuration. | Each TNT location must be at a different quadrant relative to ender pearl, and not be constrainted in a way such that it cannot cover 360°. |
| `SingleTntReturnFtl` | Calculator for optimizing ender pearl landing errors and simulate the trajectory of an ender pearl accelerated by single TNT cannons. |
| `MultiTntFtl` | Generic optimizer for compute how much TNT should be used for multiple TNT with optional location; or simulate ender pearl trajectory under multiple TNTs. | It uses OR-Tools as a backend solver. Some bugs on OR-Tools' side may occur. Therefore, some problems may take an excessive amount of time and some may not be solvable. The built-in timeout feature on C# OR-Tools is broken, thus downstream developers should not rely on it. |

A detailed summary of the function is provided within the source code. Use that as a reference for what parameters mean and what to expect.


## Common example / snippet
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


## Credits
- [Hexeption/MCP-Reborn](https://github.com/Hexeption/MCP-Reborn)
- [FabricMC](https://github.com/fabricmc)
