namespace Api.ViewModels.Report
{
    public class InterviewReportViewModel
    {
        public Guid InterviewId { get; set; }
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; }
        public Guid InterviewerId { get; set; }
        public string InterviewerName { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Status { get; set; }
        public double? Score { get; set; } = 0;
    }
}