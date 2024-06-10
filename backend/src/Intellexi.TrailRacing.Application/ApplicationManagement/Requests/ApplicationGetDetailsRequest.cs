using Intellexi.TrailRacing.Application.ApplicationManagement.Responses;
using MediatR;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

public class ApplicationGetDetailsRequest : IRequest<ApplicationGetDetailsResponse>
{
    public Guid ApplicationId { get; set; }
}