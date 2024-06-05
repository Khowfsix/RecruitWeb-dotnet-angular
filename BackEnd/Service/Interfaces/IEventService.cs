using Data.CustomModel.Event;
using Service.Models;

namespace Service.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventModel>> GetAllEvent();
    Task<IEnumerable<EventModel>> GetAllEventByRecruiterId(Guid recruiterId, EventFilter eventFilter, string sortString, bool isAdmin);

    Task<EventModel> GetEventById(Guid id);

    Task<EventModel> SaveEvent(EventModel viewModel);

    Task<bool> UpdateEvent(EventModel eventModel, Guid eventModelId);

    Task<bool> DeleteEvent(Guid eventModelId);
}