using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public LevelService(ILevelRepository levelRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LevelModel>> GetAllLevels(bool isAdmin)
        {
            var data = await _levelRepository.GetAllLevels();
            var modelDatas = _mapper.Map<List<LevelModel>>(data);

            if (!isAdmin)
            {
                return modelDatas.Where(o => o.IsDeleted == false);
            }
            return modelDatas;
        }

        public async Task<LevelModel> CreateLevel(LevelModel request)
        {
            var data = _mapper.Map<Level>(request);
            var response = await _levelRepository.AddLevel(data);
            return _mapper.Map<LevelModel>(response);
        }
        public async Task<bool> UpdateLevel(LevelModel levelModel, Guid id)
        {
            var data = _mapper.Map<Level>(levelModel);
            return await _levelRepository.UpdateLevel(data, id);
        }
        public async Task<bool> RemoveLevel(Guid id)
        {
            return await _levelRepository.RemoveLevel(id);
        }
    }
}