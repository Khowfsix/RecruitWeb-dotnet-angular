using Service.Models;

namespace Service.Interfaces
{
    public interface IQuestionSkillService
    {
        Task<List<QuestionSkillModel>> GetAllQuestionSkills();

        Task<QuestionSkillModel> AddQuestionSkill(QuestionSkillModel questionSkill);

        Task<bool> UpdateQuestionSkill(QuestionSkillModel questionSkill, Guid id);

        Task<bool> RemoveQuestionSkill(Guid id);
    }
}