using FTech.Application.DataTransferObjects;
using FTech.Application.DataTransferObjects.Auth;
using FTech.Domain.Entities.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FTech.Application.Services.JWT
{
    public class JWTService : IJWTService
    {
        private readonly JWTOption _jWTOption;

        public JWTService(IConfiguration configuration)
            => _jWTOption = configuration.GetSection("JWT").Get<JWTOption>();

        public TokenDTO GenerateAccessToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jWTOption.Key));

            var token = new JwtSecurityToken(
                issuer: _jWTOption.Issuer,
                audience: _jWTOption.Audience,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_jWTOption.ExpiredInMinutes)),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    key: authSigningKey,
                    algorithm: SecurityAlgorithms.HmacSha256)
                );

            var accesstoken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO { AccessToken = accesstoken };
        }

        public TokenDTO GenerateAccessToken(Driver driver)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", driver.Id.ToString()),
                new Claim("PhoneNumber", driver.PhoneNumber),
                new Claim("LicenseNumber", driver.LicenseNumber)
            };

            var authSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jWTOption.Key));

            var token = new JwtSecurityToken(
                issuer: _jWTOption.Issuer,
                audience: _jWTOption.Audience,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_jWTOption.ExpiredInMinutes)),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    key: authSigningKey,
                    algorithm: SecurityAlgorithms.HmacSha256)
                );

            var accesstoken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenDTO { AccessToken = accesstoken };
        }
    }
}
