namespace Service.Models
{
    public class ContactEmailModel
    {

        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Datetime { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
    }
}