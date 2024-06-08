using FluentAssertions;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.UnitTests.Domain.Fixtures;

namespace Intellexi.TrailRacing.UnitTests.Domain;

internal class ApplicationTests : ApplicationTestsFixture
{
    [TestCaseSource(nameof(Create_ShouldThrowArgumentNullException_TestCases))]
    public void Create_ShouldThrowArgumentNullException(
        string firstName,
        string lastName,
        string club)
    {
        // Act
        Action action = () => Application.Create(firstName, lastName, club, Guid.NewGuid());

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Create_ShouldThrowArgumentException_TestCases))]
    public void Create_ShouldThrowArgumentException(
        string firstName,
        string lastName,
        string club)
    {
        // Act
        Action action = () => Application.Create(firstName, lastName, club, Guid.NewGuid());

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [TestCaseSource(nameof(Create_ShouldCreateObject_TestCases))]
    public void Create_ShouldCreateObject(
        string firstName,
        string lastName,
        string club,
        Guid raceId)
    {
        // Act
        var application = Application.Create(firstName, lastName, club, raceId);

        // Assert
        application.Id.Should().NotBe(Guid.Empty);
        application.FirstName.Should().Be(firstName);
        application.LastName.Should().Be(lastName);
        application.Club.Should().Be(club);
        application.RaceId.Should().Be(raceId);
    }
}