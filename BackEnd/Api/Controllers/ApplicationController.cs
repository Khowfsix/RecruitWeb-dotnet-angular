using Api.ViewModels.Application;
using AutoMapper;
using Data.CustomModel.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class ApplicationController : BaseAPIController
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplications([FromQuery] ApplicationFilterModel applicationFilterModel, string? status, string? priority, Guid? positionId, string? sortString = "DateTime_DESC")
        {
            if (positionId.HasValue)
            {
                var filterModel = _mapper.Map<ApplicationFilter>(applicationFilterModel);
                var models = await _applicationService.GetAllApplicationsByPositionId(positionId.Value, filterModel, sortString);
                var response = _mapper.Map<List<ApplicationViewModel>>(models);
                return Ok(response);
            }

            if (string.IsNullOrEmpty(status) && string.IsNullOrEmpty(priority))
            {
                var modelDatas = await _applicationService.GetAllApplications();
                var response = _mapper.Map<List<ApplicationViewModel>>(modelDatas);
                return Ok(response);
            }
            else
            {
                var modelDatas = await _applicationService.GetApplicationsWithStatus(
                    status!,
                    priority!
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
            string? Candidate_Status,
            string? Company_Status
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