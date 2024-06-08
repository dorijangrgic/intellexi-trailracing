using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.Tests.Shared.Builders;

public class RaceTestBuilder
{
    private string _name;
    private RaceDistance _distance;

    public static RaceTestBuilder Default()
    {
        return new RaceTestBuilder()
            .WithName("raceName")
            .WithDistance(RaceDistance.FiveKilometers);
    }
    
    public RaceTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    
    public RaceTestBuilder WithDistance(RaceDistance distance)
    {
        _distance = distance;
        return this;
    }

    public Race Build()
    {
        return Race.Create(_name, _distance);
    }
}