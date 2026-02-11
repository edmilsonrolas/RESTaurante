using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Prato;

namespace api.Services.Interfaces
{
    public interface IPratoService
    {
        Task<IEnumerable<PratoReadDto>> GetAllAsync();
        Task<PratoReadDto> GetByIdAsync(int id);
        Task<PratoReadDto> CreateAsync(PratoCreateDto dto);
        Task<bool> UpdateAsync(int id, PratoCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}