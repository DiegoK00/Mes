using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MesApi.Models
{
    public class Utenti : Indirizzi
    {
        [Key]
        public required string Username { get; set; }
        public required string Password { get; set; }
         public required byte[] PasswordHash { get; set; } = [];
         public required byte[] PasswordSalt { get; set; } = [];
        public string? Token { get; set; }
        public string Nome { get; set; } = "";
        public string Cognome { get; set; } = "";

    }
}