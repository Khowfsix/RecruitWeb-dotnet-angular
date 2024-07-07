using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AwardRepository : Repository<Award>, IAwardRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public AwardRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Award>> GetAllAwards()
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