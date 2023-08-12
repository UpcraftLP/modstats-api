using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Minecraft;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Histograms;

[Table("hist_supported_versions")]
public class SupportedVersionsSnapshot : Snapshot
{
    public virtual ICollection<McVersion> Data { get; set; } = default!;
}