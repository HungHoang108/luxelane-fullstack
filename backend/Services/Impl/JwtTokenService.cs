using System.Text;
using Luxelane.DTOs.UserDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Luxelane.Services.Impl
{

    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public JwtTokenService(IConfiguration config, UserManager<User> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<UserSignInResponseDTO> GenerateTokenAsync(User user)
        {
            //Payload
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"]),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),

            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secret = _config.GetValue<string>("Jwt:Secret");
            var signingKey = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!)),
                SecurityAlgorithms.HmacSha256
            );

            var expiration = DateTime.Now.AddHours(1);

            // Token description
            var tokenDescriptor = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingKey
            );

            var token = new JwtSecurityTokenHandler();

            var result = new UserSignInResponseDTO
            {
                Token = token.WriteToken(tokenDescriptor), 
                Expiration = expiration,
            };

            return result;
        }
    }
}