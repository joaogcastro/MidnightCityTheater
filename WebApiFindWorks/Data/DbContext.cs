using WebApiFindWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiFindWorks.Data;
public class WebApiFindWorksDbContext : DbContext
{
    public DbSet<Profissional>? Profissional { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=Profissionais.db;Cache=Shared");
    }

}