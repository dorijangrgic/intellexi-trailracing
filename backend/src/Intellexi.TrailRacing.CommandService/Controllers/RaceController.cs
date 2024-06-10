using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.CommandService.Controllers;

public class RaceController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RaceCreateRequest request)
    {
        await Mediator.Send(request);
        return Created();
    }
    
    [HttpPut("{raceId}")]
    public async Task<IActionResult> Update([FromRoute] Guid raceId, [FromBody] RaceUpdateRequest request)
    {
        request.RaceId = raceId;
        await Mediator.Send(request);
        return NoContent();
    }
    
    [HttpDelete("{raceId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid raceId)
    {
        var request = new RaceDeleteRequest { RaceId = raceId };
        await Mediator.Send(request);
        return NoContent();
    }
}