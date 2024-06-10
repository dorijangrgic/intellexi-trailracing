using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Intellexi.TrailRacing.Application.Common.ErrorHandling.Exceptions;

[Serializable]
public class BadRequestException : BaseServiceException
{
    public ModelStateDictionary ModelState { get; }
    
    public BadRequestException(ServiceErrorCode errorCode, string message) 
        : base(errorCode, message)
    {
    }

    public BadRequestException(ModelStateDictionary modelState) 
        : base(ServiceErrorCode.FailedValidation, "Invalid request object provided")
    {
        ModelState = modelState;
    }
    
    public override CustomProblemDetails ToProblemDetails()
    {
        var problemDetails = base.ToProblemDetails();
        problemDetails.Errors = ModelState?.ToDictionary(k => k.Key, v => v.Value.Errors.Select(x => x.ErrorMessage).ToArray());

        return problemDetails;
    }

    public override int GetStatusCode() => StatusCodes.Status400BadRequest;
}