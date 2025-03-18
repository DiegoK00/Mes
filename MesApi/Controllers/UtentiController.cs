using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MesApi.Dto;
using MesApi.Models;
using MesApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MesApi.Controllers
{
    [ApiController]
    [Route("Utenti")]
    public class UtentiController(IUserRepository utentiRepository, IMapper mapper) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUtenti()
        {
            var utente = await utentiRepository.GetUtentiAsync();

            return Ok(mapper.Map<IEnumerable<UserDto>>(utente));

        }

        [HttpGet("{Utente}")] // commesse/DescCommessa ( controllo il like ) 
        public async Task<ActionResult<UserDto>> GetUtenti(string Utente)
        {
            var user = await utentiRepository.GetUtenteAsync(Utente);

            if (user == null) return NotFound();

            return mapper.Map<UserDto>(user);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] UserDto utente)
        {

            // var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (username == null) return BadRequest("Utente non validato!");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var temp = await utentiRepository.GetUtenteAsync(utente.Username);
            if (temp != null) return Conflict("Esiste un utente col nome uguale!");

            if (utente == null) return NotFound();
            var cc = mapper.Map<Utenti>(utente);

            if (! await utentiRepository.InsertAsync(cc)) return NoContent();

            // return BadRequest("aggiunta commmessa fallita.");
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserDto utente)
        {

            // var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (username == null) return BadRequest("Utente non validato!");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tmp = await utentiRepository.GetUtenteAsync(utente.Username);
            if (tmp == null) return NotFound("Non si riesce a trovare l'utente!");

            // x forzare l'aggiornamento
            // commesseRepository.Update(user); 

            var cc = mapper.Map<Utenti>(utente);
            if (! await utentiRepository.UpdateAsync(cc)) return NoContent();

            // return BadRequest("aggiornamento commmessa fallita.");
            return Ok();

        }

        [HttpDelete("{Username}")]
        public async Task<ActionResult> DeleteUtente(string Username)
        {

            var tmpToDelete = await utentiRepository.GetUtenteAsync(Username);

            if (tmpToDelete == null) return NotFound($"Non si riesce a trovare l'utente nome : {Username}!");

            if (await utentiRepository.DeleteUtente(tmpToDelete)) return Ok();
            return BadRequest();

        }

    }
}