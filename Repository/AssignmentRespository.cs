using Microsoft.EntityFrameworkCore;
using TaskTracker.Contracts.Response;
using TaskTracker.Data;
using TaskTracker.Repository.Interface;

namespace TaskTracker.Repository;

public class AssignmentRespository:IAssignmentRepository
{
    private readonly ApplicationDbContext _context;

    public AssignmentRespository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<AssignmentResponseDto> GetAssignmentByIdAsync(Guid id)
    {
        var assignment = await _context.Assignments
            .Where(a => a.Id == id)
            .Select(a => new AssignmentResponseDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                DueDate = a.DueDate,
                StudentId = a.StudentId,

            }).FirstOrDefaultAsync();

      
        return assignment;
    }

    public async Task<List<AssignmentResponseDto>> GetAllAssignmentAsync()
    {
        var assignments = await _context.Assignments
            .Select(a => new AssignmentResponseDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                DueDate = a.DueDate,
                StudentId = a.StudentId,
            }).ToListAsync();
        return assignments;
    }
}