using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BLL.DTO.Users;
using Microsoft.IdentityModel.Tokens;

namespace MinimalWebAPI.WebApp.Helpers
{
	public class JWTTokenHelper
	{
		public static string CreateToken(UserDTO userDTO, IConfiguration config)
        {
            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sid, userDTO.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, userDTO.Email),
        };

            var claimsIdentity = new ClaimsIdentity(claims);
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
	}
}

