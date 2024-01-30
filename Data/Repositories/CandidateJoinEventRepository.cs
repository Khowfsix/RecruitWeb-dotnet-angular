using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CandidateJoinEventRepository : Repository<CandidateJoinEvent>, ICandidateJoinEventRepository
    {
        private readonly IUnitOfWork _uow;

        public CandidateJoinEventRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<CandidateJoinEvent>> GetAllCandidateJoinEvents()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<CandidateJoinEvent> SaveCandidateJoinEvent(CandidateJoinEvent request)
        {
            request.CandidateJoinEventId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateCandidateJoinEvent(CandidateJoinEvent request, Guid requestId)
        {
            try
            {
                request.CandidateJoinEventId = requestId;
                Entities.Update(request);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteCandidateJoinEvent(Guid requestId)
        {
            try
            {
                var candidateJoinEvent = GetById(requestId);
                if (candidateJoinEvent == null)
                    return await Task.FromResult(false);

                Entities.Remove(candidateJoinEvent);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CandidateJoinEvent>> JoinEventDetail(Guid candidateId)
        {
            try
            {
                var listData = await Entities
                    .Where(c => c.CandidateId.Equals(candidateId))
                    .Include(c => c.Event)
                    .Include(c => c.Candidate.User)
                    .ToListAsync();

                return listData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CandidateJoinEvent>> GetCandidatesSortedByJoinEventCount()
        {
            return await Task.FromResult(Entities.ToList());
        }
    }
}