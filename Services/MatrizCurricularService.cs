using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudVeiculos.Services
{
    public class MatrizCurricularService
    {
        private readonly ApplicationDbContext _context;

        public MatrizCurricularService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MatrizCurricular>> GetAll()
        {
            return await _context.MatrizCurricular
                                 .Include(m => m.Disciplinas)
                                 .ToListAsync();
        }

        public async Task<MatrizCurricular?> GetById(int id)
        {
            return await _context.MatrizCurricular
                                 .Include(m => m.Disciplinas)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MatrizCurricular> Create(MatrizCurricularCreateDTO dto)
        {
            var disciplinas = await _context.Disciplina
                .Where(d => dto.DisciplinaIds.Contains(d.Id))
                .ToListAsync();

            var matriz = new MatrizCurricular
            {
                Nome = dto.Nome,
                Ano = dto.Ano,
                Disciplinas = disciplinas
            };

            _context.MatrizCurricular.Add(matriz);
            await _context.SaveChangesAsync();
            return matriz;
        }

        public async Task<MatrizCurricular?> Update(int id, MatrizCurricularUpdateDTO dto)
        {
            var matriz = await _context.MatrizCurricular
                                       .Include(m => m.Disciplinas)
                                       .FirstOrDefaultAsync(m => m.Id == id);
            if (matriz == null) return null;

            matriz.Nome = dto.Nome;
            matriz.Ano = dto.Ano;

            // atualiza relação: limpa e atribui novamente
            var disciplinas = await _context.Disciplina
                .Where(d => dto.DisciplinaIds.Contains(d.Id))
                .ToListAsync();
            matriz.Disciplinas.Clear();
            foreach (var d in disciplinas) matriz.Disciplinas.Add(d);

            await _context.SaveChangesAsync();
            return matriz;
        }

        public async Task<bool> Delete(int id)
        {
            var matriz = await _context.MatrizCurricular.FindAsync(id);
            if (matriz == null) return false;

            _context.MatrizCurricular.Remove(matriz);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
