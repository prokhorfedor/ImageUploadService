using Microsoft.AspNetCore.Http;

namespace Contracts.Requests;

public class AddLeadImageRequest
{
    public Guid LeadId { get; set; }
    public IFormFile File { get; set; }
}