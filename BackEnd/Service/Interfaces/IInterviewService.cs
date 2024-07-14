using Data.CustomModel.Interviewer;
using Service.Models;

namespace Service.Interfaces;

public interface IInterviewService
{
    Task<IEnumerable<InterviewModel>> GetAllInterview(int? status);

    Task<IEnumerable<InterviewModel>> GetInterviewsByInterviewer(Guid requestId);

    Task<IEnumerable<InterviewModel>> GetInterviewsByPositon(Guid requestId);

    Task<IEnumerable<InterviewModel>> GetInterviewsByCompanyId(Guid requestId, InterviewFilter? interviewFilter, string? sortString);

    Task<InterviewModel> GetLastInterviewByInterviewerId(Guid interviewerId);

    Task<InterviewModel?> GetInterviewById(Guid id);

    Task<InterviewModel> SaveInterview(InterviewModel viewModel);

    //Task<bool> CreateInterviewWithApplication(InterviewAddModel interviewRequest, Guid applicationId);
    Task<bool> UpdateInterview(InterviewModel interviewModel, Guid interviewModelId);

    Task<bool> UpdateStatusInterview(Guid interviewId, int? Candidate_Status, int? Company_Status);

    Task<bool> DeleteInterview(Guid interviewModelId);

    //todo: InterviewResultQuestionModel in viewmodel
    Task<InterviewModel?> PostQuestionIntoInterview(InterviewResultQuestion_Model request);

    Task<InterviewModel?> GetInterviewById_noInclude(Guid id);
    Task<bool> UpdateAddressInterview(Guid interviewId, string address);
}