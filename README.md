# Ender Overhaul
A rework of the previous [PearlCalculatorCore](https://github.com/LegendsOfSky/PearlCalculatorCore).

This project simulates TNT explosions and the flight of players and ender pearls in Minecraft. Quirks and bugs that exist in vanilla Java Edition are preserved on purpose and treated as technical features. The main use case is helping technical players design ender pearl cannons that accelerate pearls to a chosen location for fast travel.

> [!WARNING]
> This project is only for Minecraft Java Edition and not for Minecraft Bedrock Edition

Licensed under the [MIT License](LICENSE).


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


## C# projects within this repo
| Name | Description | Status |
|------|-------------|--------|
| `EnderOverhaul` | Repo name | WIP |
| `EnderBlackout` | CLI application for creating ender pearl cannon config templates | Pending |
| `EnderTinker` | Cross platform calculator | Pending |
| [`EnderDynamics`](EnderOverhaul.EnderDynamics/README.md) | Wrapper library that select and wraps different version of `EnderDynamics.Impl` | Finished |
| `EnderDynamics.Impl` | Implementation library containing ported Minecraft sourced code for different version | Continuously maintaining |
| [`EnderMechanics`](EnderOverhaul.EnderMechanics/README.md) | Calculator library for optimizing least errors and explore ender pearl cannon solutions | Finished |
| `EnderOverflow` | Library to handle various ender pearl cannon config files | Pending |
| `DebugConsole` | Console for debug or committing sample code | — |

Click on project names will go to their respective `README.md`.


## Install / Quick start
**Requirement**
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

**Build**
```bash
git clone https://github.com/LegendsOfSky/EnderOverhaul.git
cd EnderOverhaul
dotnet build -c Release
```


## Credits
- [Hexeption/MCP-Reborn](https://github.com/Hexeption/MCP-Reborn)
- [FabricMC](https://github.com/fabricmc)
- [RichardLitt/standard-readme](https://github.com/RichardLitt/standard-readme)
