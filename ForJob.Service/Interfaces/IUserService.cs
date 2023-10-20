using ForJob.Service.DTOs.Users;

namespace ForJob.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> RegisterAsync(UserRegisterDto dto);
    Task<UserResultDto> LoginAsync(UserLoginDto dto);
}
