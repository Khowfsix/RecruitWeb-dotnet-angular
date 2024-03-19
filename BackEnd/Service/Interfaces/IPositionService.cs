using Data.Entities;
using Data.Paging;
using Service.Models;

namespace Service.Interfaces
{
    public interface IPositionService
    {
        Task<PageResponse<PositionModel>> GetAllPositions(bool isAdmin, PositionFilter positionFilter, string sortString, PageRequest pageRequest);
        Task<List<PositionModel>> GetAllPositionsByCurrentUser(String userId);

        Task<PositionModel> GetPositionById(Guid id);

        Task<List<PositionModel>> GetPositionByName(string name);

        Task<PositionModel> AddPosition(PositionModel position);

        Task<bool> UpdatePosition(PositionModel position, Guid positionId);

        Task<bool> RemovePosition(Guid positionId);
    }
}