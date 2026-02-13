using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Pedido;

namespace api.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoReadDto>> GetAllAsync();
        Task<PedidoReadDto> GetByIdAsync(int id);
        Task<PedidoReadDto> CreateAsync(PedidoCreateDto dto);
    }
}