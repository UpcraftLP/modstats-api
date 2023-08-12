using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModStats.API.Models.Mods;

[Table("mods_metadata")]
public class ModMetadata : BaseModel
{
    //FK: Mod
    public Guid ModId { get; set; }
    public virtual Mod Mod { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public string? Description { get; set; }
}