using Intellexi.TrailRacing.Application.ApplicationManagement.Models;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Responses;

public class ApplicationGetDetailsResponse : ApplicationModel
{
    public ApplicationGetDetailsResponse(
        Guid id,
        Guid raceId,
        string firstName,
        string lastName,
        string club) : base(id, raceId, firstName, lastName, club)
    {
    }
    
    public static ApplicationGetDetailsResponse From(Domain.Entities.Application application)
    {
        return new(
            application.Id,
            application.RaceId,
            application.FirstName,
            application.LastName,
            application.Club);
    }
}