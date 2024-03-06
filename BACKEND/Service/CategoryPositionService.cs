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

        public async Task<IEnumerable<CategoryPositionModel>> GetAllCategoryPositions()
        {
            var data = await _categoryPositionRepository.GetAllCategoryPositions();
            return data.Select(item => _mapper.Map<CategoryPositionModel>(item)).ToList();
        }
    }
}