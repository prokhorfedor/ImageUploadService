using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Enums;

namespace Contracts.Models;

[Table("Leads")]
public class LeadModel
{
    [Key]
    public Guid LeadId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    public LeadSource Source { get; set; }

    public DateTime CreatedAt { get; set; }

    public LeadStatus Status { get; set; }

    public string Notes { get; set; }

    public bool IsDeleted { get; set; }
    public List<LeadImageModel>? LeadImages { get; set; }
}