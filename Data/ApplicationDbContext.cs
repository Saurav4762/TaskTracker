using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Entities;

namespace TaskTracker.Data;

public class ApplicationDbContext : DbContext 

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Assignment> Assignments { get; set; }
    
}