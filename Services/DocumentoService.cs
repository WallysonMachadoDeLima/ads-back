using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class DocumentoService
    {
        private readonly ApplicationDbContext _context;

        public DocumentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Documento>> GetAll()
        {
            return await _context.Documento.ToListAsync();
        }

        public async Task<Documento?> GetById(int id)
        {
            return await _context.Documento.FindAsync(id);
        }

        public async Task<Documento> Create(DocumentoCreateDTO dto)
        {
            // por enquanto só atribuímos uma URL fixa
            var documento = new Documento
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Url = "https://www.google.com/imgres?q=ifro&imgurl=https%3A%2F%2Flookaside.fbsbx.com%2Flookaside%2Fcrawler%2Finstagram%2Fifro_oficial%2Fprofile_pic.jpg&imgrefurl=https%3A%2F%2Fwww.instagram.com%2Fifro_oficial%2F&docid=zB150hdfMIGTEM&tbnid=fMk99Kbjaw2N0M&vet=12ahUKEwiblf281ZSOAxU2hJUCHbnbIGcQM3oECHkQAA..i&w=640&h=640&hcb=2&ved=2ahUKEwiblf281ZSOAxU2hJUCHbnbIGcQM3oECHkQAA"
            };

            _context.Documento.Add(documento);
            await _context.SaveChangesAsync();
            return documento;
        }

        public async Task<Documento?> Update(int id, DocumentoUpdateDTO dto)
        {
            var documento = await _context.Documento.FindAsync(id);
            if (documento == null) return null;

            documento.Nome = dto.Nome;
            documento.Descricao = dto.Descricao;
            documento.Url = dto.Url;

            await _context.SaveChangesAsync();
            return documento;
        }

        public async Task<bool> Delete(int id)
        {
            var documento = await _context.Documento.FindAsync(id);
            if (documento == null) return false;

            _context.Documento.Remove(documento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
