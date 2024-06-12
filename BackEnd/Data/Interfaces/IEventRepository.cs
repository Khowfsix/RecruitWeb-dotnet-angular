using Data.CustomModel.Event;
using Data.Entities;

namespace Data.Interfaces;

public interface IEventRepository : IRepository<Event>
{
    Task<IEnumerable<Event>> GetAllEvent();
    Task<IEnumerable<Event>> GetAllEventByRecruiterId(Guid recruiterId, EventFilter eventFilter, string sortString);

    Task<Event> GetEventById(Guid id);

    Task<Event> SaveEvent(Event request);

    Task<bool> UpdateEvent(Event request, Guid requestId);

    Task<bool> DeleteEvent(Guid requestId);
}