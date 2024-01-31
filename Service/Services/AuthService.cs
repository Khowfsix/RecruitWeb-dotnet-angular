using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Service.Models;

namespace Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICandidateService _candidateService;
        private readonly IRecruiterService _recruiterService;
        private readonly IInterviewerService _interviewerService;
        private readonly IBlacklistService _blacklistService;
        private readonly IInterviewService _interviewService;
        private readonly IApplicationService _applicationService;
        private readonly ICvService _cvService;
        //private readonly IDepartmentService _departmentService;
        private readonly ISuccessfulCandidateService _successfulCandidateService;

        public AuthService(UserManager<WebUser> userManager,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            //IHttpContextAccessor httpContextAccessor,
            ICandidateService candidateService,
            IRecruiterService recruiterService,
            IInterviewerService interviewerService,
            IBlacklistService blacklistService,
            IInterviewService interviewService,
            IApplicationService applicationService,
            ISuccessfulCandidateService successfulCandidateService,
            ICvService cvService
            //IDepartmentService departmentService
            )
        {
            _userManager = userManager;
            _mapper = mapper;
            //_httpContextAccessor = httpContextAccessor;
            _candidateService = candidateService;
            _recruiterService = recruiterService;
            _interviewerService = interviewerService;
            _blacklistService = blacklistService;
            _interviewService = interviewService;
            _applicationService = applicationService;
            _cvService = cvService;
            //_departmentService = departmentService;
            _successfulCandidateService = successfulCandidateService;
            _roleManager = roleManager;
        }

        public async Task<string> GetCurrentUserId(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            string userId = user.Id;

            if (user != null)
            {
                return userId;
            }
            return null!;
            //throw new NotImplementedException();
        }

        public async Task<string> GetCurrentUserRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userRole = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                return userRole[0];
            }
            return null!;
            //throw new NotImplementedException();
        }

        public async Task<bool> CreateCandidate(string userId)
        {
            var candidate = new CandidateModel
            {
                //CandidateId = Guid.Empty,
                UserId = userId,
                Experience = "",
                IsDeleted = false,
            };
            var response = await _candidateService.SaveCandidate(candidate);
            if (response != null)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> CreateRecruiter(string userId, Guid departmentId)
        {
            var recruiter = new RecruiterModel
            {
                //RecruiterId = Guid.Empty,
                UserId = userId,
                DepartmentId = departmentId,
                IsDeleted = false
            };
            var response = await _recruiterService.SaveRecruiter(recruiter);
            if (response != null)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> CreateInterviewer(string userId, Guid departmentId)
        {
            var interviewer = new InterviewerModel
            {
                //InterviewerId = Guid.Empty,
                UserId = userId,
                DepartmentId = departmentId,
                IsDeleted = false
            };
            var response = await _interviewerService.SaveInterviewer(interviewer);
            if (response != null)
            {
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<IEnumerable<ProfileModel>> GetUsersInBlacklist()
        {
            var blacklist = await _blacklistService.GetAllBlackLists();
            var listCandidate = new List<Guid>();
            var listUser = new List<ProfileModel>();
            if (blacklist != null)
            {
                foreach (var item in blacklist)
                {
                    listCandidate.Add(item.CandidateId);
                }
            }
            else
                return null!;
            if (listCandidate != null)
            {
                foreach (var item in listCandidate)
                {
                    var user = await _candidateService.GetProfile(item);
                    if (user != null)
                    {
                        listUser.Add(user);
                    }
                }
            }
            else
                return null!;
            if (listUser != null)
                return listUser;
            else return null!;
        }

        public async Task<bool> BrowsePassInterview(Guid interviewId)
        {
            //[Interview].Company_Status = Passed
            var interviewViewModel = await _interviewService.GetInterviewById(interviewId);
            if (interviewViewModel == null)
            {
                return false;
            }
            var interviewModel = _mapper.Map<InterviewModel>(interviewViewModel);

            interviewModel.Company_Status = "Passed";
            await _interviewService.UpdateInterview
                (_mapper.Map<InterviewModel>
                (interviewModel), interviewId);

            //[Application].Candidate_Status = Passed
            var applicationModel = _mapper.Map<ApplicationModel>
                (_applicationService.GetApplicationById(interviewModel.ApplicationId));
            if (applicationModel == null)
            {
                return await Task.FromResult(false);
            }
            applicationModel.Company_Status = "Passed";
            await _applicationService.UpdateApplication
                (_mapper.Map<ApplicationModel>
                (applicationModel), interviewModel.ApplicationId);

            //Get CandidateId
            var cv = await _cvService.GetCvById(applicationModel.Cvid);
            if (cv == null)
            {
                return await Task.FromResult(false);
            }

            //Create SuccessfullCandidate
            var susCandidate = new SuccessfulCadidateModel()
            {
                PositionId = applicationModel.PositionId,
                CandidateId = cv.CandidateId,
                DateSuccess = applicationModel.DateTime,
            };

            var data = await _successfulCandidateService.SaveSuccessfulCadidate(susCandidate);
            if (data != null)
            {
                return await Task.FromResult(true);
            }
            else
                return await Task.FromResult(false);
        }

        public async Task<bool> BrowseFailInterview(Guid interviewId)
        {
            //[Interview].Company_Status = Failed
            var interviewViewModel = await _interviewService.GetInterviewById(interviewId);
            if (interviewViewModel == null)
            {
                return false;
            }
            var interviewModel = _mapper.Map<InterviewModel>(interviewViewModel);

            interviewModel.Company_Status = "Failed";
            var data = await _interviewService.UpdateInterview
                (_mapper.Map<InterviewModel>
                (interviewModel), interviewId);
            if (data == true)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<IEnumerable<UserModel>> GetAllAccount()
        {
            var listUserVM = new List<UserModel>();
            var listWebUser = await _userManager.Users.ToListAsync();
            if (listWebUser != null)
            {
                foreach (var item in listWebUser)
                {
                    var user = _mapper.Map<UserModel>(item);
                    user.CandidateId = await GetCandidateId(user.Id);
                    user.InterviewerId = await GetInterviewerId(user.Id);
                    user.RecruiterId = await GetRecruiterId(user.Id);
                    user.DepartmentId = await GetDepartmentId(user.Id);
                    listUserVM.Add(user);
                }
            }
            else
                return null;

            return listUserVM;
        }

        public async Task<IEnumerable<UserModel>> GetAllCandidate()
        {
            string roleName = "Candidate";
            var listCandidate = new List<UserModel>();
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var userInRole = await _userManager.GetUsersInRoleAsync(roleName);
                if (userInRole != null)
                {
                    foreach (var item in userInRole)
                    {
                        var user = _mapper.Map<UserModel>(item);
                        user.CandidateId = await GetCandidateId(user.Id);
                        user.InterviewerId = await GetInterviewerId(user.Id);
                        user.RecruiterId = await GetRecruiterId(user.Id);
                        user.DepartmentId = await GetDepartmentId(user.Id);
                        if (user.CandidateId != null)
                            listCandidate.Add(user);
                    }
                }
                else
                    return null!;
            }
            return listCandidate;
        }

        public async Task<IEnumerable<UserModel>> GetAllInterviewer()
        {
            string roleName = "Interviewer";
            var listInterviewer = new List<UserModel>();
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var userInRole = await _userManager.GetUsersInRoleAsync(roleName);
                if (userInRole != null)
                {
                    foreach (var item in userInRole)
                    {
                        var user = _mapper.Map<UserModel>(item);
                        user.CandidateId = await GetCandidateId(user.Id);
                        user.InterviewerId = await GetInterviewerId(user.Id);
                        user.RecruiterId = await GetRecruiterId(user.Id);
                        user.DepartmentId = await GetDepartmentId(user.Id);
                        if (user.InterviewerId != null)
                            listInterviewer.Add(user);
                    }
                }
                else
                    return null;
            }
            return listInterviewer;
        }

        public async Task<Guid?> GetCandidateId(string userId)
        {
            var listCandidate = await _candidateService.GetAllCandidates();
            if (listCandidate != null)
            {
                foreach (var item in listCandidate)
                {
                    if (item.UserId == userId)
                        return item.CandidateId;
                }
                return null;
            }
            else
                return null;
        }

        public async Task<Guid?> GetInterviewerId(string userId)
        {
            var listInterviewer = await _interviewerService.GetAllInterviewer();
            if (listInterviewer != null)
            {
                foreach (var item in listInterviewer)
                {
                    if (item.UserId == userId)
                        return item.InterviewerId;
                }
                return null;
            }
            else
                return null;
        }

        public async Task<Guid?> GetRecruiterId(string userId)
        {
            var listRecruiter = await _recruiterService.GetAllRecruiter();
            if (listRecruiter != null)
            {
                foreach (var item in listRecruiter)
                {
                    if (item.UserId == userId)
                        return item.RecruiterId;
                }
                return null;
            }
            else
                return null;
        }

        public async Task<Guid?> GetDepartmentId(string userId)
        {
            var listRecruiter = await _recruiterService.GetAllRecruiter();
            if (listRecruiter != null)
            {
                foreach (var item in listRecruiter)
                {
                    if (item.UserId == userId)
                        return item.DepartmentId;
                }
            }
            var listInterviewer = await _interviewerService.GetAllInterviewer();
            if (listInterviewer != null)
            {
                foreach (var item in listInterviewer)
                {
                    if (item.UserId == userId)
                        return item.DepartmentId;
                }
                return null;
            }
            else
                return null;
        }

        public async Task<IEnumerable<UserModel>> GetAllRecruiter()
        {
            string roleName = "Recruiter";
            var listRecruiter = new List<UserModel>();
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var userInRole = await _userManager.GetUsersInRoleAsync(roleName);
                if (userInRole != null)
                {
                    foreach (var item in userInRole)
                    {
                        var user = _mapper.Map<UserModel>(item);
                        user.CandidateId = await GetCandidateId(user.Id);
                        user.InterviewerId = await GetInterviewerId(user.Id);
                        user.RecruiterId = await GetRecruiterId(user.Id);
                        user.DepartmentId = await GetDepartmentId(user.Id);
                        if (user.RecruiterId != null)
                            listRecruiter.Add(user);
                    }
                }
                else
                    return null;
            }
            return listRecruiter;
        }

        public async Task<IEnumerable<WebUserModel>> GetAllUsers()
        {
            var listWebUser = await _userManager.Users.ToListAsync();
            if (listWebUser == null)
                return null!;
            return _mapper.Map<List<WebUserModel>>(listWebUser);
        }

        public async Task<IEnumerable<WebUserModel>> GetAllSystemAccount()
        {
            var listWebUser = await _userManager.Users.ToListAsync();
            if (listWebUser == null)
                return null;
            var listUserVM = new List<WebUserModel>();
            foreach (var item in listWebUser)
            {
                var userVM = _mapper.Map<WebUserModel>(item);
                if (userVM != null)
                    listUserVM.Add(userVM);
            }
            return listUserVM;
        }

        public async Task<UserModel> GetAccountByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null!;
            var webUser = _mapper.Map<UserModel>(user);
            webUser.CandidateId = await GetCandidateId(user.Id);
            webUser.InterviewerId = await GetInterviewerId(user.Id);
            webUser.RecruiterId = await GetRecruiterId(user.Id);
            webUser.DepartmentId = await GetDepartmentId(user.Id);
            if (webUser != null)
                return webUser;
            else
                return null!;
        }

        public async Task<ProfileModel> GetUserInBlacklistById(string userId)
        {
            var users = await _blacklistService.GetAllBlackLists();
            var user = await GetAccountByUserId(userId);
            var userInBL = new ProfileModel();
            foreach (var item in users)
            {
                if (item.CandidateId == user.CandidateId)
                {
                    userInBL = await _candidateService.GetProfile(item.CandidateId);
                }
            }
            if (userInBL!.UserId != Guid.Empty)
                return userInBL;
            else
                return null!;
        }
    }
}