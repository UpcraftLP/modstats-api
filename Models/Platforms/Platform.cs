using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModStats.API.Models.Platforms;

[Table("platforms")]
public class Platform : BaseModel
{
    [Required]
    public string Slug { get; set; }
    
    [Required]
    public string Name { get; set; }
}
