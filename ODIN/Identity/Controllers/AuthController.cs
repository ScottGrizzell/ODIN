using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto model)
        {
            // These should be grabbed from some db not hardcoded. 
            if (model.Username == "admin" && model.Password == "password")
            {
                var token = GenerateJwtToken(model.Username, "admin");
                return Ok(new { Token = token });
            }
            else if (model.Username == "user" && model.Password == "password")
            {
                var token = GenerateJwtToken(model.Username, "user");
                return Ok(new { Token = token });

            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username, string role)
        {
            var claims = new[] {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role) 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super_secret_private_key_that_should_never_be_used_in_prod"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: "ODIN.Identity",
            audience: "ODIN.Users",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8), // This should be shorter and I should use a refresh token
            signingCredentials: creds
        );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
