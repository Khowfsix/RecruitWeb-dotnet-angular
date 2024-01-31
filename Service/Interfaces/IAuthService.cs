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

        Task<IEnumerable<ProfileModel>> GetUsersInBlacklist();

        Task<IEnumerable<UserModel>> GetAllCandidate();

        Task<IEnumerable<UserModel>> GetAllInterviewer();

        Task<IEnumerable<UserModel>> GetAllRecruiter();

        Task<IEnumerable<UserModel>> GetAllAccount();

        Task<UserModel> GetAccountByUserId(string userId);

        Task<IEnumerable<WebUserModel>> GetAllSystemAccount();

        Task<IEnumerable<WebUserModel>> GetAllUsers();

        Task<ProfileModel> GetUserInBlacklistById(string userId);

        Task<bool> BrowsePassInterview(Guid interviewId);

        Task<bool> BrowseFailInterview(Guid interviewId);
    }
}