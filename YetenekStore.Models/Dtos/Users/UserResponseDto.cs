namespace YetenekStore.Models.Dtos.Users;

public sealed class UserResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string? PhoneNumber { get; set; }
}