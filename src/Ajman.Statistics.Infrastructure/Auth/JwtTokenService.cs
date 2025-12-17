using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajman.Statistics.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ajman.Statistics.Infrastructure.Auth
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _key;

        public JwtTokenService(string key)
        {
            _key = key;
        }

        public string GenerateAccessToken(string username, string role)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim("role", role)
        };

            var token = new JwtSecurityToken(
                issuer: "Samsotech-Ajman-API",
                audience: "MOE-Backoffice-System",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
