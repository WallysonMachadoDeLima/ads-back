// ServidorService.cs
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
    public class ServidorService
    {
        private readonly ApplicationDbContext _context;

        public ServidorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servidor>> GetAll()
            => await _context.Servidor.ToListAsync();

        public async Task<Servidor?> GetById(int id)
            => await _context.Servidor.FindAsync(id);

        public async Task<Servidor> Create(ServidorCreateDTO dto)
        {
            if (!IsCpfValid(dto.Cpf))
                throw new InvalidOperationException("CPF inválido.");

            var servidor = new Servidor
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Email = dto.Email,
                Senha = dto.Senha,
                Tipo = dto.Tipo,
                DataNascimento = DateTime.SpecifyKind(dto.DataNascimento, DateTimeKind.Utc),
                Sexo = dto.Sexo,
                Situacao = dto.Situacao
            };

            _context.Servidor.Add(servidor);
            await _context.SaveChangesAsync();
            return servidor;
        }

        public async Task<Servidor?> Update(int id, ServidorUpdateDTO dto)
        {
            var servidor = await _context.Servidor.FindAsync(id);
            if (servidor == null)
                return null;

            if (!IsCpfValid(dto.Cpf))
                throw new InvalidOperationException("CPF inválido.");

            servidor.Nome = dto.Nome;
            servidor.Cpf = dto.Cpf;
            servidor.Email = dto.Email;
            servidor.Senha = dto.Senha;
            servidor.Tipo = dto.Tipo;
            servidor.DataNascimento = DateTime.SpecifyKind(dto.DataNascimento, DateTimeKind.Utc);
            servidor.Sexo = dto.Sexo;
            servidor.Situacao = dto.Situacao;


            await _context.SaveChangesAsync();
            return servidor;
        }

        public async Task<bool> Delete(int id)
        {
            var servidor = await _context.Servidor.FindAsync(id);
            if (servidor == null) return false;

            _context.Servidor.Remove(servidor);
            await _context.SaveChangesAsync();
            return true;
        }

        // Validação de CPF
        private bool IsCpfValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            var cleaned = Regex.Replace(cpf, "[^0-9]", "");
            if (cleaned.Length != 11 || cleaned.Distinct().Count() == 1)
                return false;

            int[] m1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] m2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp = cleaned.Substring(0, 9);
            int sum = 0;
            for (int i = 0; i < 9; i++) sum += int.Parse(temp[i].ToString()) * m1[i];

            int r = sum % 11;
            int d = r < 2 ? 0 : 11 - r;
            temp += d;

            sum = 0;
            for (int i = 0; i < 10; i++) sum += int.Parse(temp[i].ToString()) * m2[i];
            r = sum % 11;
            d = r < 2 ? 0 : 11 - r;

            return cleaned.EndsWith(d.ToString());
        }
    }
}
