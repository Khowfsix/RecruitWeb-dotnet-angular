using Service.Models;

namespace Service.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomModel>> GetAllRoom();

        Task<RoomModel> SaveRoom(RoomModel viewModel);

        Task<bool> UpdateRoom(RoomModel reportModel, Guid reportModelId);

        Task<bool> DeleteRoom(Guid reportModelId);
    }
}