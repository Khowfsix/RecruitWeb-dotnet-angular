namespace Api.ViewModels.Interview
{
    public class InterviewAddModel
    {
        public Guid InterviewerId { get; set; }
        public Guid RecruiterId { get; set; }
        public Guid ApplicationId { get; set; }
        public int? Priority { get; set; }
        public string? Notes { get; set; }
        public string? AddressOrStartURL{ get; set; }
        public string? DetailLocationOrJoinURL { get; set; }
        public DateTime MeetingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int InterviewType { get; set; }
    }
}