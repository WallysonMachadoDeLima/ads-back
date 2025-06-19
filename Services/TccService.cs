using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class TccService
    {
        private readonly ApplicationDbContext _context;

        public TccService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tcc> Create(TccCreateDTO dto)
        {
            var tcc = new Tcc
            {
                AlunoId = dto.AlunoId,
                TituloProvisorio = dto.TituloProvisorio,
                Resumo = dto.Resumo,
                AreaTematica = dto.AreaTematica,
                OrientadorId = dto.OrientadorId,
                CoorientadorId = dto.CoorientadorId,
                ArquivoProposta = dto.ArquivoProposta,
                Periodo = dto.Periodo,
                DataPrevistaDefesa = dto.DataPrevistaDefesa,
                Observacoes = dto.Observacoes
            };

            _context.Tcc.Add(tcc);
            await _context.SaveChangesAsync();
            return tcc;
        }

        public async Task<List<Tcc>> GetAll()
        {
            return await _context.Tcc.ToListAsync();
        }

        public async Task<Tcc?> GetById(int id)
        {
            return await _context.Tcc.FindAsync(id);
        }

        public async Task<bool> Update(int id, TccCreateDTO dto)
        {
            var tcc = await _context.Tcc.FindAsync(id);
            if (tcc == null) return false;

            tcc.AlunoId = dto.AlunoId;
            tcc.TituloProvisorio = dto.TituloProvisorio;
            tcc.Resumo = dto.Resumo;
            tcc.AreaTematica = dto.AreaTematica;
            tcc.OrientadorId = dto.OrientadorId;
            tcc.CoorientadorId = dto.CoorientadorId;
            tcc.ArquivoProposta = dto.ArquivoProposta;
            tcc.Periodo = dto.Periodo;
            tcc.DataPrevistaDefesa = dto.DataPrevistaDefesa;
            tcc.Observacoes = dto.Observacoes;

            _context.Tcc.Update(tcc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var tcc = await _context.Tcc.FindAsync(id);
            if (tcc == null) return false;

            _context.Tcc.Remove(tcc);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
