
using Api.ViewModels.Application;
using Api.ViewModels.Interviewer;
using Api.ViewModels.Itrsinterview;
using Api.ViewModels.Recruiter;
using Api.ViewModels.Round;

namespace Api.ViewModels.Interview
{
    public class InterviewViewModel
    {
        public Guid InterviewId { get; set; }
        //public Guid RecruiterId { get; set; }
        //public Guid InterviewerId { get; set; }

        //public Guid ApplicationId { get; set; }

        //public Guid? ItrsinterviewId { get; set; }

        public string? Company_Status { get; set; }
        public string? Candidate_Status { get; set; }

        public string? Notes { get; set; }
        public string? Priority { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ApplicationViewModel Application { get; set; } = null!;

        public virtual InterviewerViewModel Interviewer { get; set; } = null!;

        public virtual ItrsinterviewViewModel? Itrsinterview { get; set; }

        public virtual RecruiterViewModel Recruiter { get; set; } = null!;

        public ICollection<RoundViewModel> Rounds { get; set; } = new List<RoundViewModel>();
    }
}