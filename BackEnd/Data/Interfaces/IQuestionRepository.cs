using Data.Entities;

namespace Data.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> GetAllQuestions();

        Task<Question> GetQuestion(Guid? id);

        Task<List<Question>> GetListQuestions(Guid id);

        //Task<List<CategoryQuestionModel>> GetAllQuestionCategories();
        Task<Question> AddQuestion(Question question);

        Task<bool> UpdateQuestion(Question question, Guid id);

        Task<bool> RemoveQuestion(Guid id);

        Task<List<Question>> GetQuestionsByName(string keyword);
    }
}