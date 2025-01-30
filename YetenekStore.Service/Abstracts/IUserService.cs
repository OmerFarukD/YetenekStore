using YetenekStore.Models.Dtos.Users;

namespace YetenekStore.Service.Abstracts;

public interface IUserService
{
    Task<UserResponseDto> CreateUserAsync(RegisterRequestDto register);
    Task<UserResponseDto> LoginAsync(LoginRequestDto login);
    Task<UserResponseDto> GetByEmailAsync(string email);
}