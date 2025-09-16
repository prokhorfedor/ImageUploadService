using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models;

[Table("LeadImages")]
public class LeadImageModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LeadImageId { get; set; }
    public byte[] Image { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? LeadId { get; set; }
}