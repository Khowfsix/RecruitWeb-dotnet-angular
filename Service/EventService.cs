using AutoMapper;
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
        return await _EventRepository.DeleteEvent(eventModelId);
    }

    public async Task<IEnumerable<EventModel>> GetAllEvent()
    {
        var data = await _EventRepository.GetAllEvent();
        if (!data.IsNullOrEmpty())
        {
            List<EventModel> result = _mapper.Map<List<EventModel>>(data);
            return result;
        }
        return null!;
    }

    public async Task<bool> UpdateEvent(EventModel eventModel, Guid eventModelId)
    {
        var data = _mapper.Map<Event>(eventModel);
        return await _EventRepository.UpdateEvent(data, eventModelId);
    }

    public async Task<EventModel> GetEventById(Guid id)
    {
        var data = await _EventRepository.GetEventById(id);
        if (data == null)
        {
            return null!;
        }
        var respone = _mapper.Map<EventModel>(data);
        return respone;
    }
}