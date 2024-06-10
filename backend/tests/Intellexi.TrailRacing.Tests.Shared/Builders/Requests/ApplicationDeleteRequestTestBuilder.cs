using Intellexi.TrailRacing.Application.ApplicationManagement.Requests;

namespace Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

public class ApplicationDeleteRequestTestBuilder
{
    private Guid _id;
    
    public static ApplicationDeleteRequestTestBuilder Default()
    {
        return new ApplicationDeleteRequestTestBuilder()
            .WithId(Guid.NewGuid());
    }
    
    public ApplicationDeleteRequestTestBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public ApplicationDeleteRequest Build()
    {
        return new ApplicationDeleteRequest
        {
            ApplicationId = _id
        };
    }
}