using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoundRepository : Repository<Round>, IRoundRepository
    {
        private readonly IUnitOfWork _uow;

        public RoundRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Round>> GetAllRounds(string? request)
        {
            if (string.IsNullOrEmpty(request))
            {
                var datas = await Entities.ToListAsync();
                return datas;
            }
            else
            {
                var datas = await Entities.Where(r => r.InterviewId.ToString().Contains(request)).Take(10).ToListAsync();
                return datas;
            }
        }

        public async Task<Round> SaveRound(Round request)
        {
            request.RoundId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateRound(Round request, Guid requestId)
        {
            request.RoundId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRound(Guid requestId)
        {
            var data = GetById(requestId);
            if (data != null)
            {
                Entities.Remove(data);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            throw new ArgumentNullException(nameof(data));
        }
    }
}