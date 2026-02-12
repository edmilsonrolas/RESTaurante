using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Pedido
{
    public class PedidoCreateDto
    {
        public int ClienteId { get; set; }
        public int TrabalhadorId { get; set; }
        public List<PratoQuantidadeDto>? Pratos { get; set; } 

    }

    public class PratoQuantidadeDto
    {
        public int PratoId { get; set; }
        public int Quantidade { get; set; }
    }
}