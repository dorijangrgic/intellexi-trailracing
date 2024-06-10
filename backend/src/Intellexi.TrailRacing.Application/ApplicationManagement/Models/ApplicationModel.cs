namespace Intellexi.TrailRacing.Application.ApplicationManagement.Models;

public class ApplicationModel
{
    public Guid Id { get; set; }
    public Guid RaceId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Club { get; set; }

    protected ApplicationModel(Guid id, Guid raceId, string firstName, string lastName, string club)
    {
        Id = id;
        RaceId = raceId;
        FirstName = firstName;
        LastName = lastName;
        Club = club;
    }
    
    public static ApplicationModel From(Domain.Entities.Application application)
    {
        return new(
            application.Id,
            application.RaceId,
            application.FirstName,
            application.LastName,
            application.Club);
    }
}