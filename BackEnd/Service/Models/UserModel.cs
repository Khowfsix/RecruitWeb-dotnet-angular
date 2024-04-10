namespace Service.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Guid? CandidateId { get; set; }
        public Guid? InterviewerId { get; set; }
        public Guid? RecruiterId { get; set; }
        public Guid? CompanyId { get; set; }
    }
}