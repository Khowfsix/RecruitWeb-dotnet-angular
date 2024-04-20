using Data.CustomModel.Interviewer;
using Data.Entities;

namespace Data.Interfaces;

public interface IInterviewRepository : IRepository<Interview>
{
    Task<IEnumerable<Interview>> GetAllInterview();

    Task<IEnumerable<Interview>> GetInterviewsByCompanyId(Guid companyId, InterviewFilter interviewFilter, string sortString);

    Task<Interview?> GetInterviewById(Guid id);

    Task<Interview?> GetInterviewById_NoInclude(Guid id);

    Task<IEnumerable<Interview>> GetInterviewOfInterviewer(Guid id);

    Task<Interview?> SaveInterview(Interview request);

    //Task<bool> CreateInterviewWithApplication(Interview interviewRequest, Guid applicationRequest);
    Task<bool> UpdateInterview(Interview request, Guid requestId);

    Task<bool> DeleteInterview(Guid requestId);

    Task<IEnumerable<Interview>> InterviewReport(DateTime fromDate, DateTime toDate);
}