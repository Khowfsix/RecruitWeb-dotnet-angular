namespace Api.ViewModels.Application
{
    public class ApplicationFilterModel
    {
        public string? Search { get; set; }
        public bool? NotInBlackList { get; set; } = false;
    }
}