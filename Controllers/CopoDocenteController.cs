using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("corpo-doscente")]
    public class CorpoDocenteController : ControllerBase
    {
        private readonly CorpoDocenteService _corpoDoscenteService;

        public CorpoDocenteController(CorpoDocenteService corpoDoscenteService)
        {
            _corpoDoscenteService = corpoDoscenteService;
        }

        [HttpPost]
        public async Task<ActionResult<CorpoDocente>> Add([FromBody] CorpoDocenteCreateDTO dto)
        {
            var corpo = await _corpoDoscenteService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = corpo.Id }, corpo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorpoDocente>>> GetAll()
        {
            return Ok(await _corpoDoscenteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CorpoDocente>> GetById(int id)
        {
            var corpo = await _corpoDoscenteService.GetById(id);
            if (corpo == null) return NotFound();

            return Ok(corpo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CorpoDocenteUpdateDTO dto)
        {
            var result = await _corpoDoscenteService.Update(id, dto);
            if (!result) return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _corpoDoscenteService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
