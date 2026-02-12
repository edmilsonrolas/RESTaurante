using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Pedido
{
    public class PedidoUpdateDto
    {
        public int ClienteId { get; set; }
        public int TrabalhadorId { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<PratoQuantidadeDto>? Pratos { get; set; }
    }
}