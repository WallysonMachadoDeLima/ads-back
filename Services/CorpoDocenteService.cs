using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class CorpoDocenteService
    {
        private readonly ApplicationDbContext _context;

        public CorpoDocenteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CorpoDocente>> GetAll()
        {
            return await _context.CorpoDocente.ToListAsync();
        }

        public async Task<CorpoDocente?> GetById(int id)
        {
            return await _context.CorpoDocente.FindAsync(id);
        }

        public async Task<CorpoDocente> Create(CorpoDocenteCreateDTO dto)
        {
            var corpo = new CorpoDocente
            {
                ServidorId = dto.ServidorId,
                Disciplina = dto.Disciplina
            };

            _context.CorpoDocente.Add(corpo);
            await _context.SaveChangesAsync();
            return corpo;
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
