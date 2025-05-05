using Microsoft.EntityFrameworkCore;
using TaskTracker.Contracts.Response;
using TaskTracker.Data;
using TaskTracker.Repository.Interface;

namespace TaskTracker.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentResponseDto>> GetAllStudentsAsync()
    {
        var students = await _context.Students.Select(a => new StudentResponseDto
        {
            Id = a.Id,
            FullName = a.FullName,
            Email = a.Email,
        }).ToListAsync();
        return students;

    }

    public async Task<StudentResponseDto> GetStudentByIdAsync(Guid id)
    {
       var student = await _context.Students
           .Where(a => a.Id == id)
           .Select(a=>new StudentResponseDto
           {
               Id = a.Id,
               FullName = a.FullName,
               Email = a.Email,
           }).FirstOrDefaultAsync();

       if (student == null)
       {
           throw new Exception("Student not found");
       }
       return student;
           
           
    }
}