using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.CategoryPosition
{
    public class CategoryPositionAddModel
    {
        [Key]
        public Guid CategoryPositionId { get; set; }

        public string? CategoryPositionName { get; set; }

        public string? CategoryPositionDescription { get; set; }
    }
}