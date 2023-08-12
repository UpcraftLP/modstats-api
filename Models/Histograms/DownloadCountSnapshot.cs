using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Histograms;

[Table("hist_download_count")]
public class DownloadCountSnapshot : Snapshot
{
    public double Data { get; set; } = 0;
}