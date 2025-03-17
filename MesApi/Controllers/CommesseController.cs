using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNetCore.Mvc;
using MesApi.Dto;
using MesApi.Repository;
using MesApi.Helpers;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using MesApi.Models;


namespace MesApi.Controllers
{
    //  [Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("commesse")]
    public class CommesseController(ICommesseRepository commesseRepository, IMapper mapper) : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommesseDto>>> GetCommesse()
        {
            var comm = await commesseRepository.GetCommesseAsync();

            return Ok(mapper.Map<IEnumerable<CommesseDto>>(comm));

        }

        // [HttpGet("Id:int")]
        // //  [HttpGet("{id:int}")] // commesse/id 
        // public async Task<ActionResult<CommesseDto>> GetCommessa(int id)
        // {
        //     var comm = await commesseRepository.GetCommessaAsync(id);
        //     if (comm == null) return NotFound();
        //     return mapper.Map<CommesseDto>(comm);
        // }

        [HttpGet("{Id}/{Commessa}")] // commesse/nome/Id
        public async Task<ActionResult<CommesseDto>> GetCommessa(int Id,string Commessa)
        {
            Commesse? comm;
            if (Id == 0)
            {
                comm = await commesseRepository.GetCommessaNomeAsync(Commessa);
            }
            else
            {
                comm = await commesseRepository.GetCommessaAsync(Id);
            }

            if (comm == null) return NotFound();

            return mapper.Map<CommesseDto>(comm);
        }

        [HttpGet("{Commessa}")] // commesse/DescCommessa ( controllo il like ) 
        public async Task<ActionResult<CommesseDto>> GetCommessa(string Commessa)
        {
            var comm = await commesseRepository.GetCommessaNomeAsync(Commessa);

            if (comm == null) return NotFound();

            return mapper.Map<CommesseDto>(comm);
        }

        [HttpPost]
        public async Task<ActionResult> InsertCommessa([FromBody] CommesseDto comm)
        {

            // var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (username == null) return BadRequest("Utente non validato!");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var temp = await commesseRepository.GetCommessaNomeAsync(comm.Name);
            if (temp != null) return Conflict("Esiste una commessa col nome uguale!");

            if (comm == null) return NotFound();
            var cc = mapper.Map<Commesse>(comm);

            if (await commesseRepository.InsertAsync(cc)) return NoContent();

            // return BadRequest("aggiunta commmessa fallita.");
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateCommessa(CommesseDto comm)
        {

            // var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // if (username == null) return BadRequest("Utente non validato!");

            var commessa = await commesseRepository.GetCommessaAsync(comm.Id);
            if (commessa == null) return NotFound("Non si riesce a trovare la commessa!");

            // x forzare l'aggiornamento
            // commesseRepository.Update(user);
            mapper.Map(comm, commessa);

            if (await commesseRepository.UpdateAsync(commessa)) return NoContent();

            // return BadRequest("aggiornamento commmessa fallita.");
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCommessa(int Id)
        {

            var commmessaToDelete = await commesseRepository.GetCommessaAsync(Id);
            if (commmessaToDelete == null) return NotFound($"Non si riesce a trovare la commessa id : {Id}!");

            if (await commesseRepository.Delete(commmessaToDelete)) return Ok();
            return BadRequest();

        }


    }
}