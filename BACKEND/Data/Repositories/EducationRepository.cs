using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Education>> GetAllEducations()
        {
            /*------------------------------*/
            // Finds all of level entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var entities = await Entities
                .ToListAsync();

            return entities;
        }
    }
}