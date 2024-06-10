using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Requests;

public class RaceDeleteRequest : IRequest
{
    public Guid RaceId { get; set; }
}