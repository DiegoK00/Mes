using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MesApi.Models
{
    public class Clienti : Indirizzi
    {
        [Key]
        public required int Id { get; set; }
        public required string RagioneSociale { get; set; }
        public string? PIVA { get; set; }
        public string? CodiceFiscale { get; set; }
        
    }
}