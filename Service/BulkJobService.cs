using System.Transactions;
using TaskTracker.Contracts.Request;
using TaskTracker.Service.Interface;

namespace TaskTracker.Service;

public class BulkJobService : IBulkJobService
{
    private readonly IStudentService _studentService;
    private readonly IAssignmentservice _assignmentService;

    public BulkJobService(IStudentService studentService, IAssignmentservice assignmentService)
    {
        _studentService = studentService;
        _assignmentService = assignmentService;
    }

    public async Task ImportStudentsAsync(List<StudentRequestDto>? students)
    {
        var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        foreach (var student in students)
        {
            await _studentService.AddStudentAsync(student);
        }
        
        scope.Complete();
    }

    public async Task ImportAssignmentsAsync(List<AssignmentRequestDto> assignments)
    {
        var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        foreach (var assignment in assignments)
        {
            await _assignmentService.AddAssignmentAsync(assignment);
        }
        scope.Complete();
    }
}