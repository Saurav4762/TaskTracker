using Microsoft.EntityFrameworkCore;
using TaskTracker.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace TaskTracker.Data;

public class ApplicationDbContext : DbContext

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
}