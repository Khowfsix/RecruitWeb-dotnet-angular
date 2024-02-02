namespace Service.Models
{
    public class SecurityQuestionModel
    {
        public Guid SecurityQuestionId { get; set; }
        public string QuestionString { get; set; } = null!;
    }
}