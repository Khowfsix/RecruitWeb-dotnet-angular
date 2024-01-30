using Data.Entities;
using Service.Models;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<String> GetCurrentUserId(string username);

        Task<String> GetCurrentUserRole(string username);

        Task<bool> CreateCandidate(string userId);

        Task<bool> CreateRecruiter(string userId, Guid departmentId);

        Task<bool> CreateInterviewer(string userId, Guid departmentId);

        Task<Guid?> GetDepartmentId(string userId);

        Task<Guid?> GetRecruiterId(string userId);

        Task<Guid?> GetInterviewerId(string userId);

        Task<Guid?> GetCandidateId(string userId);

        Task<IEnumerable<CandidateModel>> GetUsersInBlacklist();

        Task<IEnumerable<WebUser>> GetAllCandidate();

        Task<IEnumerable<WebUser>> GetAllInterviewer();

        Task<IEnumerable<WebUser>> GetAllRecruiter();

        Task<IEnumerable<WebUser>> GetAllAccount();

        Task<WebUser> GetAccountByUserId(string userId);

        Task<IEnumerable<WebUser>> GetAllSystemAccount();

        Task<IEnumerable<WebUser>> GetAllUsers();

        Task<CandidateModel> GetUserInBlacklistById(string userId);

        Task<bool> BrowsePassInterview(Guid interviewId);

        Task<bool> BrowseFailInterview(Guid interviewId);
    }
}