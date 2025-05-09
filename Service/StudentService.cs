using TaskTracker.Contracts.Request;
using TaskTracker.Data;
using TaskTracker.Entities;
using TaskTracker.Service.Interface;

namespace TaskTracker.Service;

public class StudentService:IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Student> AddStudentAsync(StudentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            throw new Exception("Full name is required");
        }
        var student = new Student
        {
            FullName = dto.FullName,
            Email = dto.Email,

        };
        
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> UpdateStudentAsync(Guid id, StudentRequestDto dto)
    {
        if (string.IsNullOrEmpty(dto.FullName))
        {
            throw new Exception("Full name is required");
        }
        var student = await _context.Students.FindAsync(id);
        if (student == null) 
        {
            throw new Exception("Student not found");
        }
        student.FullName = dto.FullName;
        student.Email = dto.Email;
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task DeleteStudentAsync(Guid id)
    {
        var student =await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception ("Student not found");
        }
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();  
        
    }
}