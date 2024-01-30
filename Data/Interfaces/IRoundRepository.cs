using Data.Entities;

namespace Data.Interfaces
{
    public interface IRoundRepository : IRepository<Round>
    {
        Task<IEnumerable<Round>> GetAllRounds(string? request);
        Task<Round> SaveRound(Round request);
        Task<bool> UpdateRound(Round request, Guid requestId);
        Task<bool> DeleteRound(Guid requestId);
    }
}
