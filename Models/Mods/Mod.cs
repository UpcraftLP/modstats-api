using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Histograms;
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
    
    [NotMapped]
    public virtual double TotalDownloadCount => PlatformIDs.Sum(it => it.DownloadCount);
    
    public virtual ICollection<DownloadCountSnapshot> HistoricalDownloadData { get; set; } = new List<DownloadCountSnapshot>();
    public virtual ICollection<SupportedVersionsSnapshot> HistoricalSupportedVersionsData { get; set; } = new List<SupportedVersionsSnapshot>();
}