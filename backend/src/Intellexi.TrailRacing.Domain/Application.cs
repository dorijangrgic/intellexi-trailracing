namespace Intellexi.TrailRacing.Domain;

public class Application
{
    public Guid Id { get; init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Club { get; private set; }
    public Guid RaceId { get; private set; }
    
    public Race Race { get; private set; }

    private Application(Guid id, string firstName, string lastName, string club, Guid raceId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Club = club;
        RaceId = raceId;
    }

    public static Application Create(string firstName, string lastName, string club, Guid raceId)
    {
        return new Application(Guid.NewGuid(), firstName, lastName, club, raceId);
    }
}