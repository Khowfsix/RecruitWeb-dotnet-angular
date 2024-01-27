using Data.Entities;
using Data.Models;
using Data.ViewModels.Room;

namespace Data.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<RoomModel>> GetAllRoom();
        Task<RoomModel> SaveRoom(RoomModel request);
        Task<bool> UpdateRoom(RoomModel request, Guid requestId);
        Task<bool> DeleteRoom(Guid requestId);
        Task<RoomModel> GetRoomById(Guid id);
    }
}
