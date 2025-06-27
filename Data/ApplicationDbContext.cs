using Microsoft.EntityFrameworkCore;
using CrudVeiculos.Entities;

namespace CrudVeiculos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Servidor> Servidor { get; set; }
        public DbSet<CorpoDocente> CorpoDocente { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Tcc> Tcc { get; set; }
        public DbSet<Documento> Documentos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorpoDocente>()
                .HasOne(cd => cd.Servidor)
                .WithOne()
                .HasForeignKey<CorpoDocente>(cd => cd.ServidorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CorpoDocente>()
                .HasOne(cd => cd.Disciplina)
                .WithMany()
                .HasForeignKey(cd => cd.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tcc>()
                .HasOne(t => t.Aluno)
                .WithMany()
                .HasForeignKey(t => t.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tcc>()
                .HasOne(t => t.Orientador)
                .WithMany()
                .HasForeignKey(t => t.OrientadorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tcc>()
                .HasOne(t => t.Coorientador)
                .WithMany()
                .HasForeignKey(t => t.CoorientadorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}