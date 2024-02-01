using Api.ViewModels.Event;
using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers;
[Authorize]
public class EventController : BaseAPIController
{
    private readonly IEventService _EventService;
    private readonly IMapper _mapper;

    public EventController(IEventService eventService, IMapper mapper)
    {
        _EventService = eventService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEvent(Guid? id)
    {
        if (id != null)
        {
            var data = await _EventService.GetEventById((Guid)id);
            var response = _mapper.Map<EventViewModel>(data);
            return response switch
            {
                null => NotFound(),
                _ => Ok(response)
            };
        }

        var eventList = await _EventService.GetAllEvent();
        if (eventList.IsNullOrEmpty())
        {
            return Ok("Not found");
        }
        var responseList = _mapper.Map<List<EventViewModel>>(eventList);
        return Ok(responseList);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SaveEvent(EventAddModel request)
    {
        var modelData = _mapper.Map<EventModel>(request);
        var response = await _EventService.SaveEvent(modelData);
        if (response != null)
        {
            return Ok(response);
        }
        else
            return Ok("Not found");
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateEvent(EventUpdateModel request, Guid id)
    {
        var modelData = _mapper.Map<EventModel>(request);
        var response = await _EventService.UpdateEvent(modelData, id);
        if (response == true)
        {
            return Ok(response);
        }
        else
            return Ok("Not found");
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        var response = await _EventService.DeleteEvent(id);
        if (response == true)
        {
            return Ok(response);
        }
        else
            return Ok("Not found");
    }
}