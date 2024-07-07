using Api.ViewModels.AdminAward;
using Api.ViewModels.EventHasPosition;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers;

[Authorize]
public class EventHasPositionController : BaseAPIController
{
    private readonly IEventHasPositionService _EventHasPositionService;
    private readonly IMapper _mapper;

    public EventHasPositionController(IEventHasPositionService EventHasPositionService, IMapper mapper)
    {
        _EventHasPositionService = EventHasPositionService;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin, Recruiter")]
    public async Task<IActionResult> SaveEventHasPosition(EventHasPositionAddModel request)
    {
        var modelData = _mapper.Map<EventHasPositionModel>(request);
        var response = await _EventHasPositionService.SaveEventHasPosition(modelData);
        if (response != null)
        {
            return Ok(response);
        }
        else
            return Ok("Not found");
    }


    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin, Recruiter")]
    public async Task<IActionResult> DeleteEventHasPosition(Guid id)
    {
        var response = await _EventHasPositionService.DeleteEventHasPosition(id);
        if (response == true)
        {
            return Ok(response);
        }
        else
            return Ok("Not found");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEventHasPositions()
    {
        var listModelDatas = await _EventHasPositionService.GetAllEventHasPositions();
        var response = _mapper.Map<List<EventHasPositionViewModel>>(listModelDatas);
        return Ok(response);
    }
}