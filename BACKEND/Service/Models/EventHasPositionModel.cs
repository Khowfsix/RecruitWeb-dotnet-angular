
namespace Service.Models
{
    public class EventHasPositionModel
    {
        public Guid EventHasPositionId { get; set; }

        public Guid PositionId { get; set; }

        public Guid EventId { get; set; }

        public virtual PositionModel Position { get; set; }

        //public virtual EventViewModel Event { get; set; }
    }
}