using Data.Entities;
using Data.Models;
using Data.ViewModels.QuestionSkill;

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