using FluentAssertions;

namespace Intellexi.TrailRacing.Domain.UnitTest;

public class RaceTests
{
    [Test]
    public void Create_ShouldCreateRace()
    {
        // Act
        var race = Race.Create("Race", RaceDistance.Marathon);

        // Assert
        race.Id.Should().NotBe(Guid.Empty);
        race.Name.Should().Be("Race");
        race.Distance.Should().Be(RaceDistance.Marathon);
    }

    [Test]
    public void Update_ShouldUpdateRace()
    {
        // Arrange
        var race = Race.Create("Race", RaceDistance.Marathon);

        // Act
        race.Update("New race", RaceDistance.HalfMarathon);

        // Assert
        race.Id.Should().NotBe(Guid.Empty);
        race.Name.Should().Be("New race");
        race.Distance.Should().Be(RaceDistance.HalfMarathon);
    }
}