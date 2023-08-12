using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Models.Histograms;

public class Snapshot
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
    
    public Guid ModId { get; set; }
    public virtual Mod Mod { get; set; } = null!;
    
    public Guid PlatformId { get; set; }
    public virtual Platform Platform { get; set; } = null!;
}