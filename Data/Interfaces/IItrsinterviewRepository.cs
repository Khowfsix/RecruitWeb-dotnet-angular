using Data.Entities;
using Data.Models;
using Data.ViewModels.Itrsinterview;

namespace Data.Interfaces;

public interface IItrsinterviewRepository : IRepository<Itrsinterview>
{
    Task<IEnumerable<ItrsinterviewModel>> GetAllItrsinterview();
    Task<IEnumerable<ItrsinterviewModel>> GetAllItrsinterview_NoInclude();
    Task<ItrsinterviewModel?> GetItrsinterviewById(Guid id);
    Task<ItrsinterviewModel?> SaveItrsinterview(ItrsinterviewModel request, Guid interviewerId);
    Task<bool> UpdateItrsinterview(ItrsinterviewModel request, Guid requestId);
    Task<bool> DeleteItrsinterview(Guid requestId);
}