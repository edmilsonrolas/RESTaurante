using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Encomenda;
using api.Models;

namespace api.Mappers
{
    public static class EncomendaMappers
    {
        public static EncomendaReadDto ToEncomendaReadDto(this Encomenda encomendaModel)
        {
            return new EncomendaReadDto
            {
                Id = encomendaModel.EncomendaId,
                Cliente = encomendaModel.Cliente!.Nome,
                DataEncomenda = encomendaModel.DataEncomenda,
                Estado = encomendaModel.Estado,

                Pratos = encomendaModel.Pratos!
                    .Select(pe => new EncomendaPratoReadDto
                    {
                        PratoId = pe.PratoId,
                        PratoNome = pe.Prato!.Nome,
                        Quantidade = pe.Quantidade,
                        PrecoUnitario = pe.PrecoUnitario,
                        Subtotal = pe.Subtotal
                    }).ToList(),

                ValorTotal = encomendaModel.ValorTotal
            };
        }
    }
}