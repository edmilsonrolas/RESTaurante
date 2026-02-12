using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public int TrabalhadorId { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;
        public EstadoPedido Estado { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

            // Navegação
        public Cliente Cliente { get; set; } = null!;
        public Trabalhador Trabalhador { get; set; } = null!;
        public ICollection<PratoPedido> Pratos { get; set; } = new List<PratoPedido>();
    }
}