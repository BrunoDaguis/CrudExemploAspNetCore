
using Microsoft.EntityFrameworkCore;
using SistemaLembrete.Domain.Entities;

namespace SistemaLembrete.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<LembreteEntity> Lembrete { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>().ToTable("Usuario");
            modelBuilder.Entity<LembreteEntity>().ToTable("Lembrete");
        }

    }
}
