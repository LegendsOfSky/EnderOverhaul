using System.Reflection;
using Tomlyn;
using Tomlyn.Model;


namespace EnderOverhaul.EnderDynamics;

public static class EnderDynamicsConfig
{
    public static string MinecraftVersion { get; private set; }
    public static string LibVersion { get; private set; }

    internal static event EventHandler<ImplementationChangedEventArgs>? OnImplementationChangedEvent;
    internal static Assembly S_ImplementationLibrary;

    private static readonly string s_mappingFilePath = "MinecraftVersionMapping.toml";
    private static readonly Dictionary<string , string> s_minecraftVersionToLibVersion = new();
    private static readonly Dictionary<string , Assembly> s_implementations = new ();


    static EnderDynamicsConfig()
    {
#pragma warning disable S3877  // ignores sonarqube S3877 because it is intensional to make the whole type unusable if any error occur when parsing mapping file
        TomlTable mappingTable = TomlSerializer.Deserialize<TomlTable>(File.ReadAllText(s_mappingFilePath))
            ?? throw new FileNotFoundException("Cannot find mapping file to convert Minecraft version into library version");
        foreach ((string libVersion, object value) in mappingTable)
        {
            if (value is not TomlArray minecraftVersions)
                throw new InvalidDataException("Unable to parse mapping file.");

            string libPath = Path.Combine(AppContext.BaseDirectory , "lib" , libVersion , "EnderOverhaul.EnderDynamics.Impl.dll");
            if (!File.Exists(libPath))
                throw new FileNotFoundException($"Cannot find implementation assembly for '{libVersion}'.");

            Assembly assembly = Assembly.LoadFile(libPath);
            s_implementations.Add(libVersion , assembly);
            foreach (object? minecraftVersionObj in minecraftVersions)
            {
                if (minecraftVersionObj is not string minecraftVersion)
                    throw new InvalidDataException("Unable to parse mapping file.");

                s_minecraftVersionToLibVersion.Add(minecraftVersion , libVersion);
            }
        }
#pragma warning restore S3877

        TrySetMinecraftVersion("Latest");
    }

    
    public static bool TrySetMinecraftVersion(string minecraftVersion)
    {
        if (!s_minecraftVersionToLibVersion.TryGetValue(minecraftVersion , out string? libVersion))
            return false;

        OnImplementationChangedEvent?.Invoke(null , new ImplementationChangedEventArgs(S_ImplementationLibrary , s_implementations[libVersion]));
        S_ImplementationLibrary = s_implementations[libVersion];
        LibVersion = libVersion;
        MinecraftVersion = minecraftVersion;
        return true;
    }
}
