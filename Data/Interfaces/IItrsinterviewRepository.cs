using Data.Entities;

namespace Data.Interfaces;

public interface IItrsinterviewRepository : IRepository<Itrsinterview>
{
    Task<IEnumerable<Itrsinterview>> GetAllItrsinterview();
    Task<IEnumerable<Itrsinterview>> GetAllItrsinterview_NoInclude();
    Task<Itrsinterview?> GetItrsinterviewById(Guid id);
    Task<Itrsinterview?> SaveItrsinterview(Itrsinterview request, Guid interviewerId);
    Task<bool> UpdateItrsinterview(Itrsinterview request, Guid requestId);
    Task<bool> DeleteItrsinterview(Guid requestId);
}