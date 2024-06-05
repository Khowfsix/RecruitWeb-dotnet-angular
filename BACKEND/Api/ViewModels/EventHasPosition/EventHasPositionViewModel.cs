
//using Api.ViewModels.Event;
using Api.ViewModels.Position;

namespace Api.ViewModels.EventHasPosition
{
    public class EventHasPositionViewModel
    {
        public Guid EventHasPositionId { get; set; }

        public Guid PositionId { get; set; }

        public Guid EventId { get; set; }

        public virtual PositionViewModel Position { get; set; }

        //public virtual EventViewModel Event { get; set; }
    }
}