using Service.Models;

namespace Service.Interfaces
{
    public interface ISkillService
    {
        Task<SkillModel> GetSkillById(Guid id);

        Task<IEnumerable<SkillModel>> GetAllSkills(bool isAdmin, string? request);

        Task<SkillModel> SaveSkill(SkillModel request);

        Task<bool> UpdateSkill(SkillModel request, Guid requestId);

        Task<bool> DeleteSkill(Guid requestId);
    }
}