using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Pedido;
using api.Services.Interfaces;

namespace api.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDBContext _context;
        public PedidoService(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<PedidoReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PedidoReadDto> GetByIdAsync()
        {
            throw new NotImplementedException();
        }
        
        public Task<PedidoReadDto> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}