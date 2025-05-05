using TaskTracker.Contracts.Request;
using TaskTracker.Entities;

namespace TaskTracker.Service.Interface;

public interface IAssignmentservice
{
    Task <Assignment> AddAssignmentAsync (AssignmentRequestDto dto);
    
    Task<Assignment> UpdateAssignmentAsync ( Guid id, AssignmentRequestDto dto);
    
    Task DeleteAssignmentAsync (Guid id);
    
}