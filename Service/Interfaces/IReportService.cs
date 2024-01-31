using Service.Models;

namespace Service.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportModel>> GetAllReport();

        Task<ReportModel> SaveReport(ReportModel viewModel);

        Task<bool> UpdateReport(ReportModel reportModel, Guid reportModelId);

        Task<bool> DeleteReport(Guid reportModelId);

        Task<IEnumerable<InterviewReportModel>> InterviewReport(DateTime fromDate, DateTime toDate);

        Task<IEnumerable<ApplicationReportModel>> ApplicationReport(DateTime fromDate, DateTime toDate);
    }
}