using Ads.DTOs;
using Ads.Entities;
using Ads.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ads.Controllers
{
    [ApiController]
    [Route("api/corpo-docente")]
    public class CorpoDocenteController : ControllerBase
    {
        private readonly CorpoDocenteService _corpoDocenteService;

        public CorpoDocenteController(CorpoDocenteService corpoDocenteService)
        {
            _corpoDocenteService = corpoDocenteService;
        }

        // 📌 aqui
        [HttpPost]
        public async Task<IActionResult> Add(CorpoDocenteCreateDTO dto)
        {
            try
            {
                var created = await _corpoDocenteService.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CorpoDocente>>> GetAll()
        {
            return Ok(await _corpoDocenteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CorpoDocente>> GetById(int id)
        {
            var corpo = await _corpoDocenteService.GetById(id);
            if (corpo == null) return NotFound();
            return Ok(corpo);
        }

        // 📌 e aqui
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CorpoDocenteUpdateDTO dto)
        {
            try
            {
                var ok = await _corpoDocenteService.Update(id, dto);
                if (!ok) return NotFound();
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _corpoDocenteService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }

}
