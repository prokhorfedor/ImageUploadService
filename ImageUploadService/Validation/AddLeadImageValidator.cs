using Contracts.Requests;
using FluentValidation;
using ImageUploadService.Controllers;
using Service;

namespace ImageUploadService.Validation;

public class AddLeadImageValidator : AbstractValidator<AddLeadImageRequest>
{
    public AddLeadImageValidator(IImageUploadLogic imageUploadLogic)
    {
        RuleFor(x => x.LeadId).NotEmpty()
            .MustAsync(async (id, cancellation) => await imageUploadLogic.IsImageLimitExceeded(id))
            .WithMessage("Image limit of 10 images per lead exceeded");
        RuleFor(x => x.File).NotEmpty();
    }
}