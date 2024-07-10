using Data.Entities;

namespace Data.Interfaces;

public interface IEventHasPositionRepository : IRepository<EventHasPosition>
{
    Task<IEnumerable<EventHasPosition>> GetAllEventHasPositions();
    Task<EventHasPosition> SaveEventHasPosition(EventHasPosition request);
    Task<bool> DeleteEventHasPosition(Guid requestId);
}