using Data.CustomModel.Application;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> GetAllApplicationsByPositionId(Guid positionId, ApplicationFilter? applicationFilter, string? sortString);

        Task<IEnumerable<Application>> GetAllApplications();

        Task<IEnumerable<Application>> GetApplicationHistory(Guid candidateId);

        Task<Application?> GetApplicationById(Guid ApplicationId);

        Task<IEnumerable<Application>> GetApplicationsWithStatus(
            int status,
            int priority
        );

        Task<Application> SaveApplication(Application request);

        Task<bool> UpdateApplication(Application request, Guid requestId);

        Task<bool> DeleteApplication(Guid applicationId);

        Task<IEnumerable<Application>> ApplicationReport(DateTime fromDate, DateTime toDate);
    }
}