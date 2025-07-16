// TccController.cs
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
    [Route("api/tcc")]
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
            try
            {
                var tcc = await _tccService.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = tcc.Id }, tcc);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tcc>>> GetAll()
            => Ok(await _tccService.GetAll());

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
            try
            {
                var updated = await _tccService.Update(id, dto);
                if (!updated) return NotFound();
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
            var result = await _tccService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
