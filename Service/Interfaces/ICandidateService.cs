using Data.ViewModels.Candidate;

namespace Service.Interfaces
{
    public interface ICandidateService
    {
        Task<IEnumerable<CandidateViewModel>> GetAllCandidates();

        Task<CandidateViewModel> SaveCandidate(CandidateAddModel request);

        Task<bool> UpdateCandidate(CandidateUpdateModel request, Guid requestId);

        Task<bool> DeleteCandidate(Guid requestId);

        Task<ProfileViewModel?> GetProfile(Guid candidateId);

        Task<CandidateViewModel> FindById(Guid id);

        Task<CandidateViewModel> GetCandidateByUserId(string id);
    }
}