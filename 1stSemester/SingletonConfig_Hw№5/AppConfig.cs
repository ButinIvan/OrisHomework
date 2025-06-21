using System.Text.Json;

namespace SingletonConfig;

public sealed class AppConfig
{
    private static readonly Lazy<AppConfig> _instance = new Lazy<AppConfig>(() => new AppConfig());
    public static AppConfig Instance => _instance.Value;
    public string Domain { get; set; } = "localhost";
    public uint Port { get; set; } = 6529;
    public string StaticDirectoryPath { get; set; } = "public\\";

    private AppConfig()
    {
        ReadJsonFile().Wait();
    }
    private async Task ReadJsonFile()
    {
        if (File.Exists("config.json"))
        {
            var fileConfig = await File.ReadAllTextAsync("config.json");
            
            Dictionary<string, JsonElement>? configData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(fileConfig);

            if (configData.TryGetValue("Domain", out var domain))
                Domain = domain.GetString();

            if (configData.TryGetValue("Port", out var port))
                Port = port.GetUInt32();

            if (configData.TryGetValue("StaticDirectoryPath", out var staticDir))
                StaticDirectoryPath = staticDir.GetString();
        } 
        else
        {
            Console.WriteLine("Файл конфигурации сервера 'config.json' не найден");
        }
    }
}