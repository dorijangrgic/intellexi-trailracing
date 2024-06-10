using MediatR;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

public class ApplicationCreateRequest : IRequest
{
    public Guid RaceId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Club { get; set; }
}