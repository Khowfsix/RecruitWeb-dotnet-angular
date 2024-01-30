using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SuccessfulCadidateRepository : Repository<SuccessfulCadidate>, ISuccessfulCadidateRepository
    {
        private readonly IUnitOfWork _uow;

        public SuccessfulCadidateRepository(RecruitmentWebContext dbContext,
            IUnitOfWork uow) : base(dbContext)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<SuccessfulCadidate>> GetAllSuccessfulCadidates(string? request)
        {
            if (string.IsNullOrEmpty(request))
            {
                var datas = await Entities.Take(10).ToListAsync();
                return datas;
            }
            else
            {
                var datas = await Entities.Where(
                    s => s.Candidate.User.FullName.Contains(request) ||
                         s.Position.PositionName.Contains(request)
                    ).Take(10).ToListAsync();
                return datas;
            }
        }

        public async Task<SuccessfulCadidate> SaveSuccessfulCadidate(SuccessfulCadidate request)
        {
            request.SuccessfulCadidateId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateSuccessfulCadidate(SuccessfulCadidate request, Guid requestId)
        {
            request.SuccessfulCadidateId = requestId;

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSuccessfulCadidate(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.SuccessfulCadidateId == requestId);
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