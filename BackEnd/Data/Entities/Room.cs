namespace Data.Entities;

public partial class Room
{
    public Guid RoomId { get; set; }

    public string RoomName { get; set; } 

    public bool? IsDeleted { get; set; } 

    public virtual ICollection<Itrsinterview> Itrsinterviews { get; set; } = new List<Itrsinterview>();
}