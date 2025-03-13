using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MesApi.Models
{
    public class Clienti
    {
        [Key]
        public required int Id { get; set; }
        public required string RagioneSociale { get; set; }
        public string? PIVA { get; set; }
        public string? CodiceFiscale { get; set; }
        public string? Indirizzo { get; set; }
        public string? Località { get; set; }
        public string? Provincia { get; set; }
        public string? Regione { get; set; }
        public string? Nazione { get; set; }

    }
}