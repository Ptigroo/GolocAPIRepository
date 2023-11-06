using GolocAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GolocAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public TokenService(UserManager<User> manager, IConfiguration config)
        {
            _configuration = config;
            _userManager = manager;
        }
        public async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Pseudo)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenOptions = new JwtSecurityToken
            (
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(285),
                signingCredentials: creds

            );
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
