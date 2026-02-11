using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    public class Encomenda
    {
        public int EncomendaId { get; set; }
        public int ClienteId { get; set; }
        public int TrabalhadorId { get; set; }
        public DateTime DataEncomenda { get; set; } = DateTime.Now;
        public EstadoEncomenda Estado { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

            // Navegação
        public Cliente Cliente { get; set; } = null!;
        public Trabalhador Trabalhador { get; set; } = null!;
        public ICollection<PratoEncomenda> Pratos { get; set; } = new List<PratoEncomenda>();
    }
}