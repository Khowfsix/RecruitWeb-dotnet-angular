namespace Api.ViewModels.Company
{
    public class CompanyViewModel
    {
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; } 

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Website { get; set; }

        public string? Logo { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsActived { get; set; }
    }
}