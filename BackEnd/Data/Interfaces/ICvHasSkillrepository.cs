using Data.Entities;

namespace Data.Interfaces
{
    public interface ICvHasSkillrepository
    {
        Task<IEnumerable<CvHasSkill>> GetAllCvHasSkillService(string? request);

        Task<CvHasSkill> SaveCvHasSkillService(CvHasSkill request);

        Task<bool> UpdateCvHasSkillService(CvHasSkill request, Guid requestId);

        Task<bool> DeleteCvHasSkillService(Guid requestId);

        Task<IList<Skill>> GetSkill(Guid Cvid);

        Task<IList<Cv>> GetCv(Guid skillId);

        Task<List<CvHasSkill>> GetAllSkillsFromOneCV(Guid Cvid);
    }
}