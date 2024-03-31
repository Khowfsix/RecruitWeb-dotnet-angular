namespace Api.ViewModels.Interviewer
{
    public class InterviewerUpdateModel
    {
        public Guid InterviewerId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}