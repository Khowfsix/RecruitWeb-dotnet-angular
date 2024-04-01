namespace Data.Entities;

public partial class CategoryPosition
{
    public Guid CategoryPositionId { get; set; }
    public string? CategoryPositionName { get; set; }
    public string? CategoryPositionDescription { get; set; }
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}