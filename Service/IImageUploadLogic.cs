using Contracts.Models;
using Contracts.Requests;
using Contracts.Responses;

namespace Service;

public interface IImageUploadLogic
{
    Task<bool> IsImageLimitExceeded(Guid leadId);
    Task<AddLeadImageResponse> UploadImage(AddLeadImageRequest request);
    Task<List<LeadImageModel>> GetLeadImages(Guid leadId);
    Task<DeleteLeadImageResponse> DeleteLeadImage(DeleteLeadImageRequest request);
}