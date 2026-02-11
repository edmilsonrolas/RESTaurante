using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Encomenda;
using api.Enums;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/encomendas")]
    public class EncomendasController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EncomendasController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/encomendas
        [HttpGet]
        public async Task<IActionResult> GetEncomendas()
        {
            var encomendaDtos = await _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Pratos)
                    .ThenInclude(pe => pe.Prato)
                .ToListAsync();

            return Ok(encomendaDtos.Select(e => e.ToEncomendaReadDto()));
        }

        // GET: api/encomendas/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var encomenda = await _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Pratos)
                    .ThenInclude(pe => pe.Prato)
                .FirstOrDefaultAsync(e => e.EncomendaId == id);

            if (encomenda == null) return NotFound();

            return Ok(encomenda.ToEncomendaReadDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEncomenda([FromBody] EncomendaCreateDto dto)
        {
            if (dto.Pratos == null || !dto.Pratos.Any())
                return BadRequest("A encomenda deve conter pelo menos um prato.");

            var encomendaModel = new Encomenda
            {
                ClienteId = dto.ClienteId,
                TrabalhadorId = dto.TrabalhadorId,
                Estado = EstadoEncomenda.Pendente,
                DataEncomenda = DateTime.Now,
                ValorTotal = 0
            };

            _context.Encomendas.Add(encomendaModel);
            await _context.SaveChangesAsync();

            decimal total = 0;

            foreach (var item in dto.Pratos)
            {
                var prato = await _context.Pratos.FindAsync(item.PratoId);
                if (prato == null) 
                    return BadRequest($"Prato com ID {item.PratoId} não existe.");

                var precoUnitario = prato.Preco;
                var subtotal = precoUnitario * item.Quantidade;

                _context.PratosEncomenda.Add(new PratoEncomenda
                {
                    EncomendaId = encomendaModel.EncomendaId,
                    PratoId = prato.PratoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = precoUnitario,
                    Subtotal = subtotal
                });

                total += subtotal;
            }

            encomendaModel.ValorTotal = total;
            await _context.SaveChangesAsync();

            var encomendaCompleta = await _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.Pratos)
                    .ThenInclude(pe => pe.Prato)
                .FirstAsync(e => e.EncomendaId == encomendaModel.EncomendaId);

            return CreatedAtAction(
                nameof(GetById),
                new {id = encomendaCompleta.EncomendaId},
                encomendaCompleta.ToEncomendaReadDto()
            );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEncomenda([FromRoute] int id, [FromBody] EncomendaUpdateDto updateDto)
        {
            var encomendaModel = await _context.Encomendas.FindAsync(id);
            if (encomendaModel == null) return NotFound();

            encomendaModel.Estado = updateDto.Estado;

            await _context.SaveChangesAsync();
            return Ok(encomendaModel);
        }
    }
}