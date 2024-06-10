using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.RaceManagement.Responses;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;
using MediatR;

namespace Intellexi.TrailRacing.Application.RaceManagement.Handlers;

public class RaceGetListRequestHandler : IRequestHandler<RaceGetListRequest, IEnumerable<RaceGetListResponse>>
{
    private readonly IRepository<Race> _raceRepository;

    public RaceGetListRequestHandler(IRepository<Race> raceRepository)
    {
        ArgumentNullException.ThrowIfNull(raceRepository);
        _raceRepository = raceRepository;
    }

    public async Task<IEnumerable<RaceGetListResponse>> Handle(RaceGetListRequest request, CancellationToken cancellationToken)
    {
        var races = await _raceRepository.ListAsync(cancellationToken);
        return races.Select(RaceGetListResponse.From);
    }
}