

using Data.Entities;

namespace Data.Interfaces;

public interface IBlacklistRepository
{
    Task<IEnumerable<BlackList>> GetAllBlackLists();

    Task<BlackList> SaveBlackList(BlackList request);

    Task<bool> UpdateBlackList(BlackList request, Guid requestId);

    Task<bool> DeleteBlackList(Guid requestId);

    Task<bool> CheckIsInBlackList(Guid candidateId);
}