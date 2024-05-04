using Data.CustomModel.Position;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<List<Position>> GetAllPositions(PositionFilter positionFilter,
            string sortString);
        Task<List<Position>> GetAllByRecruiterId(Guid recruiterId);

        Task<List<Position>> GetAllPositionsByUserId(String userId);

        Task<Position?> GetPositionById(Guid id);
        
        Task<PositionAllMinMaxRange> GetAllMinMaxRange();

        Task<List<Position>> GetPositionByName(string name);

        Task<Position> AddPosition(Position position);

        Task<bool> UpdatePosition(Position position, Guid positionId);

        Task<bool> RemovePosition(Guid positionId);
    }
}