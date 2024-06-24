namespace Service.Models
{
    public class InterviewModel
    {
        public Guid InterviewId { get; set; }

        public Guid InterviewerId { get; set; }

        public Guid RecruiterId { get; set; }

        public Guid ApplicationId { get; set; }

        public int? Company_Status { get; set; } 

        public int? Candidate_Status { get; set; } 

        public string? Notes { get; set; } 

        public int? Priority { get; set; } 

        public bool? IsDeleted { get; set; } = false;

        public Guid? ResultId { get; set; }
        public string? AddressOrStartURL { get; set; }
        public string? DetailLocationOrJoinURL { get; set; }
        public DateTime? MeetingDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public ApplicationModel Application { get; set; } 

        public InterviewerModel Interviewer { get; set; } 

        public RecruiterModel Recruiter { get; set; } = null!;

        public ResultModel Result { get; set; } 

        public ICollection<RoundModel> Rounds { get; set; } = new List<RoundModel>();
    }
}