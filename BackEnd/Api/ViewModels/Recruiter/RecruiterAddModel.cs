namespace Api.ViewModels.Recruiter
{
    public class RecruiterAddModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string UserId { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Guid DepartmentId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}