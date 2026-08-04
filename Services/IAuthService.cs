using InterviewPrepApp.DTOs.Auth;

namespace InterviewPrepApp.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Register(RegisterDTO registerDTO);

        Task<AuthResponseDTO> Login(LoginDTO loginDTO);
    }
}