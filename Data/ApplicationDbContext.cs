using Microsoft.EntityFrameworkCore;
using TaskTracker.Entities;

namespace TaskTracker.Data;

public class ApplicationDbContext : DbContext

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
}