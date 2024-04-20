using Data.Entities;

namespace Data.Interfaces
{
    public interface ICandidateJoinEventRepository
    {
        Task<IEnumerable<CandidateJoinEvent>> GetAllCandidateJoinEventsByCandidateId(Guid candidateId, string sortString);

        Task<IEnumerable<CandidateJoinEvent>> GetAllCandidateJoinEvents();

        Task<CandidateJoinEvent> SaveCandidateJoinEvent(CandidateJoinEvent request);

        Task<bool> UpdateCandidateJoinEvent(CandidateJoinEvent request, Guid requestId);

        Task<bool> DeleteCandidateJoinEvent(Guid requestId);

        Task<IEnumerable<CandidateJoinEvent>> JoinEventDetail(Guid id);

        Task<IEnumerable<CandidateJoinEvent>> GetCandidatesSortedByJoinEventCount();
    }
}