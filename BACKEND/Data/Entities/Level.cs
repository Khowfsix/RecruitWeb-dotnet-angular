using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public partial class Level
{
    public Guid LevelId { get; set; }
    public string LevelName { get; set; } 
    public bool IsDeleted { get; set; }
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}