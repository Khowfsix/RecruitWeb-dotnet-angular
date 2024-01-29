using Data.Entities;

using Api.ViewModels.QuestionSkill;

namespace Data.Interfaces
{
    public interface IQuestionSkillRepository : IRepository<QuestionSkill>
    {
        Task<List<QuestionSkillModel>> GetAllQuestionSkills();

        Task<QuestionSkillModel> AddQuestionSkill(QuestionSkillModel questionSkill);

        Task<bool> UpdateQuestionSkill(QuestionSkillModel questionSkill, Guid id);

        Task<bool> RemoveQuestionSkill(Guid id);
    }
}