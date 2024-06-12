using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.QueryService.Controllers;

public class RaceController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var races = await Mediator.Send(new RaceGetListRequest());
        return Ok(races);
    }
    
    [HttpGet("{raceId}")]
    public async Task<IActionResult> GetSingle([FromRoute] Guid raceId)
    {
        var request = new RaceGetDetailsRequest(raceId);
        var race = await Mediator.Send(request);
        return Ok(race);
    }
}