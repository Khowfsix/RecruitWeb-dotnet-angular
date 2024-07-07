using Api.ViewModels.AdminEducation;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class EducationController : BaseAPIController
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(IEducationService EducationService,
            IMapper mapper)
        {
            _educationService = EducationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEducations()
        { 
            var listModelDatas = await _educationService.GetAllEducations();
            var response = _mapper.Map<List<EducationViewModel>>(listModelDatas);
            return Ok(response);
        }
    }
}