using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        private readonly IUnitOfWork _uow;

        public ReportRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Report>> GetAllReport()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<Report> SaveReport(Report request)
        {
            request.ReportId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateReport(Report request, Guid requestId)
        {
            request.ReportId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteReport(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.ReportId == requestId);
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