using AutoMapper;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class CategoryQuestionService : ICategoryQuestionService
    {
        private readonly ICategoryQuestionRepository _categoryQuestionRepository;
        private readonly IMapper _mapper;

        public CategoryQuestionService(ICategoryQuestionRepository categoryQuestionRepository, IMapper mapper)
        {
            _categoryQuestionRepository = categoryQuestionRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCategoryQuestion(Guid requestId)
        {
            return await _categoryQuestionRepository.DeleteCategoryQuestion(requestId);
        }

        public async Task<IEnumerable<CategoryQuestionModel>> GetAllCategoryQuestions()
        {
            var data = await _categoryQuestionRepository.GetAllCategoryQuestions();
            return data.Select(item => _mapper.Map<CategoryQuestionModel>(item)).ToList();
        }

        public async Task<CategoryQuestionModel?> GetCategoryQuestionById(Guid id)
        {
            var data = await _categoryQuestionRepository.GetCategoryQuestionById(id);
            if (data == null) return null;
            var response = _mapper.Map<CategoryQuestionModel>(data);
            return response;
        }

        public async Task<IEnumerable<CategoryQuestionModel>> GetCategoryQuestionsByName(string keyword)
        {
            var data = await _categoryQuestionRepository.GetCategoryQuestionsByName(keyword);
            return data.Select(item => _mapper.Map<CategoryQuestionModel>(item)).ToList();
        }

        public async Task<IEnumerable<CategoryQuestionModel>> GetCategoryQuestionsByWeight(double weight)
        {
            var data = await _categoryQuestionRepository.GetCategoryQuestionsByWeight(weight);
            return data.Select(item => _mapper.Map<CategoryQuestionModel>(item)).ToList();
        }

        public async Task<CategoryQuestionModel> SaveCategoryQuestion(CategoryQuestionModel categoryQuestion)
        {
            var data = _mapper.Map<CategoryQuestionModel>(categoryQuestion);
            var response = await _categoryQuestionRepository.SaveCategoryQuestion(data);

            return _mapper.Map<CategoryQuestionModel>(response);
        }

        public async Task<bool> UpdateCategoryQuestion(CategoryQuestionModel categoryQuestion, Guid categoryQuestionId)
        {
            var data = _mapper.Map<CategoryQuestionModel>(categoryQuestion);
            return await _categoryQuestionRepository.UpdateCategoryQuestion(data, categoryQuestionId);
        }
    }
}