using Data.Entities;

namespace Data.Interfaces
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAllRoom();

        Task<Room> SaveRoom(Room request);

        Task<bool> UpdateRoom(Room request, Guid requestId);

        Task<bool> DeleteRoom(Guid requestId);

        Task<Room> GetRoomById(Guid id);
    }
}