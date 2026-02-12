using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Models
{
    public class Prato
    {
        public int PratoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public CategoriaPrato  Categoria { get; set; }
        public bool Disponivel { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public ICollection<PratoPedido>? Pedidos { get; set; }
    }
}