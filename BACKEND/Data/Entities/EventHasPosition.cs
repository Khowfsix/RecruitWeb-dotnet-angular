namespace Data.Entities;

public partial class EventHasPosition
{
    public Guid EventHasPositionId { get; set; }

    public Guid PositionId { get; set; }

    public Guid EventId { get; set; }

    public virtual Position Position { get; set; }

    public virtual Event Event { get; set; }
}