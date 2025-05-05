using TaskTracker.Contracts.Response;
using TaskTracker.Entities;

namespace TaskTracker.Repository.Interface;

public interface IAssignmentRepository
{
    Task<AssignmentResponseDto> GetAssignmentByIdAsync (Guid id);
    
    Task<List<AssignmentResponseDto>> GetAllAssignmentAsync();
    
}