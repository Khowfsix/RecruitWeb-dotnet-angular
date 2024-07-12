using Data.Entities;

namespace Data.Interfaces
{
    public interface IQuestionLanguageRepository : IRepository<QuestionLanguage>
    {
        Task<IEnumerable<QuestionLanguage>> GetAllQuestionLanguages();
        Task<QuestionLanguage> AddQuestionLanguage(QuestionLanguage data);
    }
}