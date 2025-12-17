using Ajman.Statistics.Application.Interfaces;
using Ajman.Statistics.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ajman.Statistics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        // 1️⃣ Inject the AuthService via constructor
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // 2️⃣ Login endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var tokens = await _authService.LoginAsync(request);
            return Ok(tokens);
        }

        // 3️⃣ Refresh endpoint
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenRefreshRequest request)
        {
            var newAccessToken = await _authService.RefreshAsync(request.RefreshToken);
            return Ok(new { AccessToken = newAccessToken });
        }
    }

    // 4️⃣ Request model for refresh token
    public class TokenRefreshRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
