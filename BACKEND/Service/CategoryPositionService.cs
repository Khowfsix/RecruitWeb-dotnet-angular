using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class CategoryPositionService : ICategoryPositionService
    {
        private readonly ICategoryPositionRepository _categoryPositionRepository;
        private readonly IMapper _mapper;

        public CategoryPositionService(ICategoryPositionRepository categoryPositionRepository, IMapper mapper)
        {
            _categoryPositionRepository = categoryPositionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryPositionModel>> GetAllCategoryPositions(bool isAdmin)
        {
            var data = await _categoryPositionRepository.GetAllCategoryPositions();
            var modelDatas = _mapper.Map<List<CategoryPositionModel>>(data);

            if (!isAdmin)
            {
                return modelDatas.Where(o => o.IsDeleted == false);
            }
            return modelDatas;
        }

        public async Task<CategoryPositionModel> CreateCategoryPosition(CategoryPositionModel request)
        {
            var data = _mapper.Map<CategoryPosition>(request);
            var response = await _categoryPositionRepository.AddCategoryPosition(data);
            return _mapper.Map<CategoryPositionModel>(response);
        }

        public async Task<bool> UpdateCategoryPosition(CategoryPositionModel request, Guid id)
        {
            var entity = _mapper.Map<CategoryPosition>(request);
            return await _categoryPositionRepository.UpdateCategoryPosition(entity, id);
        }
    }
}