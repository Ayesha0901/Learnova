using BCrypt.Net;
using InterviewPrepApp.DTOs.Auth;
using InterviewPrepApp.Models;
using InterviewPrepApp.Repositories;

namespace InterviewPrepApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthService(
            IAuthRepository authRepository,
            IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDTO> Register(RegisterDTO registerDTO)
        {
            // Check Email Exists

            var existingUser =
                await _authRepository.GetUserByEmail(registerDTO.Email);

            if (existingUser != null)
                throw new Exception("Email already exists.");

            // Hash Password

            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            // Create User

            var user = new UserModel
            {
                UserId = Guid.NewGuid(),
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                PasswordHash = hashedPassword,
                IsActive = true
            };

            var result = await _authRepository.Register(user);

            // Generate Token

            string token = _jwtService.GenerateToken(result);

            return new AuthResponseDTO
            {
                Token = token,
                UserName = result.UserName,
                Email = result.Email,
                Expiration = DateTime.UtcNow.AddMinutes(120)
            };
        }

        public async Task<AuthResponseDTO> Login(LoginDTO loginDTO)
        {
            var user =
                await _authRepository.GetUserByEmail(loginDTO.Email);

            if (user == null)
                throw new Exception("Invalid Email or Password.");

            bool validPassword =
                BCrypt.Net.BCrypt.Verify(
                    loginDTO.Password,
                    user.PasswordHash);

            if (!validPassword)
                throw new Exception("Invalid Email or Password.");

            string token = _jwtService.GenerateToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                UserName = user.UserName,
                Email = user.Email,
                Expiration = DateTime.UtcNow.AddMinutes(120)
            };
        }
    }
}