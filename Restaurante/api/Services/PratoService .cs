using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Prato;
using api.Mappers;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class PratoService : IPratoService
    {
        private readonly ApplicationDBContext _context;

        public PratoService (ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PratoReadDto>> GetAllAsync()
        {
            return await _context.Pratos
                .Select(p => p.ToPratoReadDto())
                .ToListAsync();
        }

        public async Task<PratoReadDto?> GetByIdAsync(int id)
        {
            var prato = await _context.Pratos.FindAsync(id);
            return prato?.ToPratoReadDto();
        }

        public async Task<PratoReadDto> CreateAsync(PratoCreateDto dto)
        {
            var prato = dto.ToPratoFromCreateDto();
            _context.Pratos.Add(prato);
            await _context.SaveChangesAsync();
            return prato.ToPratoReadDto();
        }

        public async Task<PratoReadDto?> UpdateAsync(int id, PratoUpdateDto dto)
        {
            var prato = await _context.Pratos.FirstOrDefaultAsync(p => p.PratoId == id);
            if (prato == null) return null;

            prato.Nome = dto.Nome;
            prato.Descricao =dto.Descricao;
            prato.Preco = dto.Preco;
            prato.Categoria = dto.Categoria;

            await _context.SaveChangesAsync();
            return prato.ToPratoReadDto();
        }

        public async Task<PratoReadDto?> PatchAsync(int id, PratoPatchDto dto)
        {
            var prato = await _context.Pratos.FindAsync(id);
            if (prato == null) return null;

            if (dto.Nome != null) prato.Nome = dto.Nome;
            if (dto.Descricao != null) prato.Descricao = dto.Descricao;
            if (dto.Preco.HasValue) prato.Preco = dto.Preco.Value;
            if (dto.Categoria.HasValue) prato.Categoria = dto.Categoria.Value;

            await _context.SaveChangesAsync();
            return prato.ToPratoReadDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prato = await _context.Pratos.FindAsync(id);
            if (prato == null) return false;

            _context.Pratos.Remove(prato);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}