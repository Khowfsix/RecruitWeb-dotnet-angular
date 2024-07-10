using Api.ViewModels.Candidate;

namespace Api.ViewModels.AdminWorkExperience
{
    public partial class WorkExperienceViewModel
    {
        public Guid WorkExperienceId { get; set; }
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public DateTime? From { get; set; }
        public DateTime To { get; set; }
        public string? Description { get; set; }
        public string? Project { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateViewModel? Candidate { get; set; }
    }
}
