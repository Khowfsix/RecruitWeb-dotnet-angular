using Api.ViewModels.Language;

namespace Service.Interfaces
{
    public interface ILanguageService
    {
        Task<LanguageViewModel> AddLanguage(LanguageAddModel createdLanguage);

        Task<bool> UpdateLanguage(LanguageUpdateModel createdLanguage, Guid id);

        Task<bool> RemoveLanguage(Guid id);

        Task<List<LanguageViewModel>> GetAllLanguages();

        Task<LanguageViewModel> GetLanguage(Guid id);

        Task<List<LanguageViewModel>> GetLanguage(string name);

        //Task<bool> LanguageExists(Guid id);
    }
}