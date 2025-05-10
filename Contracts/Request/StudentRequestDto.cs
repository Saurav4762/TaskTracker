namespace TaskTracker.Contracts.Request;

public class StudentRequestDto
{
    public string FullName { get; set; }
    
    public string Email { get; set; }
    public List<StudentRequestDto> Students { get; set; }
}