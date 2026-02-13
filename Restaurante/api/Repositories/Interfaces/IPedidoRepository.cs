using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task AddAsync(Pedido pedido);
    }
}