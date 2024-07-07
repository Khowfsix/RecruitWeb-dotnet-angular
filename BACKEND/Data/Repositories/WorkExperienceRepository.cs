using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class WorkExperienceRepository : Repository<WorkExperience>, IWorkExperienceRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkExperienceRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WorkExperience>> GetAllWorkExperiences()
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