using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enums;

namespace api.Dtos.Encomenda
{
    public class EncomendaUpdateDto
    {
        public int ClienteId { get; set; }
        public int TrabalhadorId { get; set; }
        public EstadoEncomenda Estado { get; set; }
        public List<PratoQuantidadeDto>? Pratos { get; set; }
    }
}