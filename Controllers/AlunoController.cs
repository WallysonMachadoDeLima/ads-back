// AlunoController.cs
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
    [Route("api/aluno")]
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
            try
            {
                var aluno = await _alunoService.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
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
            try
            {
                var updated = await _alunoService.Update(id, dto);
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
            var result = await _alunoService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
