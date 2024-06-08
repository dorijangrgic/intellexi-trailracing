using Ardalis.GuardClauses;

namespace Intellexi.TrailRacing.Domain.Entities;

public class Race : BaseEntity
{
    public string Name { get; private set; }
    public RaceDistance Distance { get; private set; }
    
    private Race(string name, RaceDistance distance)
    {
        Name = name;
        Distance = distance;
    }

    public static Race Create(string name, RaceDistance distance)
    {
        Guard.Against.NullOrWhiteSpace(name);
        Guard.Against.LengthOutOfRange(name, 1, MaxPropertyLength);

        Guard.Against.EnumOutOfRange(distance);

        return new(name, distance);
    }
    
    public void Update(string name, RaceDistance distance)
    {
        Guard.Against.NullOrWhiteSpace(name);
        Guard.Against.LengthOutOfRange(name, 1, MaxPropertyLength);

        Guard.Against.EnumOutOfRange(distance);

        Name = name;
        Distance = distance;
    }
}