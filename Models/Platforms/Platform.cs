using System.ComponentModel.DataAnnotations.Schema;

namespace ModStats.API.Models.Platforms;

[Table("platforms")]
public class Platform : BaseModel
{
    public string Slug { get; set; } = null!;
    public string Name { get; set; } = null!;
}
