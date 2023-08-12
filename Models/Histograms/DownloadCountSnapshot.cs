using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Histograms;

[Table("hist_download_count")]
public class DownloadCountSnapshot : Snapshot<double>
{
    public Guid ModId { get; set; }
    public virtual Mod Mod { get; set; } = null!;
    
    public Guid PlatformId { get; set; }
    public virtual Platform Platform { get; set; } = null!;
}