using Intellexi.TrailRacing.Application.RaceManagement.Requests;
using Intellexi.TrailRacing.Domain;

namespace Intellexi.TrailRacing.Tests.Shared.Builders.Requests;

public class RaceCreateRequestTestBuilder
{
    private string _name;
    private RaceDistance _distance;

    public static RaceCreateRequestTestBuilder Default()
    {
        return new RaceCreateRequestTestBuilder()
            .WithName("raceName")
            .WithDistance(RaceDistance.FiveKilometers);
    }
    
    public RaceCreateRequestTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public RaceCreateRequestTestBuilder WithDistance(RaceDistance distance)
    {
        _distance = distance;
        return this;
    }
    
    public RaceCreateRequest Build()
    {
        return new RaceCreateRequest
        {
            Name = _name,
            Distance = _distance
        };
    }
}