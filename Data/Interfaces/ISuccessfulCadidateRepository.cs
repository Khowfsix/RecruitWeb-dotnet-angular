using Data.Entities;

using Api.ViewModels.SuccessfulCadidate;
using System.Data.SqlTypes;

namespace Data.Interfaces
{
    public interface ISuccessfulCadidateRepository : IRepository<SuccessfulCadidate>
    {
        Task<IEnumerable<SuccessfulCadidateModel>> GetAllSuccessfulCadidates(string? request);
        Task<SuccessfulCadidateModel> SaveSuccessfulCadidate(SuccessfulCadidateModel request);
        Task<bool> UpdateSuccessfulCadidate(SuccessfulCadidateModel request, Guid requestId);
        Task<bool> DeleteSuccessfulCadidate(Guid requestId);
    }
}
