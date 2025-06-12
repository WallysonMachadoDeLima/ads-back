using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudVeiculos.Controllers
{

    [ApiController]
    [Route("disciplina")]
    public class DisciplinaController : ControllerBase
    {
        private readonly DisciplinaService _disciplinaService;

        public DisciplinaController(DisciplinaService disciplinaService)
        {
            _disciplinaService = disciplinaService;
        }

        [HttpPost]
        public async Task<ActionResult<Disciplina>> Add([FromBody] DisciplinaCreateDTO dto)
        {
            var disciplina = await _disciplinaService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = disciplina.Id }, disciplina);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> GetAll()
        {
            return Ok(await _disciplinaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> GetById(int id)
        {
            var disciplina = await _disciplinaService.GetById(id);
            if (disciplina == null) return NotFound();

            return Ok(disciplina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DisciplinaCreateDTO dto)
        {
            var updated = await _disciplinaService.Update(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _disciplinaService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}