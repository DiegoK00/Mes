using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MesApi.Models
{
    public class Commesse
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int IdCliente { get; set; }

        [Column("IdCliente")]
        [ForeignKey("IdCliente")]
        public virtual required Clienti Clienti { get; set; }

    }
}