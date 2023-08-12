using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModStats.API.Models.Histograms;

public class Snapshot<T>
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public T Data { get; set; } = default!;
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow.ToUniversalTime();
}