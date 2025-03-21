using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MesApi.Dto;
using MesApi.Models;
using MesApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MesApi.Controllers
{
    [ApiController]
    [Route("Account")]

    public class AccountController(DataSourceContext context, ITokenService tokenServices,
        IMapper mapper) : BaseController
    {

        [HttpPost("register")] // Account/ register
        public async Task<ActionResult<UserDto>> Register(UserDto reg)
        {

            if (await UserExists(reg.Username)) return BadRequest("Il nome esiste già!!");

            using var hmac = new HMACSHA512();

            var user = mapper.Map<Utenti>(reg);
            user.Username = reg.Username.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(reg.Password));
            user.PasswordSalt = hmac.Key;
            user.Password = reg.Password;

            context.Utenti.Add(user);
            await context.SaveChangesAsync();
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenServices.CreateToken(user) 

            };

        }

        private async Task<bool> UserExists(string UserName)
        {
            return await context.Utenti.AnyAsync(x => x.Username.ToLower() == UserName.ToLower());
        }

   [HttpPost("login")] // Account/ login
        public async Task<ActionResult<UserDto>> Login(UserDto loginDto)
        {
            var user = await context.Utenti.FirstOrDefaultAsync(x =>
                    x.Username == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < 10; i++)
            {
                if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password!");
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenServices.CreateToken(user),
                Nome = user.Nome,
                Cognome = user.Cognome
            };

        }
    }
}