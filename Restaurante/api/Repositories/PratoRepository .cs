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
    public class PratoRepository : IPratoRepository
    {
        private readonly ApplicationDBContext _context;
        public PratoRepository (ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prato>> GetAllAsync()
            => await _context.Pratos.ToListAsync();

        public async Task<Prato?> GetByIdAsync(int id)
            => await _context.Pratos.FindAsync(id);

        public async Task AddAsync(Prato prato)
        {
            _context.Pratos.Add(prato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync()
            => await _context.SaveChangesAsync();

        public async Task DeleteAsync(Prato prato)
        {
            _context.Pratos.Remove(prato);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
            => await _context.Pratos.AnyAsync(p => p.PratoId == id);
    }
}