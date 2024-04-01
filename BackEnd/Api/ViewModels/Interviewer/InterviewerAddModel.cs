namespace Api.ViewModels.Interviewer
{
    public class InterviewerAddModel
    {
        public string UserId { get; set; }

        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}