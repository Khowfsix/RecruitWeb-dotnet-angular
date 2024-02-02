namespace Service.Models
{
    public class ResultModel
    {
        public Guid ResultId { get; set; }

        public string? ResultString { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}