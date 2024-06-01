using Api.ViewModels.Candidate;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CandidateController : BaseAPIController
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        private readonly UserManager<WebUser> _userManager;
        private readonly RecruitmentWebContext _dbContext;

        public CandidateController(
            ICandidateService candidateService,
            UserManager<WebUser> userManager,
            RecruitmentWebContext dbcontext,
            IMapper mapper)
        {
            _candidateService = candidateService;
            _userManager = userManager;
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCandidates()
        {
            var modelDatas = await _candidateService.GetAllCandidates();
            var response = _mapper.Map<List<CandidateViewModel>>(modelDatas);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveCandidate(CandidateAddModel request)
        {
            if (request == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var modelData = _mapper.Map<CandidateModel>(request);
            var response = await _candidateService.SaveCandidate(modelData);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCandidate(Guid requestId)
        {
            if (requestId.Equals(Guid.Empty))
            {
                return BadRequest();
            }
            var response = await _candidateService.DeleteCandidate(requestId);
            if (response == true)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCandidate(CandidateUpdateModel request, Guid requestId)
        {
            //if (request.CandidateId != requestId)
            //{
            //    return BadRequest();
            //}

            var modelData = _mapper.Map<CandidateModel>(request);
            var response = await _candidateService.UpdateCandidate(modelData, requestId);
            if (response == true)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{candidateId:guid}")]
        public async Task<IActionResult> GetProfiles(Guid candidateId)
        {
            //var response = await _candidateService.GetProfile(candidateId);
            var isAdmin = HttpContext.User.IsInRole("Admin");
            var modelData = await _candidateService.FindById(candidateId, isAdmin);
            var response = _mapper.Map<CandidateViewModel>(modelData);

            if (response == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok(response);
        }

        [HttpPut("[action]/{userId}")]
        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> UpdateCandidateProfile(string userId, UpdatePersonalProfile data)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.FullName = data.Fullname;
            user.Title = data.Title;
            user.PhoneNumber = data.PhoneNumber;
            user.Email = data.Email;
            user.PersonalLink = data.PersonalLink;
            user.DateOfBirth = data.Dob;
            user.Gender = data.Gender;
            user.City = data.City;
            user.Address = data.Address;
            var resp = await _userManager.UpdateAsync(user);
            if (!resp.Succeeded)
            {
                return BadRequest();
            }
            return Ok(user);
        }
    }
}