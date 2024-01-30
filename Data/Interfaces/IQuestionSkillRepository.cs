using Data.Entities;

namespace Data.Interfaces
{
    public interface IQuestionSkillRepository : IRepository<QuestionSkill>
    {
        Task<List<QuestionSkill>> GetAllQuestionSkills();

        Task<QuestionSkill> AddQuestionSkill(QuestionSkill questionSkill);

        Task<bool> UpdateQuestionSkill(QuestionSkill questionSkill, Guid id);

        Task<bool> RemoveQuestionSkill(Guid id);
    }
}