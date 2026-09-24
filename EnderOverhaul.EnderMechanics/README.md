# EnderOverhaul.EnderMechanics
An optimizer and solver that help users to optimize error between ender pearl land spots and target destination. It also provides helper function that helps to simulate trajectories of different FTL design.


## Usage
There exist two common design calculator and a generic solver:
| Class name | Description | Important |
|------------|-------------|-----------|
| `StandardVectorFtl` | Calculator for vectorized ender pearl cannon with four TNT locations. It can compute how much TNT should be used and the trajectory of such TNT configuration. | Each TNT location must be at a different quadrant relative to ender pearl, and not be constrainted in a way such that it cannot cover 360°. |
| `SingleTntReturnFtl` | Calculator for optimizing ender pearl landing errors and simulate the trajectory of an ender pearl accelerated by single TNT cannons. |
| `MultiTntFtl` | Generic optimizer for compute how much TNT should be used for multiple TNT with optional location; or simulate ender pearl trajectory under multiple TNTs. | It uses OR-Tools as a backend solver. Some bugs on OR-Tools' side may occur. Therefore, some problems may take an excessive amount of time and some may not be solvable. The built-in timeout feature on C# OR-Tools is broken, thus downstream developers should not rely on it. |

A detailed summary of the function is provided within the source code. Use that as a reference for what parameters mean and what is required.
