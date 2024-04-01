namespace Service.Models
{
    public class CategoryPositionModel
    {
        public Guid CategoryPositionId { get; set; }

        public string? CategoryPositionName { get; set; }

        public string? CategoryPositionDescription { get; set; }

        public virtual ICollection<PositionModel> Positions { get; set; } = new List<PositionModel>();
    }
}