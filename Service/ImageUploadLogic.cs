using Contracts.Models;
using Contracts.Requests;
using Contracts.Responses;
using Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Service;

public class ImageUploadLogic : IImageUploadLogic
{
    private const int IMAGE_LIMIT = 10;
    private readonly LeadContext _context;

    public ImageUploadLogic(LeadContext context)
    {
        _context = context;
    }

    public async Task<bool> IsImageLimitExceeded(Guid leadId)
    {
        try
        {
            var imageCount = await _context.LeadImages.AsNoTracking().Where(i=>i.LeadId == leadId && !i.IsDeleted).CountAsync();
            return imageCount < IMAGE_LIMIT;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<AddLeadImageResponse> UploadImage(AddLeadImageRequest request)
    {
        try
        {
            byte[] image;
            using (var memoryStream = new MemoryStream())
            {
                await request.File.CopyToAsync(memoryStream);
                image = memoryStream.ToArray();
            }

            var leadImage = new LeadImageModel()
            {
                LeadId = request.LeadId,
                Image = image,
            };
            await _context.LeadImages.AddAsync(leadImage);
            await _context.SaveChangesAsync();
            return new AddLeadImageResponse()
            {
                Success = true,
                LeadId = request.LeadId,
                ImageId = leadImage.LeadImageId
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<LeadImageModel>> GetLeadImages(Guid leadId)
    {
        try
        {
            var leadImages = await _context.LeadImages.AsNoTracking()
                .Where(x=>x.LeadId == leadId && !x.IsDeleted)
                .ToListAsync();
            return leadImages;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<DeleteLeadImageResponse> DeleteLeadImage(DeleteLeadImageRequest request)
    {
        try
        {
            var leadImage = await _context.LeadImages
                .FirstOrDefaultAsync(x=>x.LeadId == request.LeadId && x.LeadImageId == request.ImageId);
            if (leadImage == null)
            {
                return new DeleteLeadImageResponse()
                {
                    Success = false,
                    Error = $"Image with id: {request.ImageId} not found for lead: {request.LeadId}",
                };
            }
            leadImage.IsDeleted = true;
            await _context.SaveChangesAsync();
            return new DeleteLeadImageResponse()
            {
                Success = true,
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}