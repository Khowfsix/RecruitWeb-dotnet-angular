using Service.Models;

namespace Service.Interfaces
{
    public interface ILanguageService
    {
        Task<LanguageModel> AddLanguage(LanguageModel createdLanguage);

        Task<bool> UpdateLanguage(LanguageModel createdLanguage, Guid id);

        Task<bool> RemoveLanguage(Guid id);

        Task<List<LanguageModel>> GetAllLanguages(bool isAdmin);

        Task<LanguageModel> GetLanguage(Guid id);

        Task<List<LanguageModel>> GetLanguage(bool isAdmin, string name);
    }
}