namespace Intellexi.TrailRacing.Domain;

public class Race
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public RaceDistance Distance { get; private set; }
    
    private Race(Guid id, string name, RaceDistance distance)
    {
        Id = id;
        Name = name;
        Distance = distance;
    }

    public static Race Create(string name, RaceDistance distance)
    {
        return new Race(Guid.NewGuid(), name, distance);
    }
    
    public void Update(string name, RaceDistance distance)
    {
        Name = name;
        Distance = distance;
    }
}