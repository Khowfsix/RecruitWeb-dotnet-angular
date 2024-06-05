using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<IEnumerable<CandidateJoinEvent>> GetAllCandidateJoinEventsByCandidateId(Guid candidateId, string sortString)
        {
            var query = Entities.Where(o => o.CandidateId == candidateId).AsNoTracking();

            if (sortString != null)
            {
                var sort = new Sort<CandidateJoinEvent>(sortString);
                query = sort.getSort(query);
            }
            var result = await query
                .Include(o => o.Event.Recruiter.User)
                //.Include(o => o.Candidate)
                //.OrderByDescending(o => o.DateJoin)
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CandidateJoinEvent>> GetAllCandidateJoinEventsByEventId(Guid eventId, string? search, string sortString)
        {
            var query = Entities.Where(o => o.EventId == eventId)
                //.Include(o => o.Event.Recruiter.User)
                .Include(o => o.Candidate.User).AsNoTracking();

            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(e => e.Candidate!.User!.UserName.ToLower().Contains(search.ToLower()));
            }

            if (sortString != null)
            {
                var sort = new Sort<CandidateJoinEvent>(sortString);
                query = sort.getSort(query);
            }
            var result = await query
                .ToListAsync();
            return result;
        }
        public async Task<IEnumerable<CandidateJoinEvent>> GetAllCandidateJoinEvents()
        {
            var listData = await Entities
                .Include(o => o.Event)
                .Include(o => o.Candidate)
                .ToListAsync();
            return listData;
        }

        public async Task<CandidateJoinEvent> SaveCandidateJoinEvent(CandidateJoinEvent request)
        {
            request.CandidateJoinEventId = Guid.NewGuid();
            request.DateJoin = DateTime.Today;

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