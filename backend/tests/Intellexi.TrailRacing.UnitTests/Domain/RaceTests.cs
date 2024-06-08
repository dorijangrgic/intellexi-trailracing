using System.ComponentModel;
using FluentAssertions;
using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.Tests.Shared.Builders;
using Intellexi.TrailRacing.UnitTests.Domain.Fixtures;

namespace Intellexi.TrailRacing.UnitTests.Domain;

internal class RaceTests : RaceTestsFixture
{
    [TestCaseSource(nameof(Create_ShouldThrowArgumentNullException_TestCases))]
    public void Create_ShouldThrowArgumentNullException(
        string name,
        RaceDistance distance)
    {
        // Act
        Action action = () => Race.Create(name, distance);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Create_ShouldThrowArgumentException_TestCases))]
    public void Create_ShouldThrowArgumentException(
        string name,
        RaceDistance distance)
    {
        // Act
        Action action = () => Race.Create(name, distance);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [TestCaseSource(nameof(Create_ShouldThrowInvalidEnumArgumentException_TestCases))]
    public void Create_ShouldThrowInvalidEnumArgumentException(
        string name,
        RaceDistance distance)
    {
        // Act
        Action action = () => Race.Create(name, distance);

        // Assert
        action.Should().Throw<InvalidEnumArgumentException>();
    }

    [TestCaseSource(nameof(Create_ShouldCreateObject_TestCases))]
    public void Create_ShouldCreateObject(
        string name,
        RaceDistance distance)
    {
        // Act
        var race = Race.Create(name, distance);

        // Assert
        race.Id.Should().NotBe(Guid.Empty);
        race.Name.Should().Be(name);
        race.Distance.Should().Be(distance);
    }

    [TestCaseSource(nameof(Update_ShouldThrowArgumentNullException_TestCases))]
    public void Update_ShouldThrowArgumentNullException(
        string name,
        RaceDistance distance)
    {
        // Act
        Action action = () => Race.Create(name, distance);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Update_ShouldThrowArgumentException_TestCases))]
    public void Update_ShouldThrowArgumentException(
        string name,
        RaceDistance distance)
    {
        // Act
        Action action = () => Race.Create(name, distance);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [TestCaseSource(nameof(Update_ShouldThrowInvalidEnumArgumentException_TestCases))]
    public void Update_ShouldThrowInvalidEnumArgumentException(
        string name,
        RaceDistance distance)
    {
        // Act
        Action action = () => Race.Create(name, distance);

        // Assert
        action.Should().Throw<InvalidEnumArgumentException>();
    }

    [TestCaseSource(nameof(Update_ShouldUpdateObject_TestCases))]
    public void Update_ShouldUpdateObject(
        string name,
        RaceDistance distance)
    {
        // Arrange
        var race = RaceTestBuilder.Default().Build();

        // Act
        race.Update(name, distance);

        // Assert
        race.Id.Should().NotBe(Guid.Empty);
        race.Name.Should().Be(name);
        race.Distance.Should().Be(distance);
    }
}