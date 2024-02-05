using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BlackListRepository : Repository<BlackList>, IBlacklistRepository
    {
        private readonly IUnitOfWork _uow;

        public BlackListRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteBlackList(Guid blacklistId)
        {
            try
            {
                var blacklist = GetById(blacklistId);
                if (blacklist == null)
                    return await Task.FromResult(false);

                blacklist.IsDeleted = true;
                Entities.Update(blacklist);

                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BlackList>> GetAllBlackLists()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<BlackList> SaveBlackList(BlackList request)
        {
            request.BlackListId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateBlackList(BlackList request, Guid requestId)
        {
            try
            {
                request.BlackListId = requestId;
                Entities.Update(request);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> CheckIsInBlackList(Guid candidateId)
        {
            var data = await Entities.FirstOrDefaultAsync(x => x.CandidateId == candidateId);
            if (data != null)
                return true;
            else
                return false;
        }
    }
}