namespace Data.CustomModel.Application
{
    public class ApplicationFilter
    {
        public string? Search { get; set; }
        public bool? NotInBlackList { get; set; } = false;
    }
}