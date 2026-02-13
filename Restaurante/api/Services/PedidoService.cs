using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Pedido;
using api.Enums;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDBContext _context;
        public PedidoService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PedidoReadDto>> GetAllAsync()
        {
            var pedidos = await _context.Pedidos
                .Include(pd => pd.Cliente)
                .Include(pd => pd.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .ToListAsync();

            return pedidos.Select(pd => pd.ToPedidoReadDto());
        }

        public async Task<PedidoReadDto?> GetByIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(pd => pd.Cliente)
                .Include(pd => pd.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .FirstOrDefaultAsync(pd => pd.PedidoId == id);

            return pedido?.ToPedidoReadDto();
        }
        
        public async Task<PedidoReadDto> CreateAsync(PedidoCreateDto dto)
        {
            if (dto.Pratos == null || !dto.Pratos.Any())
                throw new ArgumentException("O pedido deve conter pelo menos um prato.");

            var pedido = new Pedido
            {
                ClienteId = dto.ClienteId,
                TrabalhadorId = dto.TrabalhadorId,
                Estado = EstadoPedido.Pendente,
                DataPedido = DateTime.Now,
                ValorTotal = 0
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            decimal total = 0;

            foreach (var item in dto.Pratos!)
            {
                var prato = await _context.Pratos.FindAsync(item.PratoId);
                if (prato == null)
                    throw new KeyNotFoundException($"Prato com ID {item.PratoId} não existe");

                var subtotal = prato.Preco * item.Quantidade;
                total += subtotal;

                _context.PratosPedido.Add(new PratoPedido
                {
                    PedidoId = pedido.PedidoId,
                    PratoId = prato.PratoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = prato.Preco,
                    Subtotal = subtotal
                });
            }

            pedido.ValorTotal = total;
            await _context.SaveChangesAsync();

            return (await GetByIdAsync(pedido.PedidoId))!;
        }
    }
}