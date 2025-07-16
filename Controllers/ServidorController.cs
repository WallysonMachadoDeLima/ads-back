// ServidorController.cs
using Ads.DTOs;
using Ads.Entities;
using Ads.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.Controllers
{
    [ApiController]
    [Route("api/servidor")]
    public class ServidorController : ControllerBase
    {
        private readonly ServidorService _servidorService;

        public ServidorController(ServidorService servidorService)
        {
            _servidorService = servidorService;
        }

        [HttpPost]
        public async Task<ActionResult<Servidor>> Add([FromBody] ServidorCreateDTO dto)
        {
            try
            {
                var servidor = await _servidorService.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = servidor.Id }, servidor);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servidor>>> GetAll()
            => Ok(await _servidorService.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<Servidor>> GetById(int id)
        {
            var servidor = await _servidorService.GetById(id);
            if (servidor == null) return NotFound();
            return Ok(servidor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ServidorUpdateDTO dto)
        {
            try
            {
                var updated = await _servidorService.Update(id, dto);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _servidorService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
