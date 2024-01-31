using Service.Models;

namespace Service.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillModel>> GetAllSkills(string? request);

        Task<SkillModel> SaveSkill(SkillModel request);

        Task<bool> UpdateSkill(SkillModel request, Guid requestId);

        Task<bool> DeleteSkill(Guid requestId);
    }
}