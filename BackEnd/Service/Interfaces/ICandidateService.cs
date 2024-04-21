using Service.Models;

namespace Service.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateModel>> GetAllCandidates();

        Task<CandidateModel> SaveCandidate(CandidateModel request);

        Task<bool> UpdateCandidate(CandidateModel request, Guid requestId);

        Task<bool> DeleteCandidate(Guid requestId);

        Task<ProfileModel?> GetProfile(Guid candidateId);

        Task<CandidateModel> FindById(Guid id, bool isAdmin);

        Task<CandidateModel> GetCandidateByUserId(string id);
    }
}