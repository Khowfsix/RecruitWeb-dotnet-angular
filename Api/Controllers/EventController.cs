using Api.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers;
[Authorize]
public class EventController : BaseAPIController
{
    private readonly IEventService _EventService;

    public EventController(IEventService eventService)
    {
        _EventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEvent(Guid? id)
    {
        if (id != null)
        {
            var data = await _EventService.GetEventById((Guid)id);
            return data switch
            {
                null => NotFound(),
                _ => Ok(data)
            };
        }

        var eventList = await _EventService.GetAllEvent();
        if (eventList == null)
        {
            return Ok("Not found");
        }
        return Ok(eventList);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SaveEvent(EventAddModel request)
    {
        var response = await _EventService.SaveEvent(request);
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
        var response = await _EventService.UpdateEvent(request, id);
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