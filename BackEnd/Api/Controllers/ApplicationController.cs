using Api.ViewModels.Application;
using AutoMapper;
using Data.CustomModel.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class ApplicationController : BaseAPIController
    {
        private readonly IApplicationService _applicationService;
        private readonly IPositionService _positionService;
        private readonly IRecruiterService _recruiterService;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IPositionService positionService, IRecruiterService recruiterService, IMapper mapper)
        {
            _applicationService = applicationService;
            _positionService = positionService;
            _recruiterService = recruiterService;
            _mapper = mapper;
        }
            
        [HttpGet]
        public async Task<IActionResult> GetAllApplications([FromQuery] ApplicationFilterModel applicationFilterModel, int? status, int? priority, Guid? positionId, string? sortString = "CreatedTime_DESC")
        {
            if (positionId.HasValue)
            {
                var userName = HttpContext.User.Identity!.Name;
                var foundPosition = await _positionService.GetPositionById(positionId.Value);
                var foundRecruiter = await _recruiterService.GetRecruiterById(foundPosition.RecruiterId);
                if (!HttpContext.User.IsInRole("Admin")){
                    if (userName != foundRecruiter!.User.UserName)
                    {
                        return Ok("Not found");
                    }
                }
                var filterModel = _mapper.Map<ApplicationFilter>(applicationFilterModel);
                var isAdmin = HttpContext.User.IsInRole("Admin");
                var models = await _applicationService.GetAllApplicationsByPositionId(positionId.Value, filterModel, sortString, isAdmin);

                var response = _mapper.Map<List<ApplicationViewModel>>(models);
                return Ok(response);
            }

            if (!status.HasValue && !priority.HasValue)
            {
                var modelDatas = await _applicationService.GetAllApplications();
                var response = _mapper.Map<List<ApplicationViewModel>>(modelDatas);
                return Ok(response);
            }
            else
            {
                var modelDatas = await _applicationService.GetApplicationsWithStatus(
                    (int)status,
                    (int)priority
                );
                var response = _mapper.Map<List<ApplicationViewModel>>(modelDatas);
                return Ok(response);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetApplicationById(Guid id)
        {
            ApplicationModel? modelDatas = await _applicationService.GetApplicationById(id);
            if (modelDatas == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var response = _mapper.Map<ApplicationViewModel>(modelDatas);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> SaveApplication(ApplicationAddModel request)
        {
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var modelData = _mapper.Map<ApplicationModel>(request);
            var response = await _applicationService.SaveApplication(modelData);
            return Ok(_mapper.Map<ApplicationModel>(response));
        }

        [HttpPut("{requestId:guid}")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> UpdateApplication(
            ApplicationUpdateModel request,
            Guid requestId
        )
        {
            if (request == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var modelData = _mapper.Map<ApplicationModel>(request);
            var response = await _applicationService.UpdateApplication(modelData, requestId);
            return Ok(response);
        }

        [HttpPut("[action]/{ApplicationId:guid}")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> UpdateStatusApplication(
            Guid ApplicationId,
            int? Candidate_Status,
            int? Company_Status
        )
        {
            if (Candidate_Status == null && Company_Status == null)
                return StatusCode(StatusCodes.Status400BadRequest);

            //var applicationNewStatus = await _applicationService.GetApplicationById(ApplicationId);

            //if (applicationNewStatus == null)
            //{
            //    return BadRequest();
            //}

            var response = await _applicationService.UpdateStatusApplication(ApplicationId, Candidate_Status, Company_Status);
            return Ok(response);
        }

        [HttpDelete("{applicationId:guid}")]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> DeleteApplication(Guid applicationId)
        {
            if (applicationId.Equals(Guid.Empty))
                return StatusCode(StatusCodes.Status400BadRequest);
            var response = await (_applicationService.DeleteApplication(applicationId));
            return Ok(response);
        }
    }
}