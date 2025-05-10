namespace TaskTracker.Contracts.Request;

public class AssignmentRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsSubmitted { get; set; }
    public Guid StudentId { get; set; }
    public List<AssignmentRequestDto> Assignments { get; set; }
}