using Data.Entities;

namespace Data.Interfaces
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<Language> AddLanguage(Language createdLanguage);
        Task<bool> UpdateLanguage(Language createdLanguage, Guid id);
        Task<bool> RemoveLanguage(Guid id);
        Task<List<Language>> GetAllLanguages();
        Task<Language?> GetLanguage(Guid id);
        Task<List<Language>> GetLanguage(string name);
        //Task<bool> LanguageExists(Guid id);
    }
}