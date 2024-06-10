using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.Application.RaceManagement.Models;

public class RaceModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RaceDistance Distance { get; set; }

    public RaceModel(Guid id, string name, RaceDistance distance)
    {
        Id = id;
        Name = name;
        Distance = distance;
    }

    public static RaceModel From(Race race) => new(race.Id, race.Name, race.Distance);
}