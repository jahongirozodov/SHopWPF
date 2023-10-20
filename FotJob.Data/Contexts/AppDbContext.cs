using ForJob.Domain.Shops;
using ForJob.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FotJob.Data.Contexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         string connectionString = "server=localhost;port=3306;database=ForJobDb;user=root;password=jahon2804";
         optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new System.Version(8, 0, 22)));
    }
    public DbSet<User> Users {get;set; }
    public DbSet<Shop> Shops {get;set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>().HasQueryFilter(user => EF.Property<bool>(user, "isDeleted") == false);
    }
}
