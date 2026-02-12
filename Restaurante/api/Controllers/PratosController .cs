using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Prato;
using api.Mappers;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/pratos")]
    public class PratosController : ControllerBase
    {
        private readonly IPratoService _service;
        public PratosController (IPratoService service)
        {
            _service = service;
        }

        // GET: api/pratos
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());    // o mesmo q return Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var prato = await _service.GetByIdAsync(id);
            return prato == null ? NotFound() : Ok(prato);
        }

        // POST: api/pratos
        [HttpPost]
        public async Task<IActionResult> CreatePrato(PratoCreateDto pratoCreateDto)
        {
            var prato = await _service.CreateAsync(pratoCreateDto);
            return CreatedAtAction(nameof(GetById), new {id = prato.Id}, prato);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePrato([FromRoute] int id, [FromBody] PratoUpdateDto pratoUpdateDto)
        {
            var prato = await _service.UpdateAsync(id, pratoUpdateDto);
            return prato == null ? NotFound() : Ok(prato);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePrato([FromRoute] int id)
            => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}