using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Requests;

public class RaceGetDetailsRequest : IRequest<RaceGetDetailsResponse>
{
    public Guid RaceId { get; set; }
    
    public RaceGetDetailsRequest(Guid raceId)
    {
        RaceId = raceId;
    }
}