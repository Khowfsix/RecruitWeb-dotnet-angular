namespace Api.ViewModels
{
    public class WebUserViewModel
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; } = default!;

        public string ImageURL { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}