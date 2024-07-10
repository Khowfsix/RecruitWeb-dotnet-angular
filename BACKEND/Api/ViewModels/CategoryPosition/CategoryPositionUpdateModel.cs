using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.CategoryPosition
{
    public class CategoryPositionUpdateModel
    {
        public string? CategoryPositionName { get; set; }

        public string? CategoryPositionDescription { get; set; }
    }
}