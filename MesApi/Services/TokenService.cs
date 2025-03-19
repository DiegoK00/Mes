using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MesApi.Models;
using MesApi.Repository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.IdentityModel.Tokens;

namespace MesApi.Services
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        public string CreateToken(Utenti user)
        {
            var tokenKey = config["TokenKey"] ?? throw new Exception("cannot access alla chiave, non è configurata in appsettings");
            if (tokenKey.Length < 64) throw new Exception("allunga la chiave!!! ");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>(){
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    };
}