using Contracts.Models;
using Contracts.Requests;
using Contracts.Responses;
using FluentValidation;
using FluentValidation.Results;
using ImageUploadService.Validation;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ImageUploadService.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageUploadController : ControllerBase
{
    private readonly IValidator<AddLeadImageRequest> _addLeadImageRequestValidator;
    private readonly IValidator<DeleteLeadImageRequest> _deleteLeadImageRequestValidator;
    private readonly IImageUploadLogic _imageUploadLogic;
    private readonly ILogger<ImageUploadController> _logger;


    public ImageUploadController(IValidator<AddLeadImageRequest> addLeadImageRequestValidator, IValidator<DeleteLeadImageRequest> deleteLeadImageRequestValidator, IImageUploadLogic imageUploadLogic, ILogger<ImageUploadController> logger)
    {
        _addLeadImageRequestValidator = addLeadImageRequestValidator;
        _deleteLeadImageRequestValidator = deleteLeadImageRequestValidator;
        _imageUploadLogic = imageUploadLogic;
        _logger = logger;
    }

    [HttpGet]
    [Route("[action]/{leadId}")]
    public async Task<ActionResult<List<LeadImageModel>>> GetLeadImages([FromRoute] Guid leadId)
    {
        try
        {
            var result = await _imageUploadLogic.GetLeadImages(leadId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<AddLeadImageResponse>> AddLeadImage([FromForm] AddLeadImageRequest request)
    {
        try
        {
            ValidationResult validationResult = await _addLeadImageRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return BadRequest();
            }
            var result = await _imageUploadLogic.UploadImage(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new AddLeadImageResponse()
            {
                Success = false,
                Error = e.Message
            });
        }
    }

    [HttpDelete]
    [Route("[action]")]
    public async Task<ActionResult<DeleteLeadImageResponse>> DeleteLeadImage([FromBody] DeleteLeadImageRequest request)
    {
        try
        {
            ValidationResult validationResult = await _deleteLeadImageRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return BadRequest(new DeleteLeadImageResponse()
                {
                    Success = false,
                    Error = this.ModelState
                });
            }
            var result = await _imageUploadLogic.DeleteLeadImage(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new DeleteLeadImageResponse()
            {
                Success = false,
                Error = e.Message
            });
        }
    }
}