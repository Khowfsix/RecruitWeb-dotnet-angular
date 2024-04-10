namespace Data.Entities
{
    public class SecurityAnswerModel
    {
        public Guid SecurityAnswerId { get; set; }

        public string AnswerString { get; set; } = null!;

        public Guid SecurityQuestionId { get; set; }

        public string WebUserId { get; set; }
    }
}