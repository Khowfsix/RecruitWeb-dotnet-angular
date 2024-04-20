using Data.CustomModel.Application;
using Service.Models;

namespace Service.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationModel>> GetAllApplicationsByPositionId(Guid positionId, ApplicationFilter? applicationFilter, string? sortString);

        Task<IEnumerable<ApplicationModel>> GetAllApplications();

        Task<IEnumerable<ApplicationModel>> GetAllApplicationsOfPosition(Guid? positionId, int? status, int? priority);

        //todo: return ApplicationHistoryViewModel
        Task<IEnumerable<ApplicationModel>> GetApplicationHistory(Guid candidateId);

        Task<ApplicationModel?> GetApplicationById(Guid ApplicationId);

        Task<IEnumerable<ApplicationModel>> GetApplicationsWithStatus(int status, int priority);

        Task<ApplicationModel> SaveApplication(ApplicationModel requestId);

        Task<bool> UpdateApplication(ApplicationModel request, Guid applicationId);

        Task<bool> UpdateStatusApplication(Guid applicationId, int? Candidate_Status, int? Company_Status);

        Task<bool> DeleteApplication(Guid applicationId);
    }
}