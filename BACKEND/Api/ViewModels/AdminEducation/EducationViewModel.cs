using Api.ViewModels.Candidate;

namespace Api.ViewModels.AdminEducation
{
    public partial class EducationViewModel
    {
        public Guid EducationId { get; set; }
        public string? School { get; set; }
        public string? Major { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public string? AdditionalDetails { get; set; }
        public Guid? CandidateId { get; set; }
        public virtual CandidateViewModel? Candidate { get; set; }
    }
}

