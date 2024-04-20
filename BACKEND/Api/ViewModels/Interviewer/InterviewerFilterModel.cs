namespace Api.ViewModels.Interviewer
{
    public class InterviewerFilterModel
    {
        public string? Search { get; set; }
        public bool? IsFreeTime { get; set; } = false;
        public bool? IsBusyTime { get; set; } = false;
        public string? FromTime { get; set; }
        public string? ToTime { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}