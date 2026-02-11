using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Prato;

namespace api.Services.Interfaces
{
    public class PratoService : IPratoService
    {
        private readonly ApplicationDBContext _context;

        public PratoService (ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<PratoReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PratoReadDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PratoReadDto> CreateAsync(PratoCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, PratoCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}