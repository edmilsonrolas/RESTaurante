using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Pedido;
using api.Enums;
using api.Mappers;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _service;

        public PedidosController(IPedidoService service)
        {
            _service = service;
        }

        // GET: api/pedidos
        [HttpGet, Authorize]
        public async Task<IActionResult> GetPedidos()
            => Ok(await _service.GetAllAsync());

        // GET: api/pedidos/{id}
        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _service.GetByIdAsync(id);
            return pedido == null ? NotFound() : Ok(pedido);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Create(PedidoCreateDto dto)
        {
            var pedido = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = pedido.PedidoId}, pedido);
        }

        // [HttpPut]
        // [Route("{id}")]
        // public async Task<IActionResult> UpdatePedido([FromRoute] int id, [FromBody] PedidoUpdateDto updateDto)
        // {
        //     var PedidoModel = await _context.Pedidos.FindAsync(id);
        //     if (PedidoModel == null) return NotFound();

        //     PedidoModel.Estado = updateDto.Estado;

        //     await _context.SaveChangesAsync();
        //     return Ok(PedidoModel);
        // }
    }
}