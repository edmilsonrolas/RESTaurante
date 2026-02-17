using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Trabalhador : Pessoa
    {
        public string Cargo { get; set; } = string.Empty;
        public DateTime DataContratacao { get; set; } = DateTime.Now;
        
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}