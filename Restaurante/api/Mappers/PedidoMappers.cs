using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Pedido;
using api.Models;

namespace api.Mappers
{
    public static class PedidoMappers
    {
        public static PedidoReadDto ToPedidoReadDto(this Pedido PedidoModel)
        {
            return new PedidoReadDto
            {
                PedidoId = PedidoModel.PedidoId,
                Cliente = PedidoModel.Cliente!.Nome,
                DataPedido = PedidoModel.DataPedido,
                Estado = PedidoModel.Estado,

                Pratos = PedidoModel.Pratos!
                    .Select(pe => new PedidoPratoReadDto
                    {
                        PratoId = pe.PratoId,
                        PratoNome = pe.Prato!.Nome,
                        Quantidade = pe.Quantidade,
                        PrecoUnitario = pe.PrecoUnitario,
                        Subtotal = pe.Subtotal
                    }).ToList(),

                ValorTotal = PedidoModel.ValorTotal
            };
        }
    }
}