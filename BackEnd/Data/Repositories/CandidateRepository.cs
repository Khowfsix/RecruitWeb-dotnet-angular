using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CandidateRepository : Repository<Candidate>, ICandidateRepository
    {
        private readonly IUnitOfWork _uow;

        public CandidateRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteCandidate(Guid candidateId)
        {
            try
            {
                var candidate = GetById(candidateId);
                if (candidate == null)
                    return await Task.FromResult(false);

                candidate.IsDeleted = true;
                Entities.Update(candidate);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            var listData = await Entities.Include(x => x.User).Include(o => o.CandidateHasSkills).ToListAsync();
            return listData;
        }

        public async Task<Candidate> FindById(Guid id)
        {
            var entity = await Entities
                .Where(x => x.CandidateId == id)
                .Include(c => c.User)
                .Include(o => o.CandidateHasSkills)
                .FirstOrDefaultAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return entity;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Candidate?> GetCandidateByUserId(string userId)
        {
            var data = await Entities
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
                .FirstOrDefaultAsync();

            return data;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

        public async Task<Candidate?> GetProfile(Guid candidateId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var profile = GetById(candidateId);
            if (profile is not null)
            {
                return profile;
            }
            else return null;
        }

        public async Task<Candidate> SaveCandidate(Candidate request)
        {
            try
            {
                request.CandidateId = Guid.NewGuid();

                Entities.Add(request);
                _uow.SaveChanges();

                return await Task.FromResult(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateCandidate(Candidate request, Guid requestId)
        {
            try
            {
                request.CandidateId = requestId;
                Entities.Update(request);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
                return await Task.FromResult(false);
            }
        }
    }
}