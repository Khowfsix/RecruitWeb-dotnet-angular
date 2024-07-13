using Api.ViewModels.Company;

namespace Api.ViewModels.Interviewer
{
    public class InterviewerViewModel
    {
        public Guid InterviewerId { get; set; }

        public string UserId { get; set; }

        public Guid CompanyId { get; set; }
        public virtual CompanyViewModel Company { get; set; }

        public WebUserViewModel User { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int? daysToLastInterview { get; set; } = null;
    }
}