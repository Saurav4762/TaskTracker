using TaskTracker.Contracts.Request;
using TaskTracker.Entities;

namespace TaskTracker.Service.Interface;

public interface IBulkJobService
{
    public Task ImportStudentsAsync(List<StudentRequestDto>? students);
    
    public Task ImportAssignmentsAsync(List<AssignmentRequestDto> assignments);
}