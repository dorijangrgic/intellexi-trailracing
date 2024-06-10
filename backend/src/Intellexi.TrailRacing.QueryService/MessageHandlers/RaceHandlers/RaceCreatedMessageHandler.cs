using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.QueryService.MessageHandlers.RaceHandlers;

public class RaceCreatedMessageHandler : IMessageHandler<RaceCreateRequest>
{
    private readonly IGenericRepository<Race> _raceRepository;

    public RaceCreatedMessageHandler(IGenericRepository<Race> raceRepository)
    {
        ArgumentNullException.ThrowIfNull(raceRepository);
        _raceRepository = raceRepository;
    }

    public async Task HandleAsync(RaceCreateRequest message)
    {
        var race = Race.Create(message.Name, message.Distance);
        await _raceRepository.AddAsync(race);
    }
}