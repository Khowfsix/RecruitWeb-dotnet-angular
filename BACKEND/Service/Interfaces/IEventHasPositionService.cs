using Service.Models;

namespace Service.Interfaces;

public interface IEventHasPositionService
{
    Task<EventHasPositionModel> SaveEventHasPosition(EventHasPositionModel viewModel);

    Task<bool> DeleteEventHasPosition(Guid EventHasPositionModelId);
}