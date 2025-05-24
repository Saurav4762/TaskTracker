using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Entities;
using TaskTracker.Data;
using TaskTracker.Contracts;
using TaskTracker.Contracts.Request;
using TaskTracker.Service;
using TaskTracker.Repository;
using TaskTracker.Repository.Interface;
using TaskTracker.Service.Interface;

namespace TaskTracker.Controllers;
[Route("api/[controller]")]
[ApiController]

public class AssignmentController : ControllerBase
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IAssignmentservice _assignmentService;
    private readonly ILogger<AssignmentController> _logger;

    public AssignmentController(IAssignmentRepository assignmentRepository, IStudentRepository studentRepository, IAssignmentservice assignmentService, ILogger<AssignmentController> logger)
    {
        _assignmentRepository = assignmentRepository;
        _assignmentService = assignmentService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAssignments()
    {
        try
        {
            _logger.LogInformation("Getting all assignments");
            var assignment = await _assignmentRepository.GetAllAssignmentAsync();
            return Ok(new {message = "Assignments Found successfully", Data = assignment});

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssignment(Guid id)
    {
        try
        {
            var assignment = await _assignmentRepository.GetAssignmentByIdAsync(id);
            
            return Ok(new {message = "Assignment Found successfully", Data = assignment});

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAssignment([FromBody] AssignmentRequestDto dto)
    {
        try
        {
            _logger.LogInformation("Adding new assignment");
            
            var assignment = await _assignmentService.AddAssignmentAsync(dto);
            
            _logger.LogInformation("Assignment created successfully{assignmentId}", assignment.Id);
            
            return Ok(new {message = "Assignment Added successfully", id = assignment.Id});

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAssignment(Guid id, [FromBody] AssignmentRequestDto dto)
    {
        try
        {
            var assignment = await _assignmentRepository.GetAssignmentByIdAsync(id);
            return Ok(new {message = "Assignment Updated Successfully", id = assignment.Id});

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(Guid id)
    {
        try
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return Ok(new {message = "Assignment Deleted successfully"});

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }
}