namespace Api.ViewModels.SecurityQuestion
{
    public class SecurityQuestionUpdateModel
    {
        public Guid SecurityQuestionId { get; set; }
        public string QuestionString { get; set; } = null!;
    }
}