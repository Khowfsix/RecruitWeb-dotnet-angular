
//using Api.ViewModels.Event;
using Api.ViewModels.Position;

namespace Api.ViewModels.EventHasPosition
{
    public class EventHasPositionAddModel
    {
        public Guid PositionId { get; set; }

        public Guid EventId { get; set; }
    }
}