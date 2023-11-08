using MidnightCityTheater.Models;
using Microsoft.EntityFrameworkCore;

namespace MidnightCityTheater.Data;
public class APIDbContext : DbContext
{
    public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Ingresso> Ingresso { get; set; }
        public DbSet<Snack> Snack { get; set; }
        public DbSet<Pipoca> Pipoca { get; set; }
        public DbSet<Bebida> Bebida { get; set; }
        public DbSet<Doce> Doce { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=DatabaseCinema.db;Cache=Shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define uma chave única para a propriedade CPF
        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.CPF)
            .IsUnique();

    }
}