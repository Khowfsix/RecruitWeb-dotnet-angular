using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Paging;
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

        public async Task<PageResponse<PositionModel>> GetAllPositions(bool isAdmin, PositionFilter positionFilter, string sortString, PageRequest pageRequest)
        {
            PageResponse<Position> entityDatas = await _positionRepository.GetAllPositions(isAdmin, positionFilter, sortString, pageRequest);

            var listPositionModel = _mapper.Map<List<PositionModel>>(entityDatas.Items);
            var pageResponse = new PageResponse<PositionModel>(listPositionModel, entityDatas.TotalMatchedInDb, entityDatas.PageIndex, entityDatas.PageSize);
            return pageResponse;

            //return _mapper.Map<PageResponse<PositionModel>>(entityDatas);
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