using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CandidateHasSkillRepository : Repository<CandidateHasSkill>, ICandidateHasSkillrepository
    {
        private readonly IUnitOfWork _uow;

        public CandidateHasSkillRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<CandidateHasSkill>> GetAllByCandidateId(Guid? candidateId)
        {
            var listData = await Entities.Where(e => e.CandidateId == candidateId)
                .Include(e => e.Skill)
                .ToListAsync();
            return listData!;
        }

    }
}