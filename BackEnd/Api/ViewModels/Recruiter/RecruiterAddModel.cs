namespace Api.ViewModels.Recruiter
{
    public class RecruiterAddModel
    {
        public string UserId { get; set; }

        public Guid CompanyId { get; set; }

        public bool? IsDeleted { get; set; } = false;
        public bool? IsActived { get; set; } = false;
    }
}