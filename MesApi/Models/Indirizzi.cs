using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesApi.Models
{
    public class Indirizzi
    {
        public string? Indirizzo { get; set; }
        public string? Localita { get; set; }
        public string? Provincia { get; set; }
        public string? Regione { get; set; }
        public string? Nazione { get; set; }
    }
}