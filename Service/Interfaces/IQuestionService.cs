
using Service.Models;

namespace Service.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionModel>> GetAllQuestions(string? query, Guid? questionId);
        Task<List<QuestionModel>> GetAllLanguageQuestions();
        Task<List<QuestionModel>> GetAllSoftSkillQuestions();
        Task<List<QuestionModel>> GetAllTechnologyQuestions();

        Task<QuestionModel> GetQuestion(Guid id);

        //Task<List<CategoryQuestionModel>> GetAllQuestionCategories();
        Task<QuestionModel> AddQuestion(QuestionModel question);

        //IAsyncEnumerable<Task> AddQuestion(IAsyncEnumerable<QuestionModel> entities);
        Task<bool> UpdateQuestion(QuestionModel question, Guid id);

        Task<bool> RemoveQuestion(Guid id);
    }
}