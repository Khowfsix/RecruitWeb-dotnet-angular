using Data.Entities;

namespace Data.Interfaces
{
    public interface ICandidateHasSkillrepository
    {
        Task<IEnumerable<CandidateHasSkill>> GetAllByCandidateId(Guid? candidateId);
    }
}