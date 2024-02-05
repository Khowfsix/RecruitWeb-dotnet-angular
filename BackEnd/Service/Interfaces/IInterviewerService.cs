using Service.Models;

namespace Service.Interfaces;

public interface IInterviewerService
{
    Task<IEnumerable<InterviewerModel>> GetAllInterviewer();

    Task<InterviewerModel?> GetInterviewerById(Guid id);

    Task<IEnumerable<InterviewerModel?>> GetInterviewersInDepartment(Guid departmentId);

    Task<InterviewerModel> SaveInterviewer(InterviewerModel addModel);

    Task<bool> UpdateInterviewer(InterviewerModel interviewerModel, Guid interviewerModelId);

    Task<bool> DeleteInterviewer(Guid interviewerModelId);
}