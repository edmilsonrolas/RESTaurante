using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using api.Repositories.Interfaces;

namespace api.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDBContext _context;
        public PedidoRepository (ApplicationDBContext context)
        {
            _context = context;
        }
        
        public Task AddAsync(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pedido>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pedido?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}