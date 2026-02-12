using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Pedido
{
    public class PedidoReadDto
    {
        public int PedidoId { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime DataPedido { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<PedidoPratoReadDto> Pratos { get; set; } = new();
        public decimal ValorTotal { get; set; }
    }
}