namespace Api.ViewModels.SecurityAnswer
{
    public class SecurityAnswerViewModel
    {
        public Guid SecurityAnswerId { get; set; }

        public string AnswerString { get; set; } 

        public Guid SecurityQuestionId { get; set; }

        public string WebUserId { get; set; }
    }
}