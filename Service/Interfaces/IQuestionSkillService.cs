using Api.ViewModels.QuestionSkill;

namespace Service.Interfaces
{
    public interface IQuestionSkillService
    {
        Task<List<QuestionSkillViewModel>> GetAllQuestionSkills();

        Task<QuestionSkillViewModel> AddQuestionSkill(QuestionSkillAddModel questionSkill);

        Task<bool> UpdateQuestionSkill(QuestionSkillUpdateModel questionSkill, Guid id);

        Task<bool> RemoveQuestionSkill(Guid id);
    }
}