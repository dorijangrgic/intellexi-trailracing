using Intellexi.TrailRacing.Domain;

namespace Intellexi.TrailRacing.Application.RaceManagement.Models;

public abstract class RaceModel
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
}