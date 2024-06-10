using Intellexi.TrailRacing.Application.RaceManagement.Models;
using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.Application.RaceManagement.Responses;

public class RaceGetListResponse : RaceModel
{
    private RaceGetListResponse(Guid id, string name, RaceDistance distance) : base(id, name, distance)
    {
    }

    public static RaceGetListResponse From(Race race) => new(race.Id, race.Name, race.Distance);
}