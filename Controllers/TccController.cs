using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("tcc")]
    public class TccController : ControllerBase
    {
        private readonly TccService _tccService;

        public TccController(TccService tccService)
        {
            _tccService = tccService;
        }

        [HttpPost]
        public async Task<ActionResult<Tcc>> Add([FromBody] TccCreateDTO dto)
        {
            var tcc = await _tccService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = tcc.Id }, tcc);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcc>>> GetAll()
        {
            return Ok(await _tccService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tcc>> GetById(int id)
        {
            var tcc = await _tccService.GetById(id);
            if (tcc == null) return NotFound();

            return Ok(tcc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TccCreateDTO dto)
        {
            var result = await _tccService.Update(id, dto);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tccService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
