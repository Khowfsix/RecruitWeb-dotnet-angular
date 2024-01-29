
using Api.ViewModels.Skill;

namespace Service.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillViewModel>> GetAllSkills(string? request);

        Task<SkillViewModel> SaveSkill(SkillAddModel request);

        Task<bool> UpdateSkill(SkillUpdateModel request, Guid requestId);

        Task<bool> DeleteSkill(Guid requestId);
    }
}