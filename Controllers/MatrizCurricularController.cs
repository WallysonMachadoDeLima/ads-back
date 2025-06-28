using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("matrizcurricular")]
    public class MatrizCurricularController : ControllerBase
    {
        private readonly MatrizCurricularService _service;

        public MatrizCurricularController(MatrizCurricularService service)
            => _service = service;

        [HttpPost]
        public async Task<ActionResult<MatrizCurricular>> Create([FromBody] MatrizCurricularCreateDTO dto)
        {
            var matriz = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = matriz.Id }, matriz);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatrizCurricular>>> GetAll()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<MatrizCurricular>> GetById(int id)
        {
            var matriz = await _service.GetById(id);
            if (matriz == null) return NotFound();
            return Ok(matriz);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MatrizCurricularUpdateDTO dto)
        {
            var updated = await _service.Update(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _service.Delete(id);
            if (!removed) return NotFound();
            return NoContent();
        }

    }
}
