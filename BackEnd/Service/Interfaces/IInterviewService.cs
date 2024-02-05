using Service.Models;

namespace Service.Interfaces;

public interface IInterviewService
{
    Task<IEnumerable<InterviewModel>> GetAllInterview(string status);

    Task<IEnumerable<InterviewModel>> GetInterviewsByInterviewer(Guid requestId);

    Task<IEnumerable<InterviewModel>> GetInterviewsByPositon(Guid requestId);

    Task<IEnumerable<InterviewModel>> GetInterviewsByDepartment(Guid requestId);

    Task<InterviewModel?> GetInterviewById(Guid id);

    Task<InterviewModel> SaveInterview(InterviewModel viewModel);

    //Task<bool> CreateInterviewWithApplication(InterviewAddModel interviewRequest, Guid applicationId);
    Task<bool> UpdateInterview(InterviewModel interviewModel, Guid interviewModelId);

    Task<bool> UpdateStatusInterview(Guid interviewId, string? Candidate_Status, string? Company_Status);

    Task<bool> DeleteInterview(Guid interviewModelId);

    //todo: InterviewResultQuestionModel in viewmodel
    Task<InterviewModel?> PostQuestionIntoInterview(InterviewResultQuestion_Model request);

    Task<InterviewModel?> GetInterviewById_noInclude(Guid id);
}