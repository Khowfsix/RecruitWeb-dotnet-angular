using Data.Entities;

using Api.ViewModels.Recruiter;

namespace Data.Interfaces;

public interface IRecruiterRepository : IRepository<Recruiter>
{
    Task<IEnumerable<RecruiterModel>> GetAllRecruiter();
    Task<RecruiterModel?> GetRecruiterById(Guid id);
    Task<RecruiterModel?> SaveRecruiter(RecruiterModel request);
    Task<bool> UpdateRecruiter(RecruiterModel request, Guid requestId);
    Task<bool> DeleteRecruiter(Guid requestId);
}