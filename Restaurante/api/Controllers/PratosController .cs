using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Prato;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/pratos")]
    public class PratosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PratosController (ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/pratos
        [HttpGet]
        public async Task<IActionResult> GetPratos()
        {
            var pratoDtos = await _context.Pratos
            .Select(prato => prato.ToPratoReadDto())
            .ToListAsync();

            return Ok(pratoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var prato = await _context.Pratos.FindAsync(id);
            
            if (prato == null) return NotFound();

            return Ok(prato.ToPratoReadDto());
        }

        // POST: api/pratos
        [HttpPost]
        public async Task<IActionResult> CreatePrato(PratoCreateDto pratoCreateDto)
        {
            var pratoModel = pratoCreateDto.ToPratoFromCreateDto();
            await _context.Pratos.AddAsync(pratoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = pratoModel.PratoId}, pratoModel.ToPratoReadDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePrato([FromRoute] int id, [FromBody] PratoUpdateDto pratoUpdateDto)
        {
            var pratoModel = await _context.Pratos.FirstOrDefaultAsync(p => p.PratoId == id);

            if (pratoModel == null) return NotFound();

            pratoModel.Nome = pratoUpdateDto.Nome;
            pratoModel.Descricao = pratoUpdateDto.Descricao;
            pratoModel.Preco = pratoUpdateDto.Preco;
            pratoModel.Categoria = pratoUpdateDto.Categoria;

            await _context.SaveChangesAsync();
            return Ok(pratoModel.ToPratoReadDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePrato([FromRoute] int id)
        {
            var pratoModel = await _context.Pratos.FirstOrDefaultAsync(p => p.PratoId == id);

            if (pratoModel == null) return NotFound();

            _context.Pratos.Remove(pratoModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}