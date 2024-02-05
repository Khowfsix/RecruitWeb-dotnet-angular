using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        private readonly IUnitOfWork _uow;

        public SkillRepository(RecruitmentWebContext dbContext,
            IUnitOfWork uow) : base(dbContext)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Skill>> GetAllSkills(string? request)
        {
            if (string.IsNullOrEmpty(request))
            {
                var datas = await Entities.Take(10).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await Entities.Where(s => s.SkillName.Contains(request)).Take(10).ToListAsync();
                return datas;
            }
        }

        public async Task<Skill> SaveSkill(Skill request)
        {
            request.SkillId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateSkill(Skill request, Guid requestId)
        {
            request.SkillId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSkill(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.SkillId == requestId);
            if (entity is null or { IsDeleted: true })
            {
                return await Task.FromResult(false);
            }
            entity.IsDeleted = true;
            Entities.Update(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}