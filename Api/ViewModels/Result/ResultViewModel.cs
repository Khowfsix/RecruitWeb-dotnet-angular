namespace Api.ViewModels.Result
{
    public class ResultViewModel
    {
        public Guid ResultId { get; set; }
        public string? ResultString { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}