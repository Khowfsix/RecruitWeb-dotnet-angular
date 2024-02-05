namespace Api.ViewModels.Room
{
    public class RoomUpdateModel
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; } = null!;
    }
}