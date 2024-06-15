using Api.ViewModels.SuccessfulCadidate;
using AutoMapper;
using Data.Constant;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using Service.Services;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseAPIController
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RecruitmentWebContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly ICandidateService _candidateService;
        private readonly IRecruiterService _recruiterService;
        private readonly IInterviewerService _interviewerService;
        private readonly IBlacklistService _blacklistService;
        private readonly IAuthService _authenticationService;
        private readonly IInterviewService _interviewService;
        private readonly IApplicationService _applicationService;
        private readonly ISuccessfulCandidateService _successfulCandidateService;
        private readonly IMapper _mapper;

        public AdminController(UserManager<WebUser> userManager,
            RoleManager<IdentityRole> roleManager, IEmailService emailService,
            SignInManager<WebUser> signInManager, IConfiguration configuration,
            RecruitmentWebContext dbContext,
            ICandidateService candidateService,
            IRecruiterService recruiterService,
            IInterviewerService interviewerService,
            IBlacklistService blacklistService,
            IAuthService authenticationService,

            IInterviewService interviewService,
            IApplicationService applicationService,
            ISuccessfulCandidateService successfulCandidateService,

            IMapper mapper
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _configuration = configuration;
            _dbContext = dbContext;
            _candidateService = candidateService;
            _recruiterService = recruiterService;
            _interviewerService = interviewerService;
            _blacklistService = blacklistService;
            _authenticationService = authenticationService;

            _interviewService = interviewService;
            _applicationService = applicationService;
            _successfulCandidateService = successfulCandidateService;

            _mapper = mapper;
        }

        [HttpGet("Employees")]
        public IEnumerable<string> Get()
        {
            return new List<string> { "Vi01", "Vi10", "Vi11" };
        }

        //fix mailkit
        [HttpPost]
        [Route("SendConfirmationEmail")]
        public void SendEmailConfirmation(string emailUser, string token)
        {
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = emailUser }, Request.Scheme);
            var message = new Message(new string[] { emailUser! }, "Confirmation email link", confirmationLink!);

            // Send the confirmation email
            _emailService.SendEmail(message);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] SignUp signUp, string role)
        {
            // Check if user already exists
            var userExist = await _userManager.FindByEmailAsync(signUp.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User already exists!" });
            }

            // Create a new WebUser instance
            var user = new WebUser
            {
                Email = signUp.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUp.Username,
                FullName = signUp.FullName,
            };

            // Create the user
            var result = await _userManager.CreateAsync(user, signUp.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = $"Error: {error.Description}" });
                }
            }

            // Check if role is valid and exists
            if (string.IsNullOrEmpty(role))
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Role is null or empty." });
            }

            // Check if the specified role exists
            if (!await _roleManager.RoleExistsAsync(role))
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "This Role Does Not Exist." });
            }

            // Add the specified role to the user
            await _userManager.AddToRoleAsync(user, role);

            // Generate an email confirmation token
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // Create the corresponding interviewer/recruiter record in the database
            if (role == "Interviewer")
            {
                await _authenticationService.CreateInterviewer(user.Id, signUp.CompanyId);
            }
            else if (role == "Recruiter")
            {
                await _authenticationService.CreateRecruiter(user.Id, signUp.CompanyId);
            }
            else if (role == "Candidate")
            {
                await _authenticationService.CreateCandidate(user.Id);
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            // Send email confirmation link
            //await ConfirmEmail(token, signUp.Email);
            SendEmailConfirmation(user.Email!, token);

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = $"User created & email sent to {user.Email} Successfully." });
        }

        [HttpPost]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            // Get the user based on the provided email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = "User not found." });
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new Response { Status = "Error", Message = "This User Does Not Exist" });
            }

            /*
            // Generate the email confirmation link
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);

            // Send the confirmation email
            _emailService.SendEmail(message);
            */

            return StatusCode(StatusCodes.Status200OK,
                new Response { Status = "Success", Message = "Email Verified Successfully" });
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _authenticationService.GetAllUsers();
            if (response == null)
                return BadRequest("System connection failed");
            else if (!response.Any())
                return BadRequest("No user in system!");
            else return Ok(response);
        }

        [HttpPut]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email should not be null or empty");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            // Generate a new password for the user (you can implement your own password generation logic)
            string newPassword = "NewPass@123";

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
            {
                return BadRequest("Failed to reset the password");
            }

            // Send the new password to the user's email (optional)
#pragma warning disable CS8601 // Possible null reference assignment.
            var message = new Message(new string[] { user.Email }, "Password Reset", $"Your new password: {newPassword}");
#pragma warning restore CS8601 // Possible null reference assignment.
            _emailService.SendEmail(message);

            return Ok(new { Status = "Success", Message = "Password reset successfully" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromForm] string id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = $"User does not exist" });
            }
            var _user = await _userManager.FindByIdAsync(id.ToString());

            var result = await _userManager.DeleteAsync(_user);
            return Ok(result);
        }

        [HttpGet]
        [Route("Candidate/All")]
        public async Task<IActionResult> GetAllCandidate()
        {
            var response = await _authenticationService.GetAllCandidate();
            if (response == null)
                return BadRequest("Don't exist role Candidate");
            else if (!response.Any())
                return Ok(true);
            else return Ok(response);
        }

        [HttpGet]
        [Route("Interviewer/All")]
        public async Task<IActionResult> GetAllInterviewer()
        {
            var response = await _authenticationService.GetAllInterviewer();
            if (response == null)
                return BadRequest("Don't exist role Interviewer");
            else if (!response.Any())
                return Ok(true);
            else return Ok(response);
        }

        [HttpGet]
        [Route("Recruiter/All")]
        public async Task<IActionResult> GetAllRecruiter()
        {
            var response = await _authenticationService.GetAllRecruiter();
            if (response == null)
                return BadRequest("Don't exist role Recruiter");
            else if (!response.Any())
                return Ok(true);
            else return Ok(response);
        }

        [HttpGet]
        [Route("Profile/All")]
        public async Task<IActionResult> GetAllAccount()
        {
            var response = await _authenticationService.GetAllAccount();
            if (response == null)
                return BadRequest("System connection failed");
            else if (!response.Any())
                return BadRequest("No user in system!");
            else return Ok(response);
        }

        [HttpGet]
        [Route("Blacklist/All")]
        public async Task<IActionResult> GetAllUserInBlacklist()
        {
            var response = await _authenticationService.GetUsersInBlacklist();
            if (response == null || !response.Any())
                return BadRequest("No user in blacklist!");
            else
                return Ok(response);
        }

        [HttpPost]
        [Route("PassInterview/{interviewId:guid}")]
        public async Task<IActionResult> BrowsePassInterview(Guid interviewId)
        {
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (interviewId != null)
            {
                // Update Interview status
                var interviewResponse = await _interviewService.UpdateStatusInterview(interviewId,
                    null,
                    (int)Interview_CompanyStatus.Passed);

                var thisInterview = await _interviewService.GetInterviewById_noInclude(interviewId);

                // Update Application status
                var applicationResponse = await _applicationService.UpdateStatusApplication(thisInterview!.ApplicationId,
                    (int)Application_CompanyStatus.Accecpted,
                    null);

                var getCVandpos = await _applicationService.GetApplicationById(thisInterview!.ApplicationId);

                // Add successful candidate
                var addSuccessfulCandidate = new SuccessfulCadidateAddModel
                {
                    PositionId = getCVandpos!.Position.PositionId,
                    CandidateId = getCVandpos!.Cv.CandidateId,
                    DateSuccess = DateTime.Now
                };

                var modelAddSuccessfulCandidate = _mapper.Map<SuccessfulCadidateModel>(addSuccessfulCandidate);
                var successfulCandidate = await _successfulCandidateService.SaveSuccessfulCadidate(modelAddSuccessfulCandidate);

                if ((interviewResponse && applicationResponse))
                {
                    if (successfulCandidate != null)
                    {
                        return Ok(false);
                    }
                }
                return Ok(interviewId);
            }
            else
            {
                return BadRequest();
            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
        }

        [HttpPut]
        [Route("FailInterview/{interviewId:guid}")]
        public async Task<IActionResult> BrowseFailInterview(Guid interviewId)
        {
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (interviewId == null)
            {
                return BadRequest();
            }
            else
            {
                // Update Interview status
                var interviewResponse = await _interviewService.UpdateStatusInterview(interviewId,
                    null,
                    (int)Interview_CompanyStatus.Failed);

                //var thisInterview = await _interviewService.GetInterviewById_noInclude(interviewId);

                // Update Application status
                var applicationResponse = true;
                //var applicationResponse = await _applicationService.UpdateStatusApplication(thisInterview!.ApplicationId, null, null);

                if (interviewResponse && applicationResponse != true)
                {
                    Ok(false);
                }

                return Ok(interviewId);
            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
        }

        [HttpGet]
        [Route("Blacklist/{userId}")]
        public async Task<IActionResult> GetUserInBlacklist(string userId)
        {
            var respone = await _authenticationService.GetUserInBlacklistById(userId);
            if (respone != null)
            {
                return Ok(respone);
            }
            else { return BadRequest("This user is not on the Blacklist"); }
        }

        [HttpGet]
        [Route("Profile/{userId}")]
        public async Task<IActionResult> GetAccount(string userId)
        {
            var response = await _authenticationService.GetAccountByUserId(userId);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("This user is not on the System");
        }

        [HttpGet]
        [Route("Recruiter/{userId}")]
        public async Task<IActionResult> GetRecruiter(string userId)
        {
            var response = await _authenticationService.GetAccountByUserId(userId);
            if (response == null)
                return BadRequest("This user is not on the System");
            else if (response.Recruiters.FirstOrDefault() == null)
                return BadRequest("This user is not on the Recruiterlist");
            else return Ok(response);
        }

        [HttpGet]
        [Route("Interviewer/{userId}")]
        public async Task<IActionResult> GetInterviewer(string userId)
        {
            var response = await _authenticationService.GetAccountByUserId(userId);
            if (response == null)
                return BadRequest("This user is not on the System");
            else if (response.Recruiters.FirstOrDefault() == null)
                return BadRequest("This user is not on the Interviewerlist");
            else return Ok(response);
        }

        [HttpGet]
        [Route("Candidate/{userId}")]
        public async Task<IActionResult> GetAllCandidate(string userId)
        {
            var response = await _authenticationService.GetAccountByUserId(userId);
            if (response == null)
                return BadRequest("This user is not on the System");
            else if (response.Recruiters.FirstOrDefault() == null)
                return BadRequest("This user is not on the Candidatelist");
            else return Ok(response);
        }

        #region Comment

        //[HttpPost]
        //[Route("Create")]
        //public async Task<IActionResult> Create([FromBody] SignUp signUp, string role)
        //{
        //    // Check if user already exists
        //    var userExist = await _userManager.FindByEmailAsync(signUp.Email);
        //    if (userExist != null)
        //    {
        //        return StatusCode(StatusCodes.Status403Forbidden,
        //            new Response { Status = "Error", Message = "User already exists!" });
        //    }

        //    // Create a new WebUser instance
        //    var user = new WebUser
        //    {
        //        Email = signUp.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = signUp.Username,
        //        FullName = signUp.FullName,
        //    };

        //    // Create the user
        //    var result = await _userManager.CreateAsync(user, signUp.Password);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError,
        //                new Response { Status = "Error", Message = $"Error: {error.Description}" });
        //        }
        //    }

        //    // Check if role is valid and exists
        //    if (string.IsNullOrEmpty(role))
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            new Response { Status = "Error", Message = "Role is null or empty." });
        //    }

        //    // Check if the specified role exists
        //    if (!await _roleManager.RoleExistsAsync(role))
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            new Response { Status = "Error", Message = "This Role Does Not Exist." });
        //    }

        //    // Add the specified role to the user
        //    await _userManager.AddToRoleAsync(user, role);

        //    // Generate an email confirmation token
        //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        //    // Create the corresponding interviewer/recruiter record in the database
        //    if (role == "Interviewer")
        //    {
        //        await _authenticationService.CreateInterviewer(user.Id, signUp.CompanyId);
        //    }
        //    else if (role == "Recruiter")
        //    {
        //        await _authenticationService.CreateRecruiter(user.Id, signUp.CompanyId);
        //    }

        //    // Save changes to the database
        //    await _dbContext.SaveChangesAsync();

        //    // Send email confirmation link
        //    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
        //    var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink);
        //    _emailService.SendEmail(message);

        //    return StatusCode(StatusCodes.Status200OK,
        //        new Response { Status = "Success", Message = $"User created & email sent to {user.Email} Successfully." });
        //}
        //private async Task<IActionResult> ConfirmEmail(string token, string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user != null)
        //    {
        //        var result = await _userManager.ConfirmEmailAsync(user, token);
        //        if (result.Succeeded)
        //        {
        //            return StatusCode(StatusCodes.Status200OK,
        //            new Response { Status = "Success", Message = "Email Verified Successfully" });
        //        }
        //    }
        //    return StatusCode(StatusCodes.Status500InternalServerError,
        //           new Response { Status = "Error", Message = "This User Does Not Exist" });
        //}

        #endregion Comment
    }
}