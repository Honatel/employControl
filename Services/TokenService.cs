using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using employesControl_V2.Models;
using Microsoft.IdentityModel.Tokens;

namespace employesControl_V2.Services
{
    public static class TokenService
    {
        public static string GenereteToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                }),

                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDesciptor);
            return tokenHandler.WriteToken(token);
        }
    }
}