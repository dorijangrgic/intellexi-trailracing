using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;

namespace Intellexi.TrailRacing.Tests.Shared.Builders;

public class UserTestBuilder
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private DateTime _dateOfBirth;
    private UserRole _role;

    public static UserTestBuilder Default()
    {
        return new UserTestBuilder()
            .WithFirstName("John")
            .WithLastName("Doe")
            .WithEmail("jdoe@mail.com")
            .WithDateOfBirth(new DateTime(1998, 16, 01))
            .WithUserRole(UserRole.Applicant);
    }
    
    public UserTestBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }
    
    public UserTestBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }
    
    public UserTestBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }
    
    public UserTestBuilder WithDateOfBirth(DateTime dateOfBirth)
    {
        _dateOfBirth = dateOfBirth;
        return this;
    }
    
    public UserTestBuilder WithUserRole(UserRole role)
    {
        _role = role;
        return this;
    }
    
    public User Build(TimeProvider timeProvider)
    {
        return User.Create(_firstName, _lastName, _email, _dateOfBirth, _role, timeProvider);
    }
}