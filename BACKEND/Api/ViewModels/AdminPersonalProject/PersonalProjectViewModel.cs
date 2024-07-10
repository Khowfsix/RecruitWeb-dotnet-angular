using Api.ViewModels.Candidate;

namespace Api.ViewModels.AdminPersonalProject
{
    public partial class PersonalProjectViewModel
    {
        public Guid PersonalProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? From { get; set; }
        public DateTime To { get; set; }
        public string? ShortDescription { get; set; }
        public string? ProjectUrl { get; set; }
        public Guid CandidateId { get; set; }
        public virtual CandidateViewModel? Candidate { get; set; }
    }
}
