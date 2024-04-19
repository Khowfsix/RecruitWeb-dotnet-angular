namespace Data.Entities;

public partial class Interview
{
    public Guid InterviewId { get; set; }
    public Guid InterviewerId { get; set; }
    public Guid RecruiterId { get; set; }
    public Guid ApplicationId { get; set; }

    public int? Company_Status { get; set; }

    public int? Candidate_Status { get; set; }


    public string? Address { get; set; }
    public string? DetailLocation { get; set; }
    public DateTime? MeetingDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }


    public int? Priority { get; set; }

    //public Guid? ResultId { get; set; }

    public string? Notes { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Application Application { get; set; }

    public virtual Interviewer Interviewer { get; set; }

    public virtual Recruiter Recruiter { get; set; }

    //public virtual Result Result { get; set; } 

    public virtual ICollection<Round> Rounds { get; set; } = new List<Round>();
}