using TaskTracker.Contracts.Response;

namespace TaskTracker.Repository.Interface;

public interface IStudentRepository
{
    Task<List<StudentResponseDto>> GetAllStudentsAsync();
    
    Task<StudentResponseDto> GetStudentByIdAsync(Guid id);
    
}