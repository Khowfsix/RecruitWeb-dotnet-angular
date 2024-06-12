using Data.Entities;

namespace Data.Interfaces;

public interface IEventHasPositionRepository : IRepository<EventHasPosition>
{
    Task<EventHasPosition> SaveEventHasPosition(EventHasPosition request);
    Task<bool> DeleteEventHasPosition(Guid requestId);
}