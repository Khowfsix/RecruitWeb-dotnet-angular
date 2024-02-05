namespace Api.ViewModels.SecurityAnswer
{
    public class SecurityAnswerViewModel
    {
        public Guid SecurityAnswerId { get; set; }

        public string AnswerString { get; set; } = null!;

        public Guid SecurityQuestionId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string WebUserId { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}