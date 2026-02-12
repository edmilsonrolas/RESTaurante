using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Pedido;
using api.Enums;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PedidosController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            var pedidos = await _context.Pedidos
                .Include(pd => pd.Cliente)
                .Include(pd => pd.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .ToListAsync();

            return Ok(pedidos.Select(pd => pd.ToPedidoReadDto()));
        }

        // GET: api/pedidos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _context.Pedidos
                .Include(pd => pd.Cliente)
                .Include(pd => pd.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .FirstOrDefaultAsync(pd => pd.PedidoId == id);

            if (pedido == null) return NotFound();

            return Ok(pedido.ToPedidoReadDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePedido([FromBody] PedidoCreateDto dto)
        {
            if (dto.Pratos == null || !dto.Pratos.Any())
                return BadRequest("O Pedido deve conter pelo menos um prato.");

            var pedidoModel = new Pedido
            {
                ClienteId = dto.ClienteId,
                TrabalhadorId = dto.TrabalhadorId,
                Estado = EstadoPedido.Pendente,
                DataPedido = DateTime.Now,
                ValorTotal = 0
            };

            _context.Pedidos.Add(pedidoModel);
            await _context.SaveChangesAsync();

            decimal total = 0;

            foreach (var item in dto.Pratos)
            {
                var prato = await _context.Pratos.FindAsync(item.PratoId);
                if (prato == null) 
                    return BadRequest($"Prato com ID {item.PratoId} não existe.");

                var precoUnitario = prato.Preco;
                var subtotal = precoUnitario * item.Quantidade;

                _context.PratosPedido.Add(new PratoPedido
                {
                    PedidoId = pedidoModel.PedidoId,
                    PratoId = prato.PratoId,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = precoUnitario,
                    Subtotal = subtotal
                });

                total += subtotal;
            }

            pedidoModel.ValorTotal = total;
            await _context.SaveChangesAsync();

            var pedidoCompleto = await _context.Pedidos
                .Include(pd => pd.Cliente)
                .Include(pd => pd.Pratos)
                    .ThenInclude(pp => pp.Prato)
                .FirstAsync(pd => pd.PedidoId == pedidoModel.PedidoId);

            return CreatedAtAction(
                nameof(GetById),
                new {id = pedidoCompleto.PedidoId},
                pedidoCompleto.ToPedidoReadDto()
            );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePedido([FromRoute] int id, [FromBody] PedidoUpdateDto updateDto)
        {
            var PedidoModel = await _context.Pedidos.FindAsync(id);
            if (PedidoModel == null) return NotFound();

            PedidoModel.Estado = updateDto.Estado;

            await _context.SaveChangesAsync();
            return Ok(PedidoModel);
        }
    }
}