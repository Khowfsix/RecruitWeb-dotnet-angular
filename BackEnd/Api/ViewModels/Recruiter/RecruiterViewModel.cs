using Api.ViewModels.Company;

namespace Api.ViewModels.Recruiter
{
    public class RecruiterViewModel
    {
        public Guid RecruiterId { get; set; }
        public string UserId { get; set; } = null!;
        public Guid CompanyId { get; set; }
        public virtual CompanyViewModel? Company { get; set; }
        public virtual WebUserViewModel? User { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}