using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Repositories.Interfaces
{
    public interface IPratoRepository
    {
        Task<IEnumerable<Prato>> GetAllAsync();
        Task<Prato?> GetByIdAsync(int id);
        Task AddAsync(Prato prato);
        Task UpdateAsync();
        Task DeleteAsync(Prato prato);
        Task<bool> ExistsAsync(int id);
    }
}