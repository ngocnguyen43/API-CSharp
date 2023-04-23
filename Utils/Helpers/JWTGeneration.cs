using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi2.Models;

namespace WebAPI.Utils.Helpers
{
    public class JWTGeneration
    {
        public static JwtSecurityToken get(User user)
        {
            JwtSecurityToken token = new JwtSecurityToken(
                //issuer: "minhngoc",
                //audience: "minhngoc",
                claims: new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(ClaimTypes.Role,user.Role),
                },
                //expires:DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(
                        key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
                        algorithm: SecurityAlgorithms.HmacSha256
                    )

                );
            return token;
        }
    }
}
