using System.Net.Mime;
using Intellexi.TrailRacing.Application.Common.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.QueryService.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]s")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ProducesErrorResponseType(typeof(CustomProblemDetails))]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator = null!;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}