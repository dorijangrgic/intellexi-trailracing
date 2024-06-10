using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.CommandService.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]s")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator = null!;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}