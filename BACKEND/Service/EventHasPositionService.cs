using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service;

public class EventHasPositionService : IEventHasPositionService
{
    private readonly IEventHasPositionRepository _EventHasPositionRepository;
    private readonly IMapper _mapper;

    public EventHasPositionService(IEventHasPositionRepository EventHasPositionRepository, IMapper mapper)
    {
        _EventHasPositionRepository = EventHasPositionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventHasPositionModel>> GetAllEventHasPositions()
    {
        var data = await _EventHasPositionRepository.GetAllEventHasPositions();
        var modelDatas = _mapper.Map<List<EventHasPositionModel>>(data);

        return modelDatas;
    }

    public async Task<EventHasPositionModel> SaveEventHasPosition(EventHasPositionModel EventHasPositionModel)
    {
        var data = _mapper.Map<EventHasPosition>(EventHasPositionModel);
        var response = await _EventHasPositionRepository.SaveEventHasPosition(data);
        return _mapper.Map<EventHasPositionModel>(response);
    }

    public async Task<bool> DeleteEventHasPosition(Guid EventHasPositionModelId)
    {
        return await _EventHasPositionRepository.DeleteEventHasPosition(EventHasPositionModelId);
    }
}