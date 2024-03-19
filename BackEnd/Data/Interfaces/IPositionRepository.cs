using Data.Entities;
using Data.Paging;

namespace Data.Interfaces
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<PageResponse<Position>> GetAllPositions(bool isAdmin, PositionFilter positionFilter, string sortString, PageRequest pageRequest);

        Task<List<Position>> GetAllPositionsByUserId(String userId);

        Task<Position?> GetPositionById(Guid id);

        Task<List<Position>> GetPositionByName(string name);

        Task<Position> AddPosition(Position position);

        Task<bool> UpdatePosition(Position position, Guid positionId);

        Task<bool> RemovePosition(Guid positionId);
    }
}