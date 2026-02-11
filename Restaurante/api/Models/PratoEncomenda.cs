using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PratoEncomenda
    {
        public int PratoEncomendaId { get; set; }
        public int EncomendaId { get; set; }
        public int PratoId { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        // Navegação 
        public Encomenda? Encomenda { get; set; }
        public Prato? Prato { get; set; }
    }
}