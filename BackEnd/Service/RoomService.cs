using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _reportRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<RoomModel> SaveRoom(RoomModel reportModel)
        {
            var entity = _mapper.Map<Room>(reportModel);
            var response = await _reportRepository.SaveRoom(entity);
            return _mapper.Map<RoomModel>(response);
        }

        public async Task<bool> DeleteRoom(Guid reportModelId)
        {
            return await _reportRepository.DeleteRoom(reportModelId);
        }

        public async Task<IEnumerable<RoomModel>> GetAllRoom()
        {
            var entities = await _reportRepository.GetAllRoom();
            List<RoomModel> models = new List<RoomModel>();
            foreach (var item in entities)
            {
                models.Add(_mapper.Map<RoomModel>(item));
            }
            return models;
        }

        public async Task<bool> UpdateRoom(RoomModel reportModel, Guid reportModelId)
        {
            var entity = _mapper.Map<Room>(reportModel);
            return await _reportRepository.UpdateRoom(entity, reportModelId);
        }
    }
}