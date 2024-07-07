namespace Api.ViewModels.CategoryPosition
{
    public class CategoryPositionAddModel
    {
        public string CategoryPositionName { get; set; }

        public string? CategoryPositionDescription { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}