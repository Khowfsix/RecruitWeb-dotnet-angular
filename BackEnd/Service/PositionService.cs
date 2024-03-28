using AutoMapper;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<PositionModel> AddPosition(PositionModel position)
        {
            var data = _mapper.Map<Position>(position);
            var response = await _positionRepository.AddPosition(data);
            return _mapper.Map<PositionModel>(response);
        }

        public async Task<List<PositionModel>> GetAllPositions(PositionFilter positionFilter, string sortString)
        {
            var entityDatas = await _positionRepository.GetAllPositions(positionFilter, sortString);
            var listPositionModel = _mapper.Map<List<PositionModel>>(entityDatas);
            return listPositionModel;
        }

        public Task<List<PositionModel>> GetAllPositionsByCurrentUser(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PositionModel> GetPositionById(Guid id)
        {
            var data = await _positionRepository.GetPositionById(id);
            return _mapper.Map<PositionModel>(data);
        }

        public async Task<PositionAllMinMaxRange> GetAllMinMaxRange()
        {
            var data = await _positionRepository.GetAllMinMaxRange();
            return data;
        }

        public async Task<List<PositionModel>> GetPositionByName(string name)
        {
            var entityDatas = await _positionRepository.GetPositionByName(name);
            List<PositionModel> resultList = _mapper.Map<List<PositionModel>>(entityDatas);
            return resultList;
        }

        public async Task<bool> RemovePosition(Guid position)
        {
            return await _positionRepository.RemovePosition(position);
        }

        public async Task<bool> UpdatePosition(PositionModel positionModel, Guid positionId)
        {
            var foundPosition = await this.GetPositionById(positionId);

            _mapper.Map(positionModel, foundPosition);

            var data = _mapper.Map<Position>(foundPosition);
            return await _positionRepository.UpdatePosition(data, positionId);
        }
    }
}