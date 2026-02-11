using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    /**
        Mesmo que o cliente não se registe formalmente, esta entidade ajuda a manter histórico de encomendas.
    */
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Endereco { get; set; } = string.Empty;
        public ICollection<Encomenda>? Encomendas { get; set; }
    }
}