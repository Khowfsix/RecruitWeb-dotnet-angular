using Api.ViewModels.Candidate;
using Api.ViewModels.Interviewer;
using Api.ViewModels.Recruiter;

namespace Api.ViewModels
{
    public class WebUserViewModel
    {
        public string Id { get; set; }

        public string? FullName { get; set; }
        public string? Title { get; set; }
        public string? PersonalLink { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; } = null;

        public virtual ICollection<CandidateViewModel> Candidates { get; set; }
        public virtual ICollection<InterviewerViewModel> Interviewers { get; set; }
        public virtual ICollection<RecruiterViewModel> Recruiters { get; set; }

    }
}