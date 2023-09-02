namespace ModStats.API.DataTransfer.Mods;

public class AddModsInput
{
    public Guid? ModId { get; set; }
    public string Slug { get; set; } = null!;
    public IEnumerable<PlatformInput> SupportedPlatforms { get; set; } = null!;
}

public class PlatformInput
{
    public string Platform { get; set; } = null!;
    public string Id { get; set; } = null!;
}
