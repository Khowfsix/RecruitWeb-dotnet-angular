using Data.ViewModels.Position;

namespace Service.Interfaces
{
    public interface IPositionService
    {
        Task<List<PositionViewModel>> GetAllPositions(Guid? departmentId);

        Task<PositionViewModel> GetPositionById(Guid id);

        Task<List<PositionViewModel>> GetPositionByName(string name);

        Task<PositionViewModel> AddPosition(PositionAddModel position);

        Task<bool> UpdatePosition(PositionUpdateModel position, Guid positionId);

        Task<bool> RemovePosition(Guid positionId);
    }
}