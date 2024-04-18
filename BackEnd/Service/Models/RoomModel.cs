namespace Service.Models
{
    public class RoomModel
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; } 
        public bool? IsDeleted { get; set; } 
    }
}