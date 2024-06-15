using Service.Models;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<String> GetCurrentUserId(string username);

        Task<String> GetCurrentUserRole(string username);

        Task<bool> CreateCandidate(string userId);

        Task<bool> CreateRecruiter(string userId, Guid companyId);

        Task<bool> CreateInterviewer(string userId, Guid companyId);

        Task<Guid?> GetCompanyId(string userId);

        Task<Guid?> GetRecruiterId(string userId);

        Task<Guid?> GetInterviewerId(string userId);

        Task<Guid?> GetCandidateId(string userId);

        Task<IEnumerable<ProfileModel>> GetUsersInBlacklist();

        Task<IEnumerable<WebUserModel>> GetAllCandidate();

        Task<IEnumerable<WebUserModel>> GetAllInterviewer();

        Task<IEnumerable<WebUserModel>> GetAllRecruiter();

        Task<IEnumerable<WebUserModel>> GetAllAccount();

        Task<WebUserModel> GetAccountByUserId(string userId);

        Task<IEnumerable<WebUserModel>> GetAllSystemAccount();

        Task<IEnumerable<WebUserModel>> GetAllUsers();

        Task<ProfileModel> GetUserInBlacklistById(string userId);

        Task<bool> BrowsePassInterview(Guid interviewId);

        Task<bool> BrowseFailInterview(Guid interviewId);
    }
}