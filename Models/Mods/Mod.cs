using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Minecraft;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Mods;

[Table("mods")]
public class Mod : BaseModel
{
    public string Slug { get; set; }
    
    public DisplayInfo Display { get; set; }
    
    public IEnumerable<Platform> SupportedPlatforms { get; set; }
    public IEnumerable<McVersion> SupportedVersions { get; set; }
}