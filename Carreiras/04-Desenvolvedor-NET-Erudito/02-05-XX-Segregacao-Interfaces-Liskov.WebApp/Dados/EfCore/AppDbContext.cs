using Microsoft.EntityFrameworkCore;
using _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Models;

namespace _02_05_XX_Segregacao_Interfaces_Liskov.WebApp.Dados.EfCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Leilao> Leiloes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AluraLeiloesDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leilao>()
                .HasOne(l => l.Categoria)
                .WithMany(c => c.Leiloes)
                .HasForeignKey(l => l.IdCategoria);
        }
    }
}