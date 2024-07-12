using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Company
{
    public class CompanyUpdateModel
    {
        [Key]
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; } 

        public string? Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [DataType(DataType.Url)]
        public string? Website { get; set; }

        public string? Logo { get; set; }

        public bool? IsDeleted { get; set; } = false;

        public bool? IsActived { get; set; } = false;
    }
}