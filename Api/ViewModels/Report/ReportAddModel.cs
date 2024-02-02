namespace Api.ViewModels.Report
{
    public class ReportAddModel
    {
        public string? ReportName { get; set; }

        public Guid RecruiterId { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}