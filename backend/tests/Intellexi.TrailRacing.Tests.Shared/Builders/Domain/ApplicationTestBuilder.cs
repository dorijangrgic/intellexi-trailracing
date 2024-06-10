namespace Intellexi.TrailRacing.Tests.Shared.Builders.Domain;

public class ApplicationTestBuilder
{
    private string _firstName;
    private string _lastName;
    private string _club;
    private Guid _raceId;
    
    public static ApplicationTestBuilder Default()
    {
        return new ApplicationTestBuilder()
            .WithFirstName("firstName")
            .WithLastName("lastName")
            .WithClub("club")
            .WithRaceId(Guid.NewGuid());
    }
    
    public ApplicationTestBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }
    
    public ApplicationTestBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }
    
    public ApplicationTestBuilder WithClub(string club)
    {
        _club = club;
        return this;
    }
    
    public ApplicationTestBuilder WithRaceId(Guid raceId)
    {
        _raceId = raceId;
        return this;
    }
    
    public TrailRacing.Domain.Entities.Application Build()
    {
        return TrailRacing.Domain.Entities.Application.Create(_firstName, _lastName, _club, _raceId);
    }
}