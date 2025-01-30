namespace YetenekStore.Models.Dtos.Users;

public sealed class LoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}