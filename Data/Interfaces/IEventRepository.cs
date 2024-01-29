using Data.Entities;


namespace Data.Interfaces;

public interface IEventRepository : IRepository<Event>
{
    Task<IEnumerable<EventModel>> GetAllEvent();

    Task<EventModel> GetEventById(Guid id);

    Task<EventModel> SaveEvent(EventModel request);

    Task<bool> UpdateEvent(EventModel request, Guid requestId);

    Task<bool> DeleteEvent(Guid requestId);
}