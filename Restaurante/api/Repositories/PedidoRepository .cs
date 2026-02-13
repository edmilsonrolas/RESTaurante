using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDBContext _context;
        public PedidoRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
            => await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .ToListAsync();

        public async Task<Pedido?> GetByIdAsync(int id)
            => await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .FirstOrDefaultAsync(p => p.PedidoId == id);
    }
}