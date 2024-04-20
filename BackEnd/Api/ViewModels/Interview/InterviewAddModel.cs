namespace Api.ViewModels.Interview
{
    public class InterviewAddModel
    {
        public Guid InterviewerId { get; set; }

        public Guid RecruiterId { get; set; }

        public Guid ApplicationId { get; set; }

        public string? Notes { get; set; }

        public Guid? ResultId { get; set; }
    }
}