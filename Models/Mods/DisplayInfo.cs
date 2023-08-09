using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModStats.API.Models.Mods;

[Table("mod_display_info")]
public class DisplayInfo : BaseModel
{
    public Mod Mod { get; set; }
    [Required]
    public Guid ModId { get; set; } // foreign key

    public string Name { get; set; }
    public string Summary { get; set; }
    public string Owner { get; set; }
}