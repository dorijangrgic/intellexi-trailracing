using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

namespace Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

public class ApplicationCreateRequestTestBuilder
{
    private string _firstName;
    private string _lastName;
    private string _club;
    private Guid _raceId;
    
    public static ApplicationCreateRequestTestBuilder Default()
    {
        return new ApplicationCreateRequestTestBuilder()
            .WithFirstName("firstName")
            .WithLastName("lastName")
            .WithClub("club")
            .WithRaceId(Guid.NewGuid());
    }
    
    public ApplicationCreateRequestTestBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }
    
    public ApplicationCreateRequestTestBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }
    
    public ApplicationCreateRequestTestBuilder WithClub(string club)
    {
        _club = club;
        return this;
    }
    
    public ApplicationCreateRequestTestBuilder WithRaceId(Guid raceId)
    {
        _raceId = raceId;
        return this;
    }

    public ApplicationCreateRequest Build()
    {
        return new ApplicationCreateRequest
        {
            FirstName = _firstName,
            LastName = _lastName,
            Club = _club
        };
    }
}