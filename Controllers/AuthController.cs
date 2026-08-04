using InterviewPrepApp.DTOs.Auth;
using InterviewPrepApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPrepApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IAuthService authService,
            ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.Register(registerDTO);

                _logger.LogInformation("User registered successfully.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while registering.");

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _authService.Login(loginDTO);

                _logger.LogInformation("User logged in successfully.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Login failed.");

                return Unauthorized(ex.Message);
            }
        }
    }
}