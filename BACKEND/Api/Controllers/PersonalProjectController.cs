using Api.ViewModels.AdminPersonalProject;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class PersonalProjectController : BaseAPIController
    {
        private readonly IPersonalProjectService _personalProjectService;
        private readonly IMapper _mapper;

        public PersonalProjectController(IPersonalProjectService personalProjectService,
            IMapper mapper)
        {
            _personalProjectService = personalProjectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonalProjects()
        { 
            var listModelDatas = await _personalProjectService.GetAllPersonalProjects();
            var response = _mapper.Map<List<PersonalProjectViewModel>>(listModelDatas);
            return Ok(response);
        }
    }
}