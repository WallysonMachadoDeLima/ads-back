using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using CrudVeiculos.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{

    public class DisciplinaService
    {
        private readonly ApplicationDbContext _context;

        public DisciplinaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Disciplina>> GetAll()
        {
            return await _context.Disciplina.ToListAsync();
        }

        public async Task<Disciplina?> GetById(int id)
        {
            return await _context.Disciplina.FindAsync(id);
        }

        public async Task<Disciplina> Create(DisciplinaCreateDTO dto)
        {
            var disciplina = new Disciplina
            {
                Nome = dto.Nome,
                Codigo = dto.Codigo,
                Descricao = dto.Descricao,
                Objetivos = dto.Objetivos,
                Conteudo = dto.Conteudo
            };

            _context.Disciplina.Add(disciplina);
            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<Disciplina?> Update(int id, DisciplinaCreateDTO dto)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null) return null;

            disciplina.Nome = dto.Nome;
            disciplina.Codigo = dto.Codigo;
            disciplina.Descricao = dto.Descricao;
            disciplina.Objetivos = dto.Objetivos;
            disciplina.Conteudo = dto.Conteudo;

            await _context.SaveChangesAsync();
            return disciplina;
        }

        public async Task<bool> Delete(int id)
        {
            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null) return false;

            _context.Disciplina.Remove(disciplina);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}