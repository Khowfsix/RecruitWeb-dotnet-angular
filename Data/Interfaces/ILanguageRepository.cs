using Data.Entities;
using Microsoft.Identity.Client;
using Data.Models;
using Data.ViewModels.Language;

namespace Data.Interfaces
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<LanguageModel> AddLanguage(LanguageModel createdLanguage);
        Task<bool> UpdateLanguage(LanguageModel createdLanguage, Guid id);
        Task<bool> RemoveLanguage(Guid id);
        Task<List<LanguageModel>> GetAllLanguages();
        Task<LanguageModel> GetLanguage(Guid id);
        Task<List<LanguageModel>> GetLanguage(string name);
        //Task<bool> LanguageExists(Guid id);
    }
}