using Contracts.Requests;
using FluentValidation;
using ImageUploadService.Controllers;
using Service;

namespace ImageUploadService.Validation;

public class AddLeadImageValidator : AbstractValidator<AddLeadImageRequest>
{
    private const long FILE_SIZE_LIMIT = 5242880;
    public AddLeadImageValidator(IImageUploadLogic imageUploadLogic)
    {
        RuleFor(x => x.LeadId).NotEmpty()
            .MustAsync(async (request, id, cancellation) => await imageUploadLogic.IsImageLimitNotExceeded(id, request.Files.Count))
            .WithMessage("Image limit of 10 images per lead exceeded");
        RuleFor(x => x.Files).NotEmpty()
            .Must(x=>x.All(f=>f.Length <= FILE_SIZE_LIMIT))
            .WithMessage("Image file size limit of 5MB exceeded");
    }
}