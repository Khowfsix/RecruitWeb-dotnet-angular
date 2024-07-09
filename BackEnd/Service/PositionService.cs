using AutoMapper;
using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
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
            if (position.MinSalary > position.MaxSalary)
                return null;
            if (position.StartDate > position.EndDate)
                return null;

            var response = await _positionRepository.AddPosition(data);
            return _mapper.Map<PositionModel>(response);
        }

        public async Task<List<PositionModel>> GetAllByRecruiterId(Guid recruiterId, bool isAdmin)
        {
            var entityDatas = await _positionRepository.GetAllByRecruiterId(recruiterId);
            var listPositionModel = _mapper.Map<List<PositionModel>>(entityDatas);

            return isAdmin ? listPositionModel : listPositionModel.Where(o => !o.IsDeleted).ToList();
        }

        public async Task<List<PositionModel>> GetAllPositions(bool isAdmin, PositionFilter positionFilter, string sortString)
        {
            var entityDatas = await _positionRepository.GetAllPositions(positionFilter, sortString);
            var listPositionModel = _mapper.Map<List<PositionModel>>(entityDatas);

            return isAdmin ? listPositionModel : listPositionModel.Where(o => !o.IsDeleted).ToList();
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

        public async Task<bool> RemovePosition(Guid positionId)
        {
            var foundPosition = await this.GetPositionById(positionId);

            if (foundPosition == null)
            {
                return await Task.FromResult(false);
            }

            if (foundPosition.StartDate <= DateTime.Today && DateTime.Today <= foundPosition.EndDate)
            {
                return await Task.FromResult(false);
            }
            return await _positionRepository.RemovePosition(positionId);
        }

        public async Task<bool> UpdatePosition(PositionModel positionModel, Guid positionId)
        {
            var foundPosition = await this.GetPositionById(positionId);

            if (foundPosition == null)
            {
                return await Task.FromResult(false);
            }

            if (foundPosition.StartDate <= DateTime.Today && DateTime.Today <= foundPosition.EndDate) {
                return await Task.FromResult(false);
            }

            if (positionModel.MinSalary > positionModel.MaxSalary) 
                return await Task.FromResult(false);
            if (positionModel.StartDate > positionModel.EndDate)
            {
                return await Task.FromResult(false);
            }

            _mapper.Map(positionModel, foundPosition);

            foundPosition.MinSalary = positionModel.MinSalary;
            foundPosition.MaxSalary = positionModel.MaxSalary;

            var data = _mapper.Map<Position>(foundPosition);
            return await _positionRepository.UpdatePosition(data, positionId);
        }
    }
}