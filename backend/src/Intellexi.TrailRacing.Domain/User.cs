namespace Intellexi.TrailRacing.Domain;

public class User
{
    public Guid Id { get; init; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public UserRole Role { get; private set; }
    
    private User(Guid id, string firstName, string lastName, string email, DateTime dateOfBirth, UserRole role)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DateOfBirth = dateOfBirth;
        Role = role;
    }
    
    public static User Create(string firstName, string lastName, string email, DateTime dateOfBirth, UserRole role)
    {
        return new User(Guid.NewGuid(), firstName, lastName, email, dateOfBirth, role);
    }
}