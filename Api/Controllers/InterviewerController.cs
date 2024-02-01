using Api.ViewModels.Interviewer;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers;
[Authorize]
public class InterviewerController : BaseAPIController
{
    private readonly IInterviewerService _interviewerService;
    private readonly IMapper _mapper;

    public InterviewerController(IInterviewerService interviewerService, IMapper mapper)
    {
        _interviewerService = interviewerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInterviewer(Guid? id, Guid? departmentId)
    {
        //if (departmentId != null)
        //{
        //    var response = await _interviewerService.GetInterviewersInDepartment((Guid)departmentId);
        //}
        if (id != null)
        {
            var data = await _interviewerService.GetInterviewerById((Guid)id);
            return data switch
            {
                null => NotFound(),
                _ => Ok(data)
            };
        }

        else if (departmentId != null)
        {
            var response = await _interviewerService.GetInterviewersInDepartment((Guid)departmentId);

            if (response != null)
            {
                return Ok(response);
            }
            return Ok();
        }

        var reportList = await _interviewerService.GetAllInterviewer();
        if (reportList == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        return Ok(reportList);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SaveInterviewer(InterviewerAddModel request)
    {
        var response = await _interviewerService.SaveInterviewer(request);
        if (response != null)
        {
            return Ok(response);
        }
        return Ok(null);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateInterviewer(InterviewerUpdateModel request, Guid id)
    {
        return await _interviewerService.UpdateInterviewer(request, id) ? Ok(true) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteInterviewer(Guid id)
    {
        return await _interviewerService.DeleteInterviewer(id) ? Ok(true) : NotFound();
    }
}