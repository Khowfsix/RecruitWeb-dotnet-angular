using Data.Entities;

namespace Data.Interfaces
{
    public interface ISuccessfulCadidateRepository : IRepository<SuccessfulCadidate>
    {
        Task<IEnumerable<SuccessfulCadidate>> GetAllSuccessfulCadidates(string? request);

        Task<SuccessfulCadidate> SaveSuccessfulCadidate(SuccessfulCadidate request);

        Task<bool> UpdateSuccessfulCadidate(SuccessfulCadidate request, Guid requestId);

        Task<bool> DeleteSuccessfulCadidate(Guid requestId);
    }
}