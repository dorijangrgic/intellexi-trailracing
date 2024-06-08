using Ardalis.GuardClauses;
using Intellexi.TrailRacing.Domain.Guards;

namespace Intellexi.TrailRacing.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public UserRole Role { get; private set; }
    
    private User(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        UserRole role)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
        Role = role;
    }
    
    public static User Create(
        string firstName,
        string lastName,
        string email,
        DateTime? dateOfBirth,
        UserRole role,
        TimeProvider timeProvider)
    {
        Guard.Against.NullOrWhiteSpace(firstName);
        Guard.Against.LengthOutOfRange(firstName, 1, MaxPropertyLength);
        
        Guard.Against.NullOrWhiteSpace(lastName);
        Guard.Against.LengthOutOfRange(lastName, 1, MaxPropertyLength);
        
        Guard.Against.NullOrWhiteSpace(email);
        Guard.Against.LengthOutOfRange(email, 1, MaxPropertyLength);

        Guard.Against.Null(dateOfBirth);
        Guard.Against.FutureDateOfBirth(dateOfBirth.Value, timeProvider);

        Guard.Against.EnumOutOfRange(role);

        return new(firstName, lastName, email, dateOfBirth.Value, role);
    }
}