using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PratoPedido
    {
        public int PratoPedidoId { get; set; }
        public int PedidoId { get; set; }
        public int PratoId { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        // Navegação 
        public Pedido? Pedido { get; set; }
        public Prato? Prato { get; set; }
    }
}