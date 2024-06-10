using Intellexi.TrailRacing.Application.RaceManagement.Models;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.Application.RaceManagement.Responses;

public class RaceGetListResponse
{
    public IEnumerable<RaceModel> Races { get; set; } = [];

    public static RaceGetListResponse From(List<Race> race)
    {
        return new RaceGetListResponse
        {
            Races = race.Select(RaceModel.From)
        };
    }
}