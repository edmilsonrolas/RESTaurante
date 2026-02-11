using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Prato;
using api.Models;

namespace api.Mappers
{
    public static class PratoMappers
    {
        public static PratoReadDto ToPratoReadDto(this Prato pratoModel)
        {
            return new PratoReadDto
            {
                Id = pratoModel.PratoId,
                Nome = pratoModel.Nome,
                Descricao = pratoModel.Descricao,
                Preco = pratoModel.Preco,
                Categoria = pratoModel.Categoria,
                Disponivel = pratoModel.Disponivel
            };
        }

        public static Prato ToPratoFromCreateDto(this PratoCreateDto pratoCreateDto)
        {
            return new Prato
            {
                Nome = pratoCreateDto.Nome,
                Descricao = pratoCreateDto.Descricao,
                Preco = pratoCreateDto.Preco,
                Categoria = pratoCreateDto.Categoria
            };
        }
    }
}