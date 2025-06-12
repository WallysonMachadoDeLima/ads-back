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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CorpoDocente>()
                .HasOne(cd => cd.Servidor)
                .WithMany()
                .HasForeignKey(cd => cd.ServidorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}