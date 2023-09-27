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
        /*    
        //Define a relação de um para muitos entre Snack e Pipoca
        modelBuilder.Entity<Snack>()
            .HasMany(s => s.Pipoca)
            .WithOne(p => p.Snack)
            .HasForeignKey(p => p.SnackId);

        //Define a relação de um para muitos entre Snack e Bebida
        modelBuilder.Entity<Snack>()
            .HasMany(s => s.Bebida)
            .WithOne(b => b.Snack)
            .HasForeignKey(b => b.SnackId);

        //Define a relação de um para muitos entre Snack e Doce
        modelBuilder.Entity<Snack>()
            .HasMany(s => s.Doce)
            .WithOne(d => d.Snack)
            .HasForeignKey(d => d.SnackId);

        // Configurar relação um-para-um entre Venda e Cliente
        modelBuilder.Entity<Venda>()
            .HasOne(v => v.Cliente)
            .WithOne(c => c.Venda)
            .HasForeignKey<Cliente>(c => c.VendaId);

        // Configurar relação um-para-um entre Venda e Ingresso
        modelBuilder.Entity<Venda>()
            .HasOne(v => v.Ingresso)
            .WithOne(i => i.Venda)
            .HasForeignKey<Ingresso>(i => i.VendaId);

        // Configurar relação um-para-um entre Venda e Snack
        modelBuilder.Entity<Venda>()
            .HasOne(v => v.Snack)
            .WithOne(s => s.Venda)
            .HasForeignKey<Snack>(s => s.VendaId);
        */
    }
}