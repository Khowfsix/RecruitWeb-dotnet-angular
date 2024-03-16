using Data.Entities;

namespace Data.Interfaces
{
    public interface ISkillRepository : IRepository<Skill>
    {
        Task<Skill?> GetSkillById(Guid id);
        Task<IEnumerable<Skill>> GetAllSkills(string? request);

        Task<Skill> SaveSkill(Skill request);

        Task<bool> UpdateSkill(Skill request, Guid requestId);

        Task<bool> DeleteSkill(Guid requestId);
    }
}