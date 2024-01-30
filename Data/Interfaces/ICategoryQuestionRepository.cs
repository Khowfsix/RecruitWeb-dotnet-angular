using Data.Entities;

namespace Data.Interfaces
{
    public interface ICategoryQuestionRepository
    {
        Task<IEnumerable<CategoryQuestion>> GetAllCategoryQuestions();

        Task<CategoryQuestion?> GetCategoryQuestionById(Guid id);

        Task<IEnumerable<CategoryQuestion>> GetCategoryQuestionsByName(string keyword);

        Task<IEnumerable<CategoryQuestion>> GetCategoryQuestionsByWeight(double weight);

        Task<CategoryQuestion> SaveCategoryQuestion(CategoryQuestion categoryQuestion);

        Task<bool> UpdateCategoryQuestion(CategoryQuestion categoryQuestion, Guid categoryQuestionId);

        Task<bool> DeleteCategoryQuestion(Guid requestId);

        Task<Guid> GetIdCategoryQuestion(string keyword);
    }
}