using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ResultRepository : Repository<Result>, IResultRepository
    {
        private readonly IUnitOfWork _uow;

        public ResultRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Result>> GetAllResult()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<Result> SaveResult(Result request)
        {
            request.ResultId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateResult(Result request, Guid requestId)
        {
            request.ResultId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteResult(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.ResultId == requestId);
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