using HandlingExtinguishers.DTO.Request;
using HandlingExtinguishers.DTO.Response;

namespace HandlingExtinguishers.Contracts.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthenticationResponseDto> LoginUser(LoginRequestDto loginRequest);  
        Task<AuthenticationResponseDto> RegisterUser(RegisterUserRequestDto registerUser);  
    }
}
