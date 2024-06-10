using Microsoft.AspNetCore.Http;

namespace Intellexi.TrailRacing.Application.Common.ErrorHandling.Exceptions;

public class NotFoundException : BaseServiceException
{
    public NotFoundException(string message) 
        : base(ServiceErrorCode.EntityNotFound, message)
    {
    }

    public override int GetStatusCode() => StatusCodes.Status404NotFound;
}