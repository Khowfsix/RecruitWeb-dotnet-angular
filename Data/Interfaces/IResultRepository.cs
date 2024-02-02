using Data.Entities;

namespace Data.Interfaces
{
    public interface IResultRepository : IRepository<Result>
    {
        Task<IEnumerable<Result>> GetAllResult();

        Task<Result> SaveResult(Result request);

        Task<bool> UpdateResult(Result request, Guid requestId);

        Task<bool> DeleteResult(Guid requestId);
    }
}