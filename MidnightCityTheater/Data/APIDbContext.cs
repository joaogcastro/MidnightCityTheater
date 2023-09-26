using MidnightCityTheater.Models;
using Microsoft.EntityFrameworkCore;

namespace MidnightCityTheater.Data;
public class APIDbContext : DbContext
{
    public DbSet<Cliente>? Cliente { get; set;}

    public DbSet<Filme>? Filme { get; set; }

    public DbSet<Sala>? Sala { get; set; }

    public DbSet<Ingresso>? Ingresso { get; set;}

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