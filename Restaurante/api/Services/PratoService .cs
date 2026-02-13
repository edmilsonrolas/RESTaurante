using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Prato;
using api.Mappers;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class PratoService : IPratoService
    {
        private readonly IPratoRepository _repository;

        public PratoService (IPratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PratoReadDto>> GetAllAsync()
            => (await _repository.GetAllAsync())
                .Select(p => p.ToPratoReadDto());

        public async Task<PratoReadDto?> GetByIdAsync(int id)
        {
            var prato = await _repository.GetByIdAsync(id);
            return prato?.ToPratoReadDto();
        }

        public async Task<PratoReadDto> CreateAsync(PratoCreateDto dto)
        {
            var prato = dto.ToPratoFromCreateDto();
            await _repository.AddAsync(prato);
            return prato.ToPratoReadDto();
        }

        public async Task<PratoReadDto?> UpdateAsync(int id, PratoUpdateDto dto)
        {
            var prato = await _repository.GetByIdAsync(id);
            if (prato == null) return null;

            prato.Nome = dto.Nome;
            prato.Descricao =dto.Descricao;
            prato.Preco = dto.Preco;
            prato.Categoria = dto.Categoria;

            await _repository.UpdateAsync();
            return prato.ToPratoReadDto();
        }

        public async Task<PratoReadDto?> PatchAsync(int id, PratoPatchDto dto)
        {
            var prato = await _repository.GetByIdAsync(id);
            if (prato == null) return null;

            if (dto.Nome != null) prato.Nome = dto.Nome;
            if (dto.Descricao != null) prato.Descricao = dto.Descricao;
            if (dto.Preco.HasValue) prato.Preco = dto.Preco.Value;
            if (dto.Categoria.HasValue) prato.Categoria = dto.Categoria.Value;

            await _repository.UpdateAsync();
            return prato.ToPratoReadDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prato = await _repository.GetByIdAsync(id);
            if (prato == null) return false;

            await _repository.DeleteAsync(prato);

            return true;
        }
    }
}