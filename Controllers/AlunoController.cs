using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Add([FromBody] AlunoCreateDTO dto)
        {
            var aluno = await _alunoService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAll()
        {
            return Ok(await _alunoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetById(int id)
        {
            var aluno = await _alunoService.GetById(id);
            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlunoUpdateDTO dto)
        {
            var updated = await _alunoService.Update(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _alunoService.Delete(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
