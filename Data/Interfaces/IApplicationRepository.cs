﻿using Data.Entities;

using Api.ViewModels.Application;

namespace Data.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ApplicationModel>> GetAllApplications();

        Task<IEnumerable<ApplicationHistoryViewModel>> GetApplicationHistory(Guid Cvid);

        Task<ApplicationModel?> GetApplicationById(Guid ApplicationId);

        Task<IEnumerable<ApplicationModel>> GetApplicationsWithStatus(
            string status,
            string priority
        );

        Task<ApplicationModel> SaveApplication(ApplicationModel request);

        Task<bool> UpdateApplication(ApplicationModel request, Guid requestId);

        Task<bool> DeleteApplication(Guid applicationId);

        Task<IEnumerable<Application>> ApplicationReport(DateTime fromDate, DateTime toDate);
    }
}