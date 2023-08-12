using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Mods;

[Table("mods_supported_platforms")]
public class ModSupportedPlatform : BaseModel
{
    //FK: Mod
    public Guid ModId { get; set; }
    public virtual Mod Mod { get; set; } = null!;
    
    //FK: Platform
    public Guid PlatformId { get; set; }
    public virtual Platform Platform { get; set; } = null!;
    
    // name on the platform
    public string PlatformKey { get; set; } = null!;
}