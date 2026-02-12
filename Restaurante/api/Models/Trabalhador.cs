using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Trabalhador
    {
        public int TrabalhadorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}