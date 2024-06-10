using Ardalis.GuardClauses;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;
using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Handlers;

public class RaceGetDetailsRequestHandler : IRequestHandler<RaceGetDetailsRequest, RaceGetDetailsResponse>
{
    private readonly IRepository<Race> _raceRepository;

    public RaceGetDetailsRequestHandler(IRepository<Race> raceRepository)
    {
        ArgumentNullException.ThrowIfNull(raceRepository);
        _raceRepository = raceRepository;
    }

    public async Task<RaceGetDetailsResponse> Handle(RaceGetDetailsRequest request, CancellationToken cancellationToken)
    {
        var race = await _raceRepository.GetByIdAsync(request.RaceId, cancellationToken);
        
        Guard.Against.EntityNotFound(race, request.RaceId);

        return RaceGetDetailsResponse.From(race);
    }
}