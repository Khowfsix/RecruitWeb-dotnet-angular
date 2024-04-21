using Service.Models;

namespace Service.Interfaces
{
    public interface IBlacklistService
    {
        Task<IEnumerable<BlacklistModel>> GetAllBlackLists(bool isAdmin);

        Task<BlacklistModel> SaveBlackList(BlacklistModel request);

        Task<bool> UpdateBlackList(BlacklistModel request, Guid requestId);

        Task<bool> DeleteBlackList(Guid requestId);
    }
}