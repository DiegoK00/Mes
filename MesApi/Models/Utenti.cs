using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MesApi.Models
{
    public class Utenti
    {
        [Key]
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? Token { get; set; }


    }
}