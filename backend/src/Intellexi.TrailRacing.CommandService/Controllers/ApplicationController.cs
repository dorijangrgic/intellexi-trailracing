using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.CommandService.Controllers;

public class ApplicationController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ApplicationCreateRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }
    
    [HttpDelete("{applicationId}")]
    public async Task<IActionResult> Delete([FromRoute] Guid applicationId)
    {
        var request = new ApplicationDeleteRequest { ApplicationId = applicationId };
        await Mediator.Send(request);
        return NoContent();
    }
}