using TaskTracker.Contracts.Request;
using TaskTracker.Entities;

namespace TaskTracker.Service.Interface;

public interface IStudentService
{
    Task<Student> AddStudentAsync ( StudentRequestDto dto );
    
    Task<Student> UpdateStudentAsync ( Guid id, StudentRequestDto dto );
    
    Task DeleteStudentAsync (Guid id);
    
}