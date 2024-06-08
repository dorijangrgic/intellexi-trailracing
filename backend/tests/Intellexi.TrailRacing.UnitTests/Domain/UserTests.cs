using System.ComponentModel;
using FluentAssertions;
using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;
using Intellexi.TrailRacing.UnitTests.Domain.Fixtures;

namespace Intellexi.TrailRacing.UnitTests.Domain;

internal class UserTests : UserTestsFixture
{
    [TestCaseSource(nameof(Create_ShouldThrowArgumentNullException_TestCases))]
    public void Create_ShouldThrowArgumentNullException(
        string firstName,
        string lastName,
        string email,
        DateTime? dateOfBirth,
        UserRole role)
    {
        // Act
        Action action = () => User.Create(
            firstName,
            lastName,
            email,
            dateOfBirth,
            role,
            TimeProvider.System);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestCaseSource(nameof(Create_ShouldThrowArgumentException_TestCases))]
    public void Create_ShouldThrowArgumentException(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        UserRole role)
    {
        // Act
        Action action = () => User.Create(
            firstName,
            lastName,
            email,
            dateOfBirth,
            role,
            TimeProvider.System);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [TestCaseSource(nameof(Create_ShouldThrowInvalidEnumArgumentException_TestCases))]
    public void Create_ShouldThrowInvalidEnumArgumentException(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        UserRole role)
    {
        // Act
        Action action = () => User.Create(
            firstName,
            lastName,
            email,
            dateOfBirth,
            role,
            TimeProvider.System);

        // Assert
        action.Should().Throw<InvalidEnumArgumentException>();
    }

    [TestCaseSource(nameof(Create_ShouldCreateObject_TestCases))]
    public void Create_ShouldCreateObject(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        UserRole role)
    {
        // Act
        var user = User.Create(
            firstName,
            lastName,
            email,
            dateOfBirth,
            role,
            TimeProvider.System);

        // Assert
        user.Id.Should().NotBe(Guid.Empty);
        user.FirstName.Should().Be(firstName);
        user.LastName.Should().Be(lastName);
        user.Email.Should().Be(email);
        user.DateOfBirth.Should().Be(dateOfBirth);
        user.Role.Should().Be(role);
    }
}