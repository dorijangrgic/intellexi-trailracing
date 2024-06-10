using MediatR;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

public class ApplicationDeleteRequest : IRequest
{
    public Guid ApplicationId { get; set; }
}