using Service.Models;

namespace Service.Interfaces
{
    public interface ISuccessfulCandidateService
    {
        Task<IEnumerable<SuccessfulCadidateModel>> GetAllSuccessfulCadidates(string? request);

        Task<SuccessfulCadidateModel> SaveSuccessfulCadidate(SuccessfulCadidateModel request);

        Task<bool> UpdateSuccessfulCadidate(SuccessfulCadidateModel request, Guid requestId);

        Task<bool> DeleteSuccessfulCadidate(Guid requestId);
    }
}