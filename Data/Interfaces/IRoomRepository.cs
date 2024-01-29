using Data.Entities;

using Api.ViewModels.Room;

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
