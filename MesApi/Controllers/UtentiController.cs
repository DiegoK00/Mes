using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MesApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MesApi.Controllers
{
        [ApiController]
    [Route("Utenti")]
    public class UtentiController : Controller
    {
          [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetCommesse()
        {
            var comm = await UtentiRepository.GetCommesseAsync();

            return Ok(Mapper.Map<IEnumerable<CommesseDto>>(comm));

        }

    }
 
}