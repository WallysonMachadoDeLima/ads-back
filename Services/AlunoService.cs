// AlunoService.cs
using Ads.Data;
using Ads.DTOs;
using Ads.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ads.Services
{
    public class AlunoService
    {
        private readonly ApplicationDbContext _context;

        public AlunoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAll()
        {
            return await _context.Aluno.ToListAsync();
        }

        public async Task<Aluno?> GetById(int id)
        {
            return await _context.Aluno.FindAsync(id);
        }

        public async Task<Aluno> Create(AlunoCreateDTO dto)
        {
            if (!IsCpfValid(dto.Cpf))
                throw new InvalidOperationException("CPF inválido.");

            var aluno = new Aluno
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Matricula = dto.Matricula
            };

            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno?> Update(int id, AlunoUpdateDTO dto)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
                return null;

            if (!IsCpfValid(dto.Cpf))
                throw new InvalidOperationException("CPF inválido.");

            aluno.Nome = dto.Nome;
            aluno.Cpf = dto.Cpf;
            aluno.Email = dto.Email;
            aluno.Telefone = dto.Telefone;
            aluno.Matricula = dto.Matricula;

            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<bool> Delete(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null) return false;

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool IsCpfValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            var cleaned = Regex.Replace(cpf, "[^0-9]", "");
            if (cleaned.Length != 11 || cleaned.Distinct().Count() == 1)
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cleaned.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            digito = resto < 2 ? 0 : 11 - resto;

            return cleaned.EndsWith(digito.ToString());
        }
    }
}
