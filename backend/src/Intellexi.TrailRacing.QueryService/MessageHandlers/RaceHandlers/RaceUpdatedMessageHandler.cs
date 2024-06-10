using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.QueryService.MessageHandlers.RaceHandlers;

public class RaceUpdatedMessageHandler : IMessageHandler<RaceUpdateRequest>
{
    private readonly IGenericRepository<Race> _raceRepository;

    public RaceUpdatedMessageHandler(IGenericRepository<Race> raceRepository)
    {
        ArgumentNullException.ThrowIfNull(raceRepository);
        _raceRepository = raceRepository;
    }

    public async Task HandleAsync(RaceUpdateRequest message)
    {
        var existingRace = await _raceRepository.GetByIdAsync(message.RaceId);

        if (existingRace is null) throw new Exception($"Race with id [{message.RaceId}] not found.");
        
        existingRace.Update(message.Name, message.Distance);
        
        await _raceRepository.UpdateAsync(existingRace);
    }
}