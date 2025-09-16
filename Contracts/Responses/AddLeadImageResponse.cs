namespace Contracts.Responses;

public class AddLeadImageResponse
{
    public bool Success { get; set; }
    public object? Error { get; set; }
    public Guid LeadId { get; set; }
    public List<int> ImageIds { get; set; }
}