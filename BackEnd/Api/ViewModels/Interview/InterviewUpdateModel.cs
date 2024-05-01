namespace Api.ViewModels.Interview
{
    public class InterviewUpdateModel
    {
        public Guid InterviewerId { get; set; }
        public Guid RecruiterId { get; set; }
        public int? Priority { get; set; }
        public string? Notes { get; set; }
        public string Address { get; set; }
        public string DetailLocation { get; set; }
        public DateTime MeetingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}