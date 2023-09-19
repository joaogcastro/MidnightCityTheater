using WebApiFindWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Estacionamento.Data;
public class EstacionamentoDbContext : DbContext
{
    public DbSet<Profissional>? Profissional { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=Profissionais.db;Cache=Shared");
    }

}