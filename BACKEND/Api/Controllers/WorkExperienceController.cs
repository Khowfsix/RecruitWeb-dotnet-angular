using Api.ViewModels.AdminWorkExperience;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class WorkExperienceController : BaseAPIController
    {
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IMapper _mapper;

        public WorkExperienceController(IWorkExperienceService workExperienceService,
            IMapper mapper)
        {
            _workExperienceService = workExperienceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkExperiences()
        { 
            var listModelDatas = await _workExperienceService.GetAllWorkExperiences();
            var response = _mapper.Map<List<WorkExperienceViewModel>>(listModelDatas);
            return Ok(response);
        }
    }
}