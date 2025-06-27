using System.Collections.Generic;
using System.Threading.Tasks;
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
            var list = await _documentoService.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetById(int id)
        {
            var documento = await _documentoService.GetById(id);
            if (documento == null) return NotFound();
            return Ok(documento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Documento>> Update(int id, [FromForm] DocumentoUpdateDTO dto)
        {
            var updated = await _documentoService.Update(id, dto);
            if (!updated) return NotFound();

            var documento = await _documentoService.GetById(id);
            return Ok(documento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _documentoService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
