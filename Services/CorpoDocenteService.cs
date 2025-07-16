using Ads.Data;
using Ads.DTOs;
using Ads.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ads.Services
{
    public class CorpoDocenteService
    {
        private readonly ApplicationDbContext _context;
        private readonly ServidorService _servidorService;
        private readonly DisciplinaService _disciplinaService;

        public CorpoDocenteService(
            ApplicationDbContext context,
            ServidorService servidorService,
            DisciplinaService disciplinaService
        )
        {
            _context = context;
            _servidorService = servidorService;
            _disciplinaService = disciplinaService;
        }

        public async Task<CorpoDocente> Create(CorpoDocenteCreateDTO dto)
        {
            // valida existência de servidor
            if (await _servidorService.GetById(dto.ServidorId) == null)
                throw new InvalidOperationException("Servidor não encontrado.");

            // valida existência de disciplina
            if (await _disciplinaService.GetById(dto.DisciplinaId) == null)
                throw new InvalidOperationException("Disciplina não encontrada.");

            // checa duplicado
            var exists = await _context.CorpoDocente
                .AnyAsync(c =>
                    c.ServidorId == dto.ServidorId &&
                    c.DisciplinaId == dto.DisciplinaId
                );

            if (exists)
                throw new InvalidOperationException("Este servidor já está vinculado a essa disciplina.");

            var corpo = new CorpoDocente
            {
                ServidorId = dto.ServidorId,
                DisciplinaId = dto.DisciplinaId
            };

            _context.CorpoDocente.Add(corpo);
            await _context.SaveChangesAsync();
            return corpo;
        }

        public async Task<List<CorpoDocente>> GetAll()
            => await _context.CorpoDocente.ToListAsync();

        public async Task<CorpoDocente?> GetById(int id)
            => await _context.CorpoDocente.FindAsync(id);

        public async Task<bool> Update(int id, CorpoDocenteUpdateDTO dto)
        {
            var corpo = await _context.CorpoDocente.FindAsync(id);
            if (corpo == null) return false;

            // valida existência de servidor
            if (await _servidorService.GetById(dto.ServidorId) == null)
                throw new InvalidOperationException("Servidor não encontrado.");

            // valida existência de disciplina
            if (await _disciplinaService.GetById(dto.DisciplinaId) == null)
                throw new InvalidOperationException("Disciplina não encontrada.");

            // checa duplicado em outro registro
            var conflict = await _context.CorpoDocente
                .AnyAsync(c =>
                    c.ServidorId == dto.ServidorId &&
                    c.DisciplinaId == dto.DisciplinaId &&
                    c.Id != id
                );

            if (conflict)
                throw new InvalidOperationException("Já existe outro vínculo com esse servidor e disciplina.");

            corpo.ServidorId = dto.ServidorId;
            corpo.DisciplinaId = dto.DisciplinaId;

            _context.CorpoDocente.Update(corpo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var corpo = await _context.CorpoDocente.FindAsync(id);
            if (corpo == null) return false;

            _context.CorpoDocente.Remove(corpo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
