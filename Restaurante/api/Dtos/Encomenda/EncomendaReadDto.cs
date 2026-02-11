using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Encomenda
{
    public class EncomendaReadDto
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime DataEncomenda { get; set; }
        public EstadoEncomenda Estado { get; set; }
        public List<EncomendaPratoReadDto> Pratos { get; set; } = new();
        public decimal ValorTotal { get; set; }
    }
}