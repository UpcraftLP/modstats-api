namespace ModStats.API.Util.Config;

[Serializable]
public class CurseForgeConfig
{
    public const string SectionName = "CurseForge";
    
    public string ApiKey { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
    public long PartnerId { get; set; } = -1L;
}