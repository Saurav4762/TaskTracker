namespace TaskTracker.Contracts.Response;

public class StudentResponseDto
{
    public Guid Id { get; set; }
    public String? FullName { get; set; }
    public String? Email { get; set; }
}