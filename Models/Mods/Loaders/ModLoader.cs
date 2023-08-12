using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModStats.API.Models.Mods.Loaders;

[Table("mod_loaders")]
public class ModLoader : BaseModel
{
    [Required]
    public string Slug { get; set; } = null!;
    
    [Required]
    public string Name { get; set; } = null!;
}