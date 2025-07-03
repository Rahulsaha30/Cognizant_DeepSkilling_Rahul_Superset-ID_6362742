using Microsoft.EntityFrameworkCore;
using Model;

public class AppDbContext : DbContext
{
  public DbSet<Product> products { get; set; }
  public DbSet<Category> categories { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
  optionsBuilder.UseSqlServer(
            "Server=RAHUL69\\SQLEXPRESS;Database=RetailInventory;Trusted_Connection=True;TrustServerCertificate=True;");
    }
  }
