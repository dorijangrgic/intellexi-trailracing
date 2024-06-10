using Intellexi.TrailRacing.Application.ApplicationManagement.Models;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Responses;

public class ApplicationGetListResponse : ApplicationModel
{
    public ApplicationGetListResponse(
        Guid id,
        Guid raceId,
        string firstName,
        string lastName,
        string club) : base(id, raceId, firstName, lastName, club)
    {
    }
    
    public static ApplicationGetListResponse From(Domain.Entities.Application application)
    {
        return new(
            application.Id,
            application.RaceId,
            application.FirstName,
            application.LastName,
            application.Club);
    }
}