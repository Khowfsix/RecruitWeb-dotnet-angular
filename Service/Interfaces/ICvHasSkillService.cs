using Service.Models;

namespace Service.Interfaces
{
    public interface ICvHasSkillService
    {
        Task<IEnumerable<CvHasSkillModel>> GetAllCvHasSkillService(string? request);

        Task<CvHasSkillModel> SaveCvHasSkillService(CvHasSkillModel request);

        Task<bool> UpdateCvHasSkillService(CvHasSkillModel request, Guid requestId);

        Task<bool> DeleteCvHasSkillService(Guid requestId);
    }
}