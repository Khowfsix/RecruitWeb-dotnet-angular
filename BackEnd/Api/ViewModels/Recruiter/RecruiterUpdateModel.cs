namespace Api.ViewModels.Recruiter
{
    public class RecruiterUpdateModel
    {
        public Guid RecruiterId { get; set; }

        public string UserId { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}