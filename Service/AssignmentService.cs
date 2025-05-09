using TaskTracker.Contracts.Request;
using TaskTracker.Data;
using TaskTracker.Entities;
using TaskTracker.Service.Interface;

namespace TaskTracker.Service;

public class AssignmentService : IAssignmentservice
{
    
    private readonly ApplicationDbContext _db;

    public AssignmentService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Assignment> AddAssignmentAsync(AssignmentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new Exception("Title is required");
        }
        var assignment = new Assignment
        {
            Title = dto.Title,
            Description = dto.Description,
            StudentId = dto.StudentId,
            DueDate = dto.DueDate,
        };
        
        await _db.Assignments.AddAsync (assignment);
        await _db.SaveChangesAsync ();
        return assignment;
    }

    public async Task<Assignment> UpdateAssignmentAsync(Guid id, AssignmentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new Exception("Title is required");
        }
        var assignment = await _db.Assignments.FindAsync (id);
        if (assignment == null)
        {
            throw new Exception ("Assignment not found");
        }
        
        assignment.Title = dto.Title;
        assignment.Description = dto.Description;
        assignment.DueDate = dto.DueDate;
        assignment.StudentId = dto.StudentId;
        
        await _db.SaveChangesAsync ();
        return assignment;
    }

    public async Task DeleteAssignmentAsync(Guid id)
    {
        var assignment = await _db.Assignments.FindAsync (id);
        if (assignment == null)
        {
            throw new Exception ("Assignment not found");
        }
        _db.Assignments.Remove (assignment);
        await _db.SaveChangesAsync ();
    }
}