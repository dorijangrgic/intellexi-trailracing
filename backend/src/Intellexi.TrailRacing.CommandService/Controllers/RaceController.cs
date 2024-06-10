using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.CommandService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RaceController : ControllerBase
{
    private readonly IMediator _mediator;

    public RaceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewRace([FromBody] RaceCreateRequest command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}