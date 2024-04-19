using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Language
{
    public class LanguageViewModel
    {
        [Key]
        public Guid LanguageId { get; set; }

        public string LanguageName { get; set; } 

        public bool IsDeleted { get; set; } = false;
    }
}