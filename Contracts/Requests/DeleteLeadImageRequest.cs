namespace Contracts.Requests;

public class DeleteLeadImageRequest
{
    public Guid LeadId { get; set; }
    public int ImageId { get; set; }
}