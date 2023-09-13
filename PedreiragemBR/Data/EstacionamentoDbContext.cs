using Microsoft.EntityFrameworkCore;
using PedreiragemBR.Models;

namespace PedreiragemBR.Data;

public class EstacionamentoDbContext : DbContext
{
    public DbSet<Carro> Carro {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite(connectionString: "DataSource=estacionamento.db;Cache=shared");
    }
}