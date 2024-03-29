using Data.CustomModel.Position;
using Service.Models;

namespace Service.Interfaces
{
    public interface IPositionService
    {
        Task<List<PositionModel>> GetAllPositions(bool isAdmin, PositionFilter positionFilter, string sortString);
        
        Task<List<PositionModel>> GetAllPositionsByCurrentUser(String userId);

        Task<PositionAllMinMaxRange> GetAllMinMaxRange();

        Task<PositionModel> GetPositionById(Guid id);

        Task<List<PositionModel>> GetPositionByName(string name);

        Task<PositionModel> AddPosition(PositionModel position);

        Task<bool> UpdatePosition(PositionModel position, Guid positionId);

        Task<bool> RemovePosition(Guid positionId);
    }
}