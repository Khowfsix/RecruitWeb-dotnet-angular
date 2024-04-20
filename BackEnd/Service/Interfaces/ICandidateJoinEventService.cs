using Service.Models;

namespace Service.Interfaces
{
    public interface ICandidateJoinEventService
    {
        Task<IEnumerable<CandidateJoinEventModel>> GetAllCandidateJoinEventsByCandidateId(Guid candidateId, string sortString);

        Task<IEnumerable<CandidateJoinEventModel>> GetAllCandidateJoinEvents();

        Task<CandidateJoinEventModel> SaveCandidateJoinEvent(CandidateJoinEventModel request);

        Task<bool> UpdateCandidateJoinEvent(CandidateJoinEventModel request, Guid requestId);

        Task<bool> DeleteCandidateJoinEvent(Guid requestId);

        Task<IEnumerable<CandidateJoinEventModel>> JoinEventDetail(Guid id);

        Task<IEnumerable<CandidateJoinEventModel>> GetCandidatesSortedByJoinEventCount();
    }
}