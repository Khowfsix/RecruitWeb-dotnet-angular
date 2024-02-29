using AutoMapper;
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

        public async Task<List<PositionModel>> GetAllPositions(Guid? departmentId)
        {
            var entityDatas = await _positionRepository.GetAllPositions();
            List<PositionModel> list = new List<PositionModel>();
            if (departmentId == null)
            {
                foreach (var item in entityDatas)
                {
                    list.Add(_mapper.Map<PositionModel>(item));
                }
            }
            else
            {
                foreach (var item in entityDatas)
                {
                    if (item.DepartmentId.Equals(departmentId))
                    {
                        list.Add(_mapper.Map<PositionModel>(item));
                    }
                }
            }
            return list;
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

        public async Task<bool> UpdatePosition(PositionModel position, Guid positionId)
        {
            var data = _mapper.Map<Position>(position);
            return await _positionRepository.UpdatePosition(data, positionId);
        }
    }
}