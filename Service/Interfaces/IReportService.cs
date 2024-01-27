using Data.ViewModels.Report;

namespace Service.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportViewModel>> GetAllReport();

        Task<ReportViewModel> SaveReport(ReportAddModel viewModel);

        Task<bool> UpdateReport(ReportUpdateModel reportModel, Guid reportModelId);

        Task<bool> DeleteReport(Guid reportModelId);

        Task<IEnumerable<InterviewReportViewModel>> InterviewReport(DateTime fromDate, DateTime toDate);

        Task<IEnumerable<ApplicationReportViewModel>> ApplicationReport(DateTime fromDate, DateTime toDate);
    }
}