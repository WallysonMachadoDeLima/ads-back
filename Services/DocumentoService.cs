using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CrudVeiculos.Data;
using CrudVeiculos.DTOs;
using CrudVeiculos.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudVeiculos.Services
{
    public class DocumentoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _storage;

        public DocumentoService(ApplicationDbContext context, IFileStorageService storage)
        {
            _context = context;
            _storage = storage;
        }

        public async Task<Documento> Create(DocumentoCreateDTO dto, CancellationToken ct = default)
        {
            var url = await _storage.UploadFileAsync(dto.File, ct);
            var doc = new Documento
            {
                Nome = dto.Nome,
                Apelido = dto.Apelido,
                Url = url,
                CreatedAt = DateTime.UtcNow
            };

            _context.Documentos.Add(doc);
            await _context.SaveChangesAsync(ct);
            return doc;
        }

        public async Task<List<Documento>> GetAll(CancellationToken ct = default)
        {
            return await _context.Documentos.ToListAsync(ct);
        }

        public async Task<Documento?> GetById(int id, CancellationToken ct = default)
        {
            return await _context.Documentos.FindAsync(new object[] { id }, ct);
        }

        public async Task<bool> Update(int id, DocumentoUpdateDTO dto, CancellationToken ct = default)
        {
            var existing = await _context.Documentos.FindAsync(new object[] { id }, ct);
            if (existing == null) return false;

            var url = await _storage.UploadFileAsync(dto.File, ct);
            existing.Nome = dto.Nome;
            existing.Apelido = dto.Apelido;
            existing.Url = url;
            existing.CreatedAt = DateTime.UtcNow;

            _context.Documentos.Update(existing);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> Delete(int id, CancellationToken ct = default)
        {
            var existing = await _context.Documentos.FindAsync(new object[] { id }, ct);
            if (existing == null) return false;

            _context.Documentos.Remove(existing);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
