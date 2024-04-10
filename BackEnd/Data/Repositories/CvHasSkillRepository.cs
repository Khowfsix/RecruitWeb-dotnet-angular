using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CvHasSkillRepository : Repository<CvHasSkill>, ICvHasSkillrepository
    {
        private readonly IUnitOfWork _uow;

        public CvHasSkillRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteCvHasSkillService(Guid requestId)
        {
            try
            {
                var cvHasSkill = GetById(requestId);
                if (cvHasSkill == null)
                    return await Task.FromResult(false);

                Entities.Remove(cvHasSkill);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CvHasSkill>> GetAllByCvId(Guid? cvId)
        {
            var listData = await Entities.Where(e => e.Cvid == cvId)
                .Include(e => e.Skill)
                .ToListAsync();
            return listData!;
        }

        public async Task<IEnumerable<CvHasSkill>> GetAllCvHasSkillService(string? request)
        {
            try
            {
                var listData = new List<CvHasSkill>();
                if (string.IsNullOrEmpty(request))
                {
                    listData = await Entities.ToListAsync();
                }
                else
                {
                    listData = await Entities.Where(c => c.Skill.SkillName.Equals(request)).ToListAsync();
                }
                return listData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Cv>> GetCv(Guid skillId)
        {
            var data = await Entities
                .Where(x => x.SkillId == skillId)
                .Include(x => x.Cv)
                .Select(x => x.Cv)
                .ToListAsync();

            return data;
        }

        public async Task<IList<Skill>> GetSkill(Guid Cvid)
        {
            var data = await Entities
                .Where(x => x.Cvid == Cvid)
                .Include(x => x.Skill)
                .Select(x => x.Skill)
                .ToListAsync();

            return data;
        }

        public async Task<CvHasSkill> SaveCvHasSkillService(CvHasSkill request)
        {
            try
            {
                request.CvSkillsId = Guid.NewGuid();

                Entities.Add(request);
                _uow.SaveChanges();

                return await Task.FromResult(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateCvHasSkillService(CvHasSkill request, Guid requestId)
        {
            try
            {
                request.CvSkillsId = requestId;
                Entities.Update(request);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CvHasSkill>> GetAllSkillsFromOneCV(Guid Cvid)
        {
            var cvHasSkillList = Entities.Include(c => c.Skill).Where(c => c.Cvid == Cvid).ToListAsync();
            List<CvHasSkill> result = await cvHasSkillList;
            return result;
        }
    }
}