using Api.ViewModels.Position;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.CategoryPosition
{
    public class CategoryPositionViewModel
    {
        [Key]
        public Guid CategoryPositionId { get; set; }

        public string? CategoryPositionName { get; set; }

        public string? CategoryPositionDescription { get; set; }

        public virtual ICollection<PositionViewModel> Positions { get; set; } = new List<PositionViewModel>();
    }
}