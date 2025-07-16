// TccService.cs
using Ads.Data;
using Ads.DTOs;
using Ads.Entities;
using Ads.Services;       // para AlunoService e ServidorService
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ads.Services
{
    public class TccService
    {
        private readonly ApplicationDbContext _context;
        private readonly AlunoService _alunoService;
        private readonly ServidorService _servidorService;

        public TccService(
            ApplicationDbContext context,
            AlunoService alunoService,
            ServidorService servidorService
        )
        {
            _context = context;
            _alunoService = alunoService;
            _servidorService = servidorService;
        }

        public async Task<Tcc> Create(TccCreateDTO dto)
        {
            // valida existência de aluno
            if (await _alunoService.GetById(dto.AlunoId) == null)
                throw new InvalidOperationException($"Aluno {dto.AlunoId} não encontrado.");

            // valida existência de orientador
            if (await _servidorService.GetById(dto.OrientadorId) == null)
                throw new InvalidOperationException($"Orientador {dto.OrientadorId} não encontrado.");

            // valida existência de coorientador (se informado)
            if (dto.CoorientadorId.HasValue
                && await _servidorService.GetById(dto.CoorientadorId.Value) == null)
            {
                throw new InvalidOperationException($"Coorientador {dto.CoorientadorId} não encontrado.");
            }

            var tcc = new Tcc
            {
                AlunoId = dto.AlunoId,
                OrientadorId = dto.OrientadorId,
                CoorientadorId = dto.CoorientadorId,
                TituloProvisorio = dto.TituloProvisorio,
                Resumo = dto.Resumo,
                AreaTematica = dto.AreaTematica,
                ArquivoProposta = dto.ArquivoProposta,
                Periodo = dto.Periodo,
                DataPrevistaDefesa = DateTime.SpecifyKind(dto.DataPrevistaDefesa, DateTimeKind.Utc),
                Status = dto.Status,
                DataSubmissao = DateTime.UtcNow,
                DataAprovacao = null!
            };

            _context.Tcc.Add(tcc);
            await _context.SaveChangesAsync();
            return tcc;
        }

        public async Task<List<Tcc>> GetAll()
            => await _context.Tcc.ToListAsync();

        public async Task<Tcc?> GetById(int id)
            => await _context.Tcc.FindAsync(id);

        public async Task<bool> Update(int id, TccCreateDTO dto)
        {
            var tcc = await _context.Tcc.FindAsync(id);
            if (tcc == null)
                return false;

            // valida existência de aluno
            if (await _alunoService.GetById(dto.AlunoId) == null)
                throw new InvalidOperationException($"Aluno {dto.AlunoId} não encontrado.");

            // valida existência de orientador
            if (await _servidorService.GetById(dto.OrientadorId) == null)
                throw new InvalidOperationException($"Orientador {dto.OrientadorId} não encontrado.");

            // valida existência de coorientador (se informado)
            if (dto.CoorientadorId.HasValue
                && await _servidorService.GetById(dto.CoorientadorId.Value) == null)
            {
                throw new InvalidOperationException($"Coorientador {dto.CoorientadorId} não encontrado.");
            }

            // aplica atualizações
            tcc.AlunoId = dto.AlunoId;
            tcc.OrientadorId = dto.OrientadorId;
            tcc.CoorientadorId = dto.CoorientadorId;
            tcc.TituloProvisorio = dto.TituloProvisorio;
            tcc.Resumo = dto.Resumo;
            tcc.AreaTematica = dto.AreaTematica;
            tcc.ArquivoProposta = dto.ArquivoProposta;
            tcc.Periodo = dto.Periodo;
            tcc.DataPrevistaDefesa = DateTime.SpecifyKind(dto.DataPrevistaDefesa, DateTimeKind.Utc);

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
