namespace Api.ViewModels.Recruiter
{
    public class RecruiterAddModel
    {
        public string UserId { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}