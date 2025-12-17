using Ajman.Statistics.Application.Interfaces;
using Ajman.Statistics.Application.Interfaces;
using Ajman.Statistics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajman.Statistics.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenService _jwtTokenService;
        private readonly Dictionary<string, string> _fakeUsers = new()
        {
            { "admin", "password123" },
            { "user", "userpass" }
        };
        public AuthService(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest request)
        {
            // 1️⃣ Validate user credentials
            if (!_fakeUsers.TryGetValue(request.Username, out var pwd) || pwd != request.Password)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            // 2️⃣ Generate access token
            var accessToken = _jwtTokenService.GenerateAccessToken(request.Username, "User"); // assign role

            // 3️⃣ Generate a fake refresh token (for example purposes)
            var refreshToken = Guid.NewGuid().ToString();
                
            // 4️⃣ Return tokens
            var response = new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return await Task.FromResult(response);
        }

        public async Task<string> RefreshAsync(string refreshToken)
        {
            // Example: validate the refresh token here (pseudo code)
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentException("Invalid refresh token");

            // Generate new access token (just for example)
            var username = "user"; // get from refresh token in real scenario
            var role = "admin";    // get from refresh token
            var newAccessToken = _jwtTokenService.GenerateAccessToken(username, role);

            return await Task.FromResult(newAccessToken);
        }
    }
}
