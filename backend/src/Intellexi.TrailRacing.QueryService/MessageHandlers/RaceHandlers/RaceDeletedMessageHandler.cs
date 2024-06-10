﻿using Ardalis.GuardClauses;
using Intellexi.TrailRacing.Application.Common;
using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Application.Services;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.QueryService.MessageHandlers.RaceHandlers;

public class RaceDeletedMessageHandler : IMessageHandler<RaceDeleteRequest>
{
    private readonly IRepository<Race> _raceRepository;

    public RaceDeletedMessageHandler(IRepository<Race> raceRepository)
    {
        ArgumentNullException.ThrowIfNull(raceRepository);
        _raceRepository = raceRepository;
    }

    public async Task HandleAsync(RaceDeleteRequest message)
    {
        var race = await _raceRepository.GetByIdAsync(message.RaceId);

        Guard.Against.EntityNotFound(race, message.RaceId);
        
        await _raceRepository.DeleteAsync(race);
    }
}