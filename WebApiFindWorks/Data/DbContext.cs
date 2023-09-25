using WebApiFindWorks.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiFindWorks.Data;
public class WebApiFindWorksDbContext : DbContext
{
    public DbSet<Profissional>? Profissional { get; set; }
    public DbSet<Usuario>? Usuario { get; set; }
    public DbSet<Rating>? Rating { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=DatabaseWebApiFindWorks.db;Cache=Shared");
    }
}