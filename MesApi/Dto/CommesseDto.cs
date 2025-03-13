using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MesApi.Dto
{
    public class CommesseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? IdCliente { get; set; }
        public string? RagioneSociale { get; set; }

    }
}