using Api.ViewModels;
using Api.ViewModels.Admin;
using Api.ViewModels.Authentication.LogIn;
using Api.ViewModels.Authentication.SignUp;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Api.Controllers
{
    [Authorize]
    public class AuthenticationController : BaseAPIController
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RecruitmentWebContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authenticationService;
        private readonly IFileService _uploadFileService;
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public AuthenticationController(
            UserManager<WebUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailService emailService,
            ICandidateService candidateService,

            SignInManager<WebUser> signInManager,
            IAuthService authenticationService,
            IConfiguration configuration,

            IHttpContextAccessor httpContextAccessor,
            RecruitmentWebContext dbContext,

            IFileService uploadFileService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _configuration = configuration;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _authenticationService = authenticationService;
            _uploadFileService = uploadFileService;
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] Register signUp)
        {
            var userName = HttpContext.User.Identity!.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                return BadRequest("Please logout your account");
            }
            string role = "Candidate";
            //Check User Exist
            //Console.WriteLine("exist");
            var userExist = await _userManager.FindByEmailAsync(signUp.Email);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User already exists!" });
            }

            //Add the User in the database
            var user = new WebUser()
            {
                Email = signUp.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUp.Username,
                FullName = signUp.FullName,
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                //create user
                var result = await _userManager.CreateAsync(user, signUp.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = $"Error: {error.Description}" });
                    }
                }

                //check if user == null
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        new Response { Status = "Error", Message = "User not found." });
                }

                //check if role == null
                if (string.IsNullOrEmpty(role))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "Role is null or empty." });
                }

                //Add role to the user
                await _userManager.AddToRoleAsync(user, role);

                //Add Token to Verify the email...
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _dbContext.SaveChangesAsync();

                //send email confirm
                await ConfirmEmail(token, signUp.Email!);
                SendEmailConfirmation(user.Email!, token);

                //create candidate in database
                await _authenticationService.CreateCandidate(user.Id);
                return StatusCode(StatusCodes.Status200OK,
                    new Response { Status = "Success", Message = $"User created & email sent to {user.Email} Successfully." });
            }
            else
            {
                Console.WriteLine("error");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "This Role Does Not Exist." });
            }
        }

        //todo: fix confirm email
        private void SendEmailConfirmation(string emailUser, string token)
        {
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = emailUser }, Request.Scheme);
            var message = new Message(new string[] { emailUser! }, "Confirmation email link", confirmationLink!);

            // Send the confirmation email
            _emailService.SendEmail(message);
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            // Get the user based on the provided email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = "User not found." });
            }
            /*
            // Generate the email confirmation link
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);

            // Send the confirmation email
            _emailService.SendEmail(message);
            */

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "This User Does Not Exist" });
                }
            }
            return StatusCode(StatusCodes.Status200OK,
                   new Response { Status = "Success", Message = "Email Verified Successfully" });
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LogInModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(userName: loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user: user, password: loginModel.Password))
            {
                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.UserName),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                //get roles
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                if (user.TwoFactorEnabled)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
                    var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

                    var message = new Message(new string[] { user.Email! }, "OTP Confrimation", token);
                    _emailService.SendEmail(message);

                    return StatusCode(StatusCodes.Status200OK,
                     new Response { Status = "Success", Message = $"We have sent an OTP to your Email {user.Email}" });
                }

                var jwtToken = GetToken(authClaims);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo,
                });
                //returning the token...
            }

            return Unauthorized("Wrong password or username");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("RefreshToken")]
        public IActionResult RefreshToken()
        {
            var token = HttpContext.Request.Cookies["refreshToken"];
            var identityUser = _dbContext.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));

            // Get existing refresh token if it is valid and revoke it
            var existingRefreshToken = GetValidRefreshToken(token!, identityUser!);
            if (existingRefreshToken == null)
            {
                return new BadRequestObjectResult(new { Message = "Failed" });
            }

            existingRefreshToken.RevokedByIp = HttpContext.Connection.RemoteIpAddress!.ToString();
            existingRefreshToken.RevokedOn = DateTime.UtcNow;

            // Generate new tokens
            //var newToken = GetToken(identityUser);
            var newToken = GenerateTokens(identityUser!);
            return Ok(new { Token = newToken, Message = "Success" });
        }

        [HttpPost]
        [Route("RevokeToken")]
        public IActionResult RevokeToken(string token)
        {
            // If user found, then revoke
            if (RevokeRefreshToken(token))
            {
                return Ok(new { Message = "Success" });
            }

            // Otherwise, return error
            return new BadRequestObjectResult(new { Message = "Failed" });
        }

        [HttpPost]
        [Route("Login-2FA")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithOTP(string code, string username)
        {
            //get uset
            var user = await _userManager.FindByNameAsync(username);
            //enable twofacter
            //user.TwoFactorEnabled = true;
            var signIn = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);
            if (signIn.Succeeded)
            {
                if (user != null)
                {
                    var authClaims = new List<Claim>
                    {
                        new(ClaimTypes.Name, user.UserName),
                        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    var userRoles = await _userManager.GetRolesAsync(user);
                    foreach (var role in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var jwtToken = GetToken(authClaims);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                        expiration = jwtToken.ValidTo
                    });
                    //returning the token...
                }
            }
            return StatusCode(StatusCodes.Status404NotFound,
                new Response { Status = "Success", Message = $"Invalid Code" });
        }

        [Authorize]
        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = $"User does not exist" });
            }
            if (string.Compare(model.NewPassword, model.ConfirmPassword) != 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Response { Status = "Error", Message = $"The new password and the password confirm do not match." });
            }
            var resetPassResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (!resetPassResult.Succeeded)
            {
                var errors = new List<string>();
                foreach (var error in resetPassResult.Errors)
                {
                    errors.Add(error.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = string.Join(", ", errors) });
            }
            return Ok(new Response { Status = "Success", Message = "Password successfully changed" });
        }

        [HttpPost]
        [Route("SendForgotPasswordCode")]
        [AllowAnonymous]
        public async Task<IActionResult> SendForgotPasswordCode(string email)
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

            int otp = GenerateOTP(); // Implement this method to generate a random OTP

            var resetPassword = new ResetPassword
            {
                UserId = user.Id,
                OTP = otp.ToString(),
                InsertDateTimeUTC = DateTime.UtcNow
            };

            _dbContext.ResetPasswords.Add(resetPassword);
            await _dbContext.SaveChangesAsync();

            // Send the OTP to the user's email
            var message = new Message(new string[] { user.Email }, "Reset Password OTP}", $"OTP: {otp}");
            _emailService.SendEmail(message);

            return Ok(new { Status = "Success", Message = "OTP sent successfully" });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email, string otp, string newPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(otp) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest("Email, OTP, and New Password should not be null or empty");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var resetPasswordDetails = await _dbContext.ResetPasswords
                .Where(rp => rp.OTP == otp && rp.UserId == user.Id)
                .OrderByDescending(rp => rp.InsertDateTimeUTC)
                .FirstOrDefaultAsync();

            if (resetPasswordDetails == null)
            {
                return BadRequest("Invalid OTP");
            }

            // Verify if OTP is expired (15 minutes in this example)
            if (resetPasswordDetails.InsertDateTimeUTC.AddMinutes(15) < DateTime.UtcNow)
            {
                return BadRequest("OTP is expired, please request a new one");
            }

            // Reset the user's password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
            {
                return BadRequest("Failed to reset the password");
            }

            // Delete the used OTP from the database
            _dbContext.ResetPasswords.Remove(resetPasswordDetails);
            await _dbContext.SaveChangesAsync();

            return Ok(new { Status = "Success", Message = $"Password reset successfully! Your new password: {newPassword}" });
        }

        [Authorize]
        [HttpPut]
        [Route("Update-Profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfileModel model, bool twoFa)
        {
            // Get the current user
            var userName = HttpContext.User.Identity!.Name;
            var userId = await _authenticationService.GetCurrentUserId(userName!);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                // Handle the case when the user is not found
                return StatusCode(StatusCodes.Status404NotFound,
                    new Response { Status = "Error", Message = "User does not exist" });
            }

            // Update user's profile properties with the provided values
            user.PhoneNumber = model.PhoneNumber;
            user.FullName = model.FullName;
            user.Address = model.Address;
            user.DateOfBirth = model.DateOfBirth;
            user.TwoFactorEnabled = twoFa;

            var image = await _uploadFileService.AddFileAsync(model.ImageFile!);

            user.ImageURL = image.Url.ToString();

            IdentityResult result = await _userManager.UpdateAsync(user);
            await _dbContext.SaveChangesAsync();

            if (result.Succeeded)
            {
                await Logout();

                //await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new { Message = "Profile updated successfully!" });
            }
            else
            {
                // Handle the case when the update fails
                return BadRequest(new { Message = "Failed to update profile." });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(); ;
        }

        [Authorize]
        [HttpGet("UserId")]
        public async Task<IActionResult> GetIdCurrent()
        {
            var userName = HttpContext.User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                return Ok(new
                {
                    userId = user.Id,
                    userName = user.UserName,
                    phone = user.PhoneNumber
                });
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("GetId")]
        public async Task<IActionResult> GetUserId()
        {
            var userName = HttpContext.User.Identity!.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var response = await _authenticationService.GetCurrentUserId(userName);
                return Ok(response);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("UserLogin")]
        public async Task<IActionResult> GetUserLogin()
        {
            var userName = HttpContext.User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var viewModelResponse = _mapper.Map<WebUserViewModel>(user);
                return Ok(viewModelResponse);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var candidateVM = await _candidateService.GetCandidateByUserId(userId);
            var candidateModel = _mapper.Map<CandidateModel>(candidateVM);
            var candidate = _mapper.Map<Candidate>(candidateModel);
            var listCandidate = new List<Candidate>
            {
                candidate
            };
            if (candidate != null)
            {
                user.Candidates = listCandidate;
            }

            //var userRole = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                var viewModelResponse = _mapper.Map<WebUserViewModel>(user);
                return Ok(viewModelResponse);
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("Profile/{userId}")]
        public async Task<IActionResult> GetProfileById(string userId)
        {
            var response = await _authenticationService.GetAccountByUserId(userId);
            if (response != null)
            {
                var viewModelResponse = _mapper.Map<WebUserViewModel>(response);
                return Ok(response);
            }
            else
                return BadRequest("This user is not on the System");
        }

        [Authorize]
        [HttpGet("Profile/All")]
        public async Task<IActionResult> GetAllProfile()
        {
            var response = await _authenticationService.GetAllSystemAccount();
            if (response != null)
            {
                //todo : system account
                var viewModelResponse = _mapper.Map<List<WebUserViewModel>>(response); //List<WebUser>>
                return Ok(viewModelResponse);
            }
            else
                return BadRequest("No user on the System");
        }

        [Authorize]
        [HttpGet("Role")]
        public async Task<IActionResult> GetRoleCurrent()
        {
            var userName = HttpContext.User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(userName);
            var userRole = await _userManager.GetRolesAsync(user);
            if (user != null)
            {
                return Ok(new { role = userRole });
            }
            return NotFound();
        }

        private static int GenerateOTP()
        {
            // Create an instance of the Random class
            Random random = new();

            // Generate a random 6-digit OTP (from 100000 to 999999)
            int otp = random.Next(100000, 999999);

            // Convert the OTP to a string and return it
            return otp;
        }

        private static RefreshToken GetValidRefreshToken(string token, WebUser identityUser)
        {
            if (identityUser == null)
            {
                return null!;
            }

            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            return IsRefreshTokenValid(existingToken!) ? existingToken! : null!;
        }

        private bool RevokeRefreshToken(string token = null!)
        // Revokes the refresh token for the given user.
        // If no token is provided, the token from the HttpContext.Request.Cookies["refreshToken"] is used.
        // Returns true if the token is successfully revoked, otherwise false.
        {
            token = token == null! ? HttpContext.Request.Cookies["refreshToken"]! : token!;
            var identityUser = _dbContext.Users.Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token && y.UserId == x.Id));
            if (identityUser == null)
            {
                return false;
            }

            // Revoke Refresh token
            var existingToken = identityUser.RefreshTokens.FirstOrDefault(x => x.Token == token);
            existingToken!.RevokedByIp = HttpContext.Connection.RemoteIpAddress!.ToString();
            existingToken!.RevokedOn = DateTime.UtcNow;
            _dbContext.Update(identityUser);
            _dbContext.SaveChanges();
            return true;
        }

        private async Task<WebUser> ValidateUser(LogInModel loginData)
        {
            var identityUser = await _userManager.FindByNameAsync(loginData.Username);
            if (identityUser != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, loginData.Password);
                return result == PasswordVerificationResult.Failed ? null! : identityUser!;
            }

            return null!;
        }

        private string GenerateTokens(WebUser identityUser)
        {
            // Generate access token
            string accessToken = GenerateAccessToken(identityUser);

            // Generate refresh token and set it to cookie
            var ipAddress = HttpContext.Connection.RemoteIpAddress!.ToString();
            var refreshToken = GenerateRefreshToken(ipAddress, identityUser.Id);

            // Set Refresh Token Cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            // Save refresh token to database
            identityUser.RefreshTokens ??= new List<RefreshToken>();

            identityUser.RefreshTokens.Add(refreshToken);
            _dbContext.Update(identityUser);
            _dbContext.SaveChanges();
            return accessToken;
        }

        private string GenerateAccessToken(WebUser identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSetting = _configuration.GetSection("JWT");
            //var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
              new Claim(ClaimTypes.Name, identityUser.UserName.ToString()),
              new Claim(ClaimTypes.Email, identityUser.Email)
                }),

                //Expires = DateTime.Now.AddSeconds(jwtBearerTokenSettings.ExpiryTimeInSeconds),
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                //Audience = jwtBearerTokenSettings.Audience,
                //Issuer = jwtBearerTokenSettings.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress, string userId)
        {
            using RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                //ExpiryOn = DateTime.UtcNow.AddDays(jwtBearerTokenSettings.RefreshTokenExpiryInDays),
                CreatedOn = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserId = userId
            };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims, int expireTime = 1)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT: ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(expireTime),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        // Check if the refresh token is valid based on its properties and return a boolean value.
        private static bool IsRefreshTokenValid(RefreshToken existingToken)
        {
            // Is token already revoked, then return false
            if (existingToken.RevokedByIp != null && existingToken.RevokedOn != DateTime.MinValue)
            {
                return false;
            }

            // Token already expired, then return false
            if (existingToken.ExpiryOn <= DateTime.UtcNow)
            {
                return false;
            }

            return true;
        }
    }
}
