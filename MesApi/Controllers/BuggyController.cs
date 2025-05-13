// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MesApi.Dto;
// using MesApi.Models;
// using MesApi.Services;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http.Connections;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers
// {
//     public class BuggyController(DataContext context) : BaseApiController
//     {
//         [Authorize]
//         [HttpGet("auth")]
//         public ActionResult<string> GetAuth()
//         {
//             return "Secret text";
//         }

//         [HttpGet("not-found")]
//         public ActionResult<AppUser> GetNotFound()
//         {
//             var uss = context.Users.Find(-1);
//             if (uss == null) return NotFound();
//             return uss;
//         }


//         [HttpGet("server-error")]
//         public ActionResult<AppUser> GetServerError()
//         {
//             var uss = context.Users.Find(-1) ?? throw new Exception("Bad thing - brutto brutto brutto!!");
//             return uss;

//         }

//         [HttpGet("bad-request")]
//         public ActionResult<string> GetBadRequest()
//         {
//             return BadRequest("Bad request- non è una bella richiesta");
//         }

//     }
// }