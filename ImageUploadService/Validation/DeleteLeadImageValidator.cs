using Contracts.Requests;
using FluentValidation;

namespace ImageUploadService.Validation;

public class DeleteLeadImageValidator : AbstractValidator<DeleteLeadImageRequest>
{
    public DeleteLeadImageValidator()
    {
        RuleFor(request => request.LeadId).NotEmpty();
        RuleFor(request => request.ImageId).NotEmpty();
    }
}