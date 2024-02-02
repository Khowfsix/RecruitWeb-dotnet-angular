using Api.ViewModels.Itrsinterview;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers;

[Authorize]
public class ItrsinterviewController : BaseAPIController
{
    private readonly IItrsinterviewService _itrsinterviewService;
    private readonly IMapper _mapper;

    public ItrsinterviewController(IItrsinterviewService itrsinterviewService, IMapper mapper)
    {
        _itrsinterviewService = itrsinterviewService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItrsinterview(Guid? id)
    {
        if (id != null)
        {
            var data = await _itrsinterviewService.GetItrsinterviewById((Guid)id);
            return data switch
            {
                null => Ok("Not found"),
                _ => Ok(data)
            };
        }
        var reportList = await _itrsinterviewService.GetAllItrsinterview();
        if (reportList == null)
        {
            return Ok("Not found");
        }
        return Ok(reportList);
    }

    [HttpPost]
    [Authorize(Roles = "Recruiter,Interviewer,Admin")]
    public async Task<IActionResult> SaveItrsinterview(ItrsinterviewAddModel request, Guid interviewerId)
    {
        if (request == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        var modelRequestData = _mapper.Map<ItrsinterviewModel>(request); // <ItrsinterviewModel>
        var response = await _itrsinterviewService.SaveItrsinterview(modelRequestData, interviewerId);
        if (response == null)
        {
            return BadRequest();
        }

        if (response.ItrsinterviewId != Guid.Empty)
        {
            return Ok(response);
        }
        return StatusCode(StatusCodes.Status409Conflict);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Recruiter,Interviewer,Admin")]
    public async Task<IActionResult> UpdateItrsinterview(ItrsinterviewUpdateModel request, Guid id, Guid interviewerId)
    {
        var ItrsinterviewModel = _mapper.Map<ItrsinterviewModel>(request);
        var response = await _itrsinterviewService.UpdateItrsinterview(ItrsinterviewModel, id, interviewerId);
        return response ? Ok(true) : Ok("Update is not success instead of Confict or Not found");
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Recruiter,Interviewer,Admin")]
    public async Task<IActionResult> DeleteItrsinterview(Guid id)
    {
        return await _itrsinterviewService.DeleteItrsinterview(id) ? Ok(true) : Ok("Not found");
    }
}