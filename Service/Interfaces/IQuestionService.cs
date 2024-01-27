using Data.Models;
using Data.ViewModels.Question;

namespace Service.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionViewModel>> GetAllQuestions(string? query, Guid? questionId);
        Task<List<QuestionViewModel>> GetAllLanguageQuestions();
        Task<List<QuestionViewModel>> GetAllSoftSkillQuestions();
        Task<List<QuestionViewModel>> GetAllTechnologyQuestions();

        Task<QuestionViewModel> GetQuestion(Guid id);

        //Task<List<CategoryQuestionModel>> GetAllQuestionCategories();
        Task<QuestionViewModel> AddQuestion(QuestionAddModel question);

        //IAsyncEnumerable<Task> AddQuestion(IAsyncEnumerable<QuestionModel> entities);
        Task<bool> UpdateQuestion(QuestionUpdateModel question, Guid id);

        Task<bool> RemoveQuestion(Guid id);
    }
}