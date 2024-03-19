using CoePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoePulse.API.Repositories.Implementation
{
    public class IdentityRepository : IIdentityRepository
    {
        public readonly IConfiguration _config;

        public IdentityRepository(IConfiguration config)
        {
            _config = config;
        }

        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            //create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Id),
            };

            //add roles to claims
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //JWT Security and Token Parameters
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            //get credentials
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //create token
            var token = new JwtSecurityToken(
                               _config["Jwt:Issuer"],
                               _config["Jwt:Audience"],
                               claims,
                               expires: DateTime.Now.AddMinutes(30),
                               signingCredentials: credential
                               );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
