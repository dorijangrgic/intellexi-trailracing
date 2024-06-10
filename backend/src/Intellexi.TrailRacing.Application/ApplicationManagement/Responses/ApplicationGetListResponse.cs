using Intellexi.TrailRacing.Application.ApplicationManagement.Models;

namespace Intellexi.TrailRacing.Application.ApplicationManagement.Responses;

public class ApplicationGetListResponse
{
    public IEnumerable<ApplicationModel> Applications { get; set; }
    
    public static ApplicationGetListResponse From(List<Domain.Entities.Application> application)
    {
        return new ApplicationGetListResponse
        {
            Applications = application.Select(ApplicationModel.From)
        };
    }
}