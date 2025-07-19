using EFCOREWEB.Helper;
using EFCOREWEB.Model;
using Microsoft.EntityFrameworkCore;
namespace EFCOREWEB.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<User>().HasData(
        new User
        {
          Id = 100,
          UserName = "Super-Admin",
          UserEmail = "AppDomain@kiit.ac.in",
          password = PasswordHash.Hash("Rahul6969"),
           Role="SuperAdmin"
        }
      );
    }
  }
}