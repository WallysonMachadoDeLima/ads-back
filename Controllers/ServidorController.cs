using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("servidor")]
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
            var servidor = await _servidorService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = servidor.Id }, servidor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servidor>>> GetAll()
        {
            return Ok(await _servidorService.GetAll());
        }

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
            var updated = await _servidorService.Update(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
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
