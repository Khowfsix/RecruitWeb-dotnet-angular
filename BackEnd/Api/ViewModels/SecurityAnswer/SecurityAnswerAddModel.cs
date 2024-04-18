namespace Api.ViewModels.SecurityAnswer
{
    public class SecurityAnswerAddModel
    {
        public string AnswerString { get; set; } 

        public Guid SecurityQuestionId { get; set; }

        public string WebUserId { get; set; }
    }
}