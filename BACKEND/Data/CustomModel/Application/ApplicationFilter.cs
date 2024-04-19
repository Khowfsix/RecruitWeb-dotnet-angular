namespace Data.CustomModel.Application
{
    public class ApplicationFilter
    {
        public string? Search { get; set; }
        public int? candidateStatus { get; set; }
        public int? companyStatus { get; set; }
        public bool? NotInBlackList { get; set; } = false;
    }
}