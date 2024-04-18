namespace Service.Models;

public class ItrsinterviewModel
{
    public Guid ItrsinterviewId { get; set; }

    public DateTime DateInterview { get; set; }

    public Guid ShiftId { get; set; }

    public Guid RoomId { get; set; }

    public virtual RoomModel Room { get; set; } 

    public virtual ShiftModel Shift { get; set; } 
}