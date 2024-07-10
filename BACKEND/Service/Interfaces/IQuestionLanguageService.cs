using Service.Models;

namespace Service.Interfaces
{
    public interface IQuestionLanguageService
    {
        Task<IEnumerable<QuestionLanguageModel>> GetAllQuestionLanguages();
    }
}