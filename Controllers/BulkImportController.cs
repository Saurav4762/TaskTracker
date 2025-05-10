using System.Security.Cryptography.X509Certificates;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Contracts.Request;
using TaskTracker.Entities;
using TaskTracker.Service;
using TaskTracker.Service.Interface;

namespace TaskTracker.Controllers;

public class BulkImportController: ControllerBase
{
    private readonly IBulkJobService _bulkJobService;

    public BulkImportController(IBulkJobService bulkJobService)
    {
        _bulkJobService = bulkJobService;
    }

    [HttpPost("import-students")]
    public async Task<IActionResult> BulkImport([FromBody] StudentRequestDto dto)
    {
        var jobId = BackgroundJob.Enqueue<IBulkJobService>(x => x.ImportStudentsAsync(dto.Students));
            
        return Accepted(new
        {
            JobId = jobId,
            status = "Queued"
        });

    }

    public IActionResult Check(string jobId)
    {
        try
        {
            var jobState = JobStorage.Current.GetMonitoringApi().JobDetails(jobId);
            if (jobState != null)
            {
                return NotFound(new { message = "Job not found" });
            }

            var state = jobState.History.FirstOrDefault()?.StateName;
            return Ok(new
            {
                JobId = jobId,
                status = state
            });


        }
        catch (Exception e)
        {
          return Ok(new{message = "An error occured: " + e.Message});
        }
    }

    [HttpPost("import-assignments")]
    public async Task<IActionResult> ImportAssignments([FromBody] AssignmentRequestDto dto)
    {
        var jobid = BackgroundJob.Enqueue<IBulkJobService>(x => x.ImportAssignmentsAsync(dto.Assignments));

        return Accepted(new
        {
            JobId = jobid,
            status = "Queued"
        });
    }
}