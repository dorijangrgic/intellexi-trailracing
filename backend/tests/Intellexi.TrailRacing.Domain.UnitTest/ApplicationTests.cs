using FluentAssertions;

namespace Intellexi.TrailRacing.Domain.UnitTest;

public class ApplicationTests
{
    [Test]
    public void Create_ShouldCreateApplication()
    {
        // Act
        var race = Race.Create("Race", RaceDistance.TenKilometers);
        var application = Application.Create("John", "Doe", "TrailRacingClub", race.Id);

        // Assert
        application.Id.Should().NotBe(Guid.Empty);
        application.FirstName.Should().Be("John");
        application.LastName.Should().Be("Doe");
        application.Club.Should().Be("TrailRacingClub");
        application.RaceId.Should().Be(race.Id);
    }
}