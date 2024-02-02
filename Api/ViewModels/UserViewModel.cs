namespace Api.ViewModels
{
    public class UserViewModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Id { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid? CandidateId { get; set; }
        public Guid? InterviewerId { get; set; }
        public Guid? RecruiterId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}