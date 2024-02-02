using Data.Entities;

namespace Data.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<IEnumerable<Report>> GetAllReport();

        Task<Report> SaveReport(Report request);

        Task<bool> UpdateReport(Report request, Guid requestId);

        Task<bool> DeleteReport(Guid requestId);
    }
}