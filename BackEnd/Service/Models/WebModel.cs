namespace Service.Models
{
    public class WebUserModel
    {
        public string Id { get; set; }

        public string? FullName { get; set; }
        public string? Title { get; set; }
        public string? PersonalLink { get; set; }
        public string? Gender { get; set; }


        public DateTime? DateOfBirth { get; set; }

        public string? City { get; set; }
        public string? Address { get; set; }
        public string? ImageURL { get; set; } = null;
    }
}