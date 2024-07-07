using Service.Models;

namespace Service.Interfaces
{
    public interface ICandidateHasSkillService
    {
        Task<IEnumerable<CandidateHasSkillModel>> GetAllByCandidateId(Guid? candidateId);
        Task<IEnumerable<CandidateHasSkillModel>> GetAll();
    }
}