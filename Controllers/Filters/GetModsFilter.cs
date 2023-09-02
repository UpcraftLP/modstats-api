namespace ModStats.API.Controllers.Filters;

public class GetModsFilter
{
    public string? Slug { get; set; }
    public string? Id { get; set; }
    public List<string>? Platforms { get; set; }
    public List<string>? SupportedVersions { get; set; }
}
