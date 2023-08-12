namespace ModStats.API.Util.Config;

[Serializable]
public class ModrinthConfig
{
    public const string SectionName = "Modrinth";
    
    public string ApiKey { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
}