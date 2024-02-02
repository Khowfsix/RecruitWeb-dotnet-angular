using Data.Entities;

namespace Data.Interfaces;

public interface IInterviewerRepository : IRepository<Interviewer>
{
    Task<IEnumerable<Interviewer>> GetAllInterviewer();

    Task<Interviewer?> GetInterviewerById(Guid id);

    Task<IEnumerable<Interviewer>> GetInterviewersInDepartment(Guid deparmentId);

    Task<Interviewer> SaveInterviewer(Interviewer request);

    Task<bool> UpdateInterviewer(Interviewer request, Guid requestId);

    Task<bool> DeleteInterviewer(Guid requestId);
}