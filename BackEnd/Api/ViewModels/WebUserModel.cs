using Api.ViewModels.Candidate;
using Api.ViewModels.Interviewer;
using Api.ViewModels.Recruiter;

namespace Api.ViewModels
{
    public class WebUserViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; } = default!;

        public string ImageURL { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<CandidateViewModel> Candidates { get; set; }
        public virtual ICollection<InterviewerViewModel> Interviewers { get; set; }
        public virtual ICollection<RecruiterViewModel> Recruiters { get; set; }

    }
}