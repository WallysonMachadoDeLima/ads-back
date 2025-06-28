using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("documento")]
    public class DocumentoController : ControllerBase
    {
        private readonly DocumentoService _documentoService;

        public DocumentoController(DocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpPost]
        public async Task<ActionResult<Documento>> Add([FromForm] DocumentoCreateDTO dto)
        {
            var documento = await _documentoService.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = documento.Id }, documento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetAll()
        {
            return Ok(await _documentoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetById(int id)
        {
            var documento = await _documentoService.GetById(id);
            if (documento == null) return NotFound();
            return Ok(documento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DocumentoUpdateDTO dto)
        {
            var updated = await _documentoService.Update(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _documentoService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
