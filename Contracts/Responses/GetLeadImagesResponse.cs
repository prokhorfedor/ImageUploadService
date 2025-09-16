namespace Contracts.Responses;

public class GetLeadImagesResponse
{
    public Guid LeadId { get; set; }
    public List<string> Base64Images { get; set; }
}