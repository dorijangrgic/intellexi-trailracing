using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Intellexi.TrailRacing.QueryService.Controllers;

public class ApplicationController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new ApplicationGetListRequest();
        var applications = await Mediator.Send(request);
        return Ok(applications);
    }
    
    [HttpGet("{applicationId}")]
    public async Task<IActionResult> GetSingle([FromRoute] Guid applicationId)
    {
        var request = new ApplicationGetDetailsRequest { ApplicationId = applicationId };
        var application = await Mediator.Send(request);
        return Ok(application);
    }
}