using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Domain;

namespace Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

public class RaceUpdateRequestTestBuilder
{
    private Guid _id;
    private string _name;
    private RaceDistance _distance;

    public static RaceUpdateRequestTestBuilder Default()
    {
        return new RaceUpdateRequestTestBuilder()
            .WithId(Guid.NewGuid())
            .WithName("raceName")
            .WithDistance(RaceDistance.FiveKilometers);
    }
    
    public RaceUpdateRequestTestBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }
    
    public RaceUpdateRequestTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public RaceUpdateRequestTestBuilder WithDistance(RaceDistance distance)
    {
        _distance = distance;
        return this;
    }
    
    public RaceUpdateRequest Build()
    {
        return new RaceUpdateRequest
        {
            RaceId = _id,
            Name = _name,
            Distance = _distance
        };
    }
}