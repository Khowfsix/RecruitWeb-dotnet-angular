using Data.Entities;


namespace Data.Interfaces
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<List<PositionModel>> GetAllPositions();

        Task<PositionModel> GetPositionById(Guid id);

        Task<List<PositionModel>> GetPositionByName(string name);

        Task<PositionModel> AddPosition(PositionModel position);

        Task<bool> UpdatePosition(PositionModel position, Guid positionId);

        Task<bool> RemovePosition(Guid positionId);
    }
}