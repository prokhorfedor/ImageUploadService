namespace Contracts.Responses;

public class AddLeadImageResponse
{
    public bool Success { get; set; }
    public object? Error { get; set; }
    public Guid LeadId { get; set; }
    public int ImageId { get; set; }
}