namespace Service.Models
{
    public class RoundModel
    {
        public Guid RoundId { get; set; }

        public Guid InterviewId { get; set; }

        public Guid QuestionId { get; set; }

        public virtual QuestionModel Question { get; set; } 

        public double? Score { get; set; } 
    }
}