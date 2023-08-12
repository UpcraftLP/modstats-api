using System.ComponentModel.DataAnnotations.Schema;
using GraphQL.AspNet.Attributes;
using ModStats.API.Models.Minecraft;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Mods;

[Table("mods")]
public class Mod : BaseModel
{
    public string Slug { get; set; } = null!;
    
    public virtual ModMetadata Meta { get; set; } = null!;
    
    public virtual ICollection<ModSupportedPlatform> PlatformIDs { get; set; } = new List<ModSupportedPlatform>();
    public virtual ICollection<McVersion> SupportedVersions { get; set; } = new List<McVersion>();

    [NotMapped]
    public virtual IEnumerable<Platform> SupportedPlatforms => PlatformIDs.Select(it => it.Platform);
}