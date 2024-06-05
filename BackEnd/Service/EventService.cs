using AutoMapper;
using Data.CustomModel.Event;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service;

public class EventService : IEventService
{
    private readonly IEventRepository _EventRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, IMapper mapper)
    {
        _EventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task<EventModel> SaveEvent(EventModel eventModel)
    {
        var data = _mapper.Map<Event>(eventModel);
        var response = await _EventRepository.SaveEvent(data);
        return _mapper.Map<EventModel>(response);
    }

    public async Task<bool> DeleteEvent(Guid eventModelId)
    {
        var foundEvent = await this.GetEventById(eventModelId, true);
        if (foundEvent == null)
        {
            return await Task.FromResult(false);
        }
        if (foundEvent.StartDateTime <= DateTime.Now && DateTime.Now <= foundEvent.EndDateTime)
        {
            return await Task.FromResult(false);
        }
        return await _EventRepository.DeleteEvent(eventModelId);
    }

    public async Task<IEnumerable<EventModel>> GetAllEvent(bool isAdmin)
    {
        var data = await _EventRepository.GetAllEvent();
        if (!data.IsNullOrEmpty())
        {
            List<EventModel> result = _mapper.Map<List<EventModel>>(data);
             
            return !isAdmin ? result.Where(e => !e.IsDeleted) : result;
        }
        return null!;
    }

    public async Task<IEnumerable<EventModel>> GetAllEventByRecruiterId(Guid recruiterId, EventFilter eventFilter, string sortString, bool isAdmin)
    {
        var data = await _EventRepository.GetAllEventByRecruiterId(recruiterId, eventFilter, sortString);
       
        if (!data.IsNullOrEmpty())
        {
            List<EventModel> result = _mapper.Map<List<EventModel>>(data);
            return isAdmin ? result : result.Where(o => !o.IsDeleted).ToList();
        }
        return null!;
    }

    public async Task<bool> UpdateEvent(EventModel eventModel, Guid eventModelId)
    {
        var foundEvent = await this.GetEventById(eventModelId, true);
        if (foundEvent == null)
        {
            return await Task.FromResult(false);
        }
        if (foundEvent.StartDateTime <= DateTime.Now && DateTime.Now <= foundEvent.EndDateTime)
        {
            return await Task.FromResult(false);
        }
        var data = _mapper.Map<Event>(eventModel);
        return await _EventRepository.UpdateEvent(data, eventModelId);
    }

    public async Task<EventModel> GetEventById(Guid id, bool isAdmin)
    {
        var data = await _EventRepository.GetEventById(id);
        if (data == null)
        {
            return null!;
        }
        var respone = _mapper.Map<EventModel>(data);
        if (!isAdmin)
        {
            return respone.IsDeleted ? null : respone;
        }
        return respone;
    }
}