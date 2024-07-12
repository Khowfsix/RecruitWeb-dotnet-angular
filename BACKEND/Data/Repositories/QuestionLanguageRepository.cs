using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class QuestionLanguageRepository : Repository<QuestionLanguage>, IQuestionLanguageRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionLanguageRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<QuestionLanguage>> GetAllQuestionLanguages()
        {
            /*------------------------------*/
            // Finds all of level entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var entities = await Entities
                .ToListAsync();

            return entities;
        }

        public async Task<QuestionLanguage> AddQuestionLanguage(QuestionLanguage data)
        {
            data.QuestionLanguageId = Guid.NewGuid();

            Entities.Add(data);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(data);
        }
    }
}