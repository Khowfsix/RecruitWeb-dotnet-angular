using Data.Entities;

namespace Data.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllCandidates();

        Task<Candidate> SaveCandidate(Candidate request);

        Task<bool> UpdateCandidate(Candidate request, Guid requestId);

        Task<bool> DeleteCandidate(Guid requestId);

        Task<Candidate?> GetCandidateByUserId(string userId);

        // candidate map to profile
        Task<Candidate?> GetProfile(Guid candidateId);

        Task<Candidate> FindById(Guid id);
    }
}