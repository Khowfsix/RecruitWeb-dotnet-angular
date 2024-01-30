using Service.Models;

namespace Service.Interfaces
{
    public interface ICategoryQuestionService
    {
        Task<IEnumerable<CategoryQuestionModel>> GetAllCategoryQuestions();

        Task<CategoryQuestionModel?> GetCategoryQuestionById(Guid id);

        Task<IEnumerable<CategoryQuestionModel>> GetCategoryQuestionsByName(string keyword);

        Task<IEnumerable<CategoryQuestionModel>> GetCategoryQuestionsByWeight(double weight);

        Task<CategoryQuestionModel> SaveCategoryQuestion(CategoryQuestionModel categoryQuestion);

        Task<bool> UpdateCategoryQuestion(CategoryQuestionModel categoryQuestion, Guid categoryQuestionId);

        Task<bool> DeleteCategoryQuestion(Guid requestId);
    }
}