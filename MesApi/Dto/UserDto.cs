using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MesApi.Dto
{
    public class UserDto
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public string Password { get; set; } = "";
        public required string Token { get; set; }
        public string Nome { get; set; } = "";
        public string Cognome { get; set; } = "";
        public string Description { get; set; } = "";
        public string photo { get; set; } = "";

    }
}