using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Telefone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Endereco { get; set; }
        public bool Activo { get; set; } = true;
    }
}