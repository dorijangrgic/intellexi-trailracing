using FluentAssertions;

namespace Intellexi.TrailRacing.Domain.UnitTest;

public class UserTests
{
    [Test]
    public void Create_ShouldCreateUser()
    {
        // Arrange
        var birthDate = new DateTime(1990, 1, 1);

        // Act
        var user = User.Create("John", "Doe", "jdoe@mail.com", birthDate, UserRole.Applicant);

        // Assert
        user.Id.Should().NotBe(Guid.Empty);
        user.FirstName.Should().Be("John");
        user.LastName.Should().Be("Doe");
        user.Email.Should().Be("jdoe@mail.com");
        user.DateOfBirth.Should().Be(birthDate);
        user.Role.Should().Be(UserRole.Applicant);
    }
}