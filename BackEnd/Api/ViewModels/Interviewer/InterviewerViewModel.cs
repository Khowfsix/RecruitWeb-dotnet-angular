namespace Api.ViewModels.Interviewer
{
    public class InterviewerViewModel
    {
        public Guid InterviewerId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }

        public WebUserViewModel User { get; set; } = new();

        public bool IsDeleted { get; set; } = false;
    }
}