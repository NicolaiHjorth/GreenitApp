namespace Domain.DTOs;

public class UserCreationDto
{
    public string UserName { get; }
    public string Password { get; }
    public int Age { get; }
    public string Email { get; }

    public UserCreationDto(string userName, string password, int age, string email)
    {
        UserName = userName;
        Password = password;
        Age = age;
        Email = email;

    }
}