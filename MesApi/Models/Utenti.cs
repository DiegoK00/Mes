using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MesApi.Models
{
    [PrimaryKey(nameof(Id), nameof(Username))]
    [Index(nameof(Username), IsUnique = true)]
    public class Utenti : Indirizzi
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }

        [Key, Column(Order = 1)]
        public required string Username { get; set; }

        public required string Password { get; set; }
        public required byte[] PasswordHash { get; set; } = [];
        public required byte[] PasswordSalt { get; set; } = [];
        public string? Token { get; set; }
        public string Nome { get; set; } = "";
        public string Cognome { get; set; } = "";

    }
}