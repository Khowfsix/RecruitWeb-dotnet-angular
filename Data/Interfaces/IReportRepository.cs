using Data.Entities;

using Api.ViewModels.Report;

namespace Data.Interfaces
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<IEnumerable<ReportModel>> GetAllReport();
        Task<ReportModel> SaveReport(ReportModel request);
        Task<bool> UpdateReport(ReportModel request, Guid requestId);
        Task<bool> DeleteReport(Guid requestId);
    }
}
