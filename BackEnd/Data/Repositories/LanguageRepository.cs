using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Data.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LanguageRepository(RecruitmentWebContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Language> AddLanguage(Language createdLanguage)
        {
            /*------------------------------*/
            // Adds mapped entity to db from given model.
            /*------------------------------*/
            try
            {
                createdLanguage.LanguageId = Guid.NewGuid();
                Entities.Add(createdLanguage);
                _unitOfWork.SaveChanges();
                return await Task.FromResult(createdLanguage);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveLanguage(Guid id)
        {
            try
            {
                /*------------------------------*/
                // Finds asynchronously and removes entity with matched id in db.
                var language = await Entities.FindAsync(id);
                /*------------------------------*/

                if (language == null)
                    return await Task.FromResult(false);

                language.IsDeleted = true;
                Entities.Update(language);

                _unitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            /*------------------------------*/
            // Finds all of language entities asynchronously in db.
            // Returns a list of found entities.
            /*------------------------------*/
            var entityDatas = await Entities.ToListAsync();

            return !entityDatas.IsNullOrEmpty() ? entityDatas : new List<Language>();
        }

        public async Task<Language?> GetLanguage(Guid id)
        {
            /*------------------------------*/
            // Finds asynchronously and returns the first language with matched id in db.
            // Returns null if id is not matched.
            var language = await Entities
                    .Where(l => l.LanguageId == id)
                    .FirstOrDefaultAsync();

            // Returns mapped model of the language if it is found. Otherwise, return null.
            return language is not null ? language : null;
        }

        public async Task<List<Language>> GetLanguage(string name)
        {
            /*------------------------------*/
            // Finds all of language entities that contain name parameter asynchronously in db.
            // Returns a list of models mapped from found entities if matched.
            /*------------------------------*/

            var listLanguage = await Entities
                            .Where(l => l.LanguageName.ToLower().Contains(name.ToLower().Trim()))
                            .ToListAsync();
            return !listLanguage.IsNullOrEmpty() ? listLanguage : new List<Language>();
        }

        public async Task<bool> UpdateLanguage(Language createdLanguage, Guid id)
        {
            try
            {
                /*------------------------------*/
                // If id is not found in db, return false. Else, update and return true.
                if (await Entities.AnyAsync(l => l.LanguageId.Equals(id)) is false)
                    return await Task.FromResult(false);
                /*------------------------------*/

                createdLanguage.LanguageId = id;
                Entities.Update(createdLanguage);

                _unitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}