using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /**
        Mesmo que o cliente não se registe formalmente, esta entidade ajuda a manter histórico de pedidos.
    */
    public class Cliente : Pessoa
    {
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}