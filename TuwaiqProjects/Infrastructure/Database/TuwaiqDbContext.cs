using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TuwaiqProjects.Domain.Employees;
using TuwaiqProjects.Domain.Org;

namespace TuwaiqProjects.Infrastructure.Database;

public class TuwaiqDbContext : DbContext
{
    public TuwaiqDbContext(DbContextOptions<TuwaiqDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees1 { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(b =>
        {
            b.HasKey(e => e.Id);
            b.Property(e => e.Name).IsRequired().HasMaxLength(DbConst.Employee.MaxNameLength);
            b.Property(e => e.Email).IsRequired().HasMaxLength(100);
            b.HasOne(e => e.Department)
                  .WithMany(d => d.Employees)
                  .HasForeignKey(e => e.DepartmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Department>(b =>
        {
            b.HasKey(d => d.Id);
            b.Property(d => d.Name).IsRequired().HasMaxLength(100);
        });

       
    }
}