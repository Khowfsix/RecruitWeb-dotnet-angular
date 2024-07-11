namespace Api.ViewModels.Report
{
    public class ReportAddModel
    {
        public string? ReportName { get; set; }
        public string UserId { get; set; }
        public int ReportType { get; set; }
        public string FileURL { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}