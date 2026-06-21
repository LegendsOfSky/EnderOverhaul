using System.Reflection;
using Tomlyn;
using Tomlyn.Model;


namespace EnderOverhaul.EnderDynamics;

public static class EnderDynamicsConfig
{
    public static string MinecraftVersion { get; private set; }
    public static string LibVersion { get; private set; }

    internal static Assembly implementationLibrary;

    private static readonly string                      mappingFilePath              = "MinecraftVersionMapping.toml";
    private static readonly Dictionary<string , string> minecraftVersionToLibVersion = new();


    static EnderDynamicsConfig()
    {
        
        TomlTable mappingTable = TomlSerializer.Deserialize<TomlTable>(File.ReadAllText(mappingFilePath))
            ?? throw new FileNotFoundException("Cannot find mapping file to convert Minecraft version into library version");
        foreach ((string libVersion, object value) in mappingTable)
        {
            if (value is not TomlArray minecraftVersions)
                throw new InvalidDataException("Unable to parse mapping file.");

            foreach (object? minecraftVersionObj in minecraftVersions)
            {
                if (minecraftVersionObj is not string minecraftVersion)
                    throw new InvalidDataException("Unable to parse mapping file.");

                minecraftVersionToLibVersion.Add(minecraftVersion , libVersion);
            }
        }
    }

    
    public static bool TrySetMinecraftVersion(string minecraftVersion)
    {
        if (!minecraftVersionToLibVersion.TryGetValue(minecraftVersion , out string? libVersion))
            return false;

        string libPath = Path.Combine(AppContext.BaseDirectory , "lib" , libVersion , "EnderOverhaul.EnderDynamics.Impl.dll");
        if (!File.Exists(libPath))
            throw new FileNotFoundException($"Cannot find implementation assembly for '{libVersion}'.");

        implementationLibrary = Assembly.LoadFile(libPath);
        LibVersion = libVersion;
        MinecraftVersion = minecraftVersion;
        return true;
    }
}
