using Intellexi.TrailRacing.Application.RaceManagement.Requests;

namespace Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

public class RaceDeleteRequestTestBuilder
{
    private Guid _id;

    public static RaceDeleteRequestTestBuilder Default()
    {
        return new RaceDeleteRequestTestBuilder().WithId(Guid.NewGuid());
    }

    public RaceDeleteRequestTestBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public RaceDeleteRequest Build()
    {
        return new RaceDeleteRequest
        {
            RaceId = _id
        };
    }
}