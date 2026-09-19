using ConsoleEMS.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEMS.Dal;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Employee> Employees { get; set; }
}