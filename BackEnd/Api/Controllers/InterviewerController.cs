using Api.ViewModels.Interviewer;
using AutoMapper;
using Data.CustomModel.Interviewer;
using Data.CustomModel.Position;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers;

[Authorize]
public class InterviewerController : BaseAPIController
{
    private readonly IInterviewerService _interviewerService;
    private readonly IInterviewService _interviewService;
    private readonly IMapper _mapper;

    public InterviewerController(IInterviewerService interviewerService, IInterviewService interviewService, IMapper mapper)
    {
        _interviewerService = interviewerService;
        _interviewService = interviewService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInterviewer([FromQuery] InterviewerFilterModel interviewerFilterModel, 
        Guid? id, 
        Guid? companyId,
        string? sortString = "FullName_ASC")
    {
        var isAdmin = HttpContext.User.IsInRole("Admin");
        if (id != null)
        {
            var data = await _interviewerService.GetInterviewerById((Guid)id);
            return data switch
            {
                null => NotFound(),
                _ => Ok(data)
            };
        }
        else if (companyId != null)
        {
            var filter = _mapper.Map<InterviewerFilter>(interviewerFilterModel);
            var models = await _interviewerService.GetInterviewersInCompany((Guid)companyId, filter, sortString);
            var response = _mapper.Map<List<InterviewerViewModel>>(models);
            foreach (var interviewer in response)
            {
                var lastInterview = await _interviewService.GetLastInterviewByInterviewerId(interviewer.InterviewerId);
                if (lastInterview == null)
                {
                    interviewer.daysToLastInterview = null;
                    continue;
                }
                TimeSpan date = (TimeSpan)(lastInterview.MeetingDate - DateTime.Now);
                interviewer.daysToLastInterview = date.Days;
            }
            
            if (!isAdmin)
            {
                response = response.Where(e => !e.IsDeleted).ToList();
            }

            return response != null ? Ok(response) : Ok();
        }

        var reportList = await _interviewerService.GetAllInterviewer();
        if (reportList == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        return isAdmin ? Ok(reportList) : Ok(reportList.Where(e => !e.IsDeleted).ToList());
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Recruiter")]
    public async Task<IActionResult> SaveInterviewer(InterviewerAddModel request)
    {
        var modelData = _mapper.Map<InterviewerModel>(request);
        var response = await _interviewerService.SaveInterviewer(modelData);
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
        var modelData = _mapper.Map<InterviewerModel>(request);
        return await _interviewerService.UpdateInterviewer(modelData, id) ? Ok(true) : BadRequest();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin, Recruiter")]
    public async Task<IActionResult> DeleteInterviewer(Guid id)
    {
        return await _interviewerService.DeleteInterviewer(id) ? Ok(true) : NotFound();
    }
}