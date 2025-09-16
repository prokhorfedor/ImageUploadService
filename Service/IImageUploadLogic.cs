using Contracts.Models;
using Contracts.Requests;
using Contracts.Responses;

namespace Service;

public interface IImageUploadLogic
{
    Task<bool> IsImageLimitNotExceeded(Guid leadId, int requestFileCount);
    Task<AddLeadImageResponse> UploadImage(AddLeadImageRequest request);
    Task<List<LeadImageModel>> GetLeadImages(Guid leadId);
    Task<DeleteLeadImageResponse> DeleteLeadImage(DeleteLeadImageRequest request);
}