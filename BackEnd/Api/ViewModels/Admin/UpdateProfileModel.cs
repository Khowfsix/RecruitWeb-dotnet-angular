namespace Api.ViewModels.Admin
{
    public class UpdateProfileModel
    {
        public string? Fullname { get; set; }
        public string? Title { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PersonalLink { get; set; }
        public DateTime Dob { get; set; }
        public string? Gender { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? imgUrl { get; set; }
    }
}