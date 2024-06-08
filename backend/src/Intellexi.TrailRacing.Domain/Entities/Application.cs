using Ardalis.GuardClauses;

namespace Intellexi.TrailRacing.Domain.Entities;

public class Application : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Club { get; private set; }
    public Guid RaceId { get; private set; }
    
    public Race Race { get; private set; }

    private Application(string firstName, string lastName, string club, Guid raceId)
    {
        FirstName = firstName;
        LastName = lastName;
        Club = club;
        RaceId = raceId;
    }

    public static Application Create(string firstName, string lastName, string club, Guid raceId)
    {
        Guard.Against.NullOrWhiteSpace(firstName);
        Guard.Against.LengthOutOfRange(firstName, 1, MaxPropertyLength);
        
        Guard.Against.NullOrWhiteSpace(lastName);
        Guard.Against.LengthOutOfRange(lastName, 1, MaxPropertyLength);
        
        Guard.Against.NullOrWhiteSpace(club);
        Guard.Against.LengthOutOfRange(club, 1, MaxPropertyLength);
        
        return new(firstName, lastName, club, raceId);
    }
}