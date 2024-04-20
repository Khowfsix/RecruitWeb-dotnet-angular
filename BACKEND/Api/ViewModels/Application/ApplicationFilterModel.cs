namespace Api.ViewModels.Application
{
    public class ApplicationFilterModel
    {
        public string? Search { get; set; }
        public int? candidateStatus { get; set; }
        public int? companyStatus { get; set; }
        public bool? NotInBlackList { get; set; } = false;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}