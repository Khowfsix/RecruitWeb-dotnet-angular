namespace Service.Models
{
    public class CategoryQuestionModel
    {
        public Guid CategoryQuestionId { get; set; }

        public string? CategoryQuestionName { get; set; }

        public double Weight { get; set; }
    }
}