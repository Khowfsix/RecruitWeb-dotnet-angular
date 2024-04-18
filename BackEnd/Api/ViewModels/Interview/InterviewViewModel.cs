using Api.ViewModels.Application;
using Api.ViewModels.Interviewer;
using Api.ViewModels.Recruiter;
using Api.ViewModels.Result;
using Api.ViewModels.Round;

namespace Api.ViewModels.Interview
{
    public class InterviewViewModel
    {
        public Guid InterviewId { get; set; }

        public Guid InterviewerId { get; set; }

        public Guid RecruiterId { get; set; }

        public Guid ApplicationId { get; set; }

        public string? Company_Status { get; set; } = "Pending";

        public string? Candidate_Status { get; set; } = "Not start";

        public string? Notes { get; set; } = null!;

        public string? Priority { get; set; } = null!;

        public bool? IsDeleted { get; set; } = false;

        public Guid? ResultId { get; set; }
        public string? Address { get; set; }
        public string? DetailLocation { get; set; }
        public DateTime? MeetingDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public ApplicationViewModel Application { get; set; } = null!;

        public InterviewerViewModel Interviewer { get; set; } = null!;

        public RecruiterViewModel Recruiter { get; set; } = null!;

        public ResultViewModel Result { get; set; } = null!;

        public ICollection<RoundViewModel> Rounds { get; set; } = new List<RoundViewModel>();
    }
}