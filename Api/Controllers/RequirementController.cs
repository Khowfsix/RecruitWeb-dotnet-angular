using Api.ViewModels.Requirement;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class RequirementController : BaseAPIController
    {
        private readonly IRequirementService _reportService;
        private readonly IMapper _mapper;

        public RequirementController(IRequirementService reportService,
            IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequirement()
        {
            var reportList = await _reportService.GetAllRequirement();
            List<RequirementViewModel> result = new List<RequirementViewModel>();
            foreach (var report in reportList)
            {
                result.Add(_mapper.Map<RequirementViewModel>(report));
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveRequirement(RequirementAddModel request)
        {
            var model = _mapper.Map<RequirementModel>(request);
            var reportList = await _reportService.SaveRequirement(model);
            return Ok(reportList);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateRequirement(RequirementUpdateModel request, Guid id)
        {
            var model = _mapper.Map<RequirementModel>(request);
            var reportList = await _reportService.UpdateRequirement(model, id);
            return Ok(reportList);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteRequirement(Guid id)
        {
            var reportList = await _reportService.DeleteRequirement(id);
            return Ok(reportList);
        }
    }
}