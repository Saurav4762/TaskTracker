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
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentService studentService, IStudentRepository studentRepository)
    {
        _studentService = studentService;
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        try
        {
            var student = await _studentRepository.GetAllStudentsAsync();
            
            return Ok(new {message = "Student retrieved successfully" , Data = student});

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetstudentById(Guid id)
    {
        try
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(new {message = "Student retrieved successfully", Data = student});

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] StudentRequestDto dto)
    {
        try
        {
            var student = await _studentService.AddStudentAsync(dto);
            
            return Ok(new {message = "Student added successfully", id = student.Id});

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] StudentRequestDto dto)
    {
        try
        {
            var student = await _studentService.UpdateStudentAsync(id, dto);
            return Ok(new {message = "Student updated successfully", id = student.Id});

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        try
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok(new {message = "Student deleted successfully"});

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}