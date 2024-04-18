using Api.ViewModels.Room;
using Api.ViewModels.Shift;

namespace Api.ViewModels.Itrsinterview;

public class ItrsinterviewViewModel
{
    public Guid ItrsinterviewId { get; set; }
    public DateTime DateInterview { get; set; }

    //public Guid ShiftId { get; set; }

    //public Guid RoomId { get; set; }

    public virtual RoomViewModel Room { get; set; } 

    public virtual ShiftViewModel Shift { get; set; } 
}