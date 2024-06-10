using Intellexi.TrailRacing.Application.Common.ErrorHandling.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Intellexi.TrailRacing.CommandService.ExceptionHandlers;

public class BaseServiceExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is BaseServiceException baseServiceException)
        {
            var problemDetails = baseServiceException.ToProblemDetails();

            httpContext.Response.StatusCode = baseServiceException.GetStatusCode();
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        return false;
    }
}