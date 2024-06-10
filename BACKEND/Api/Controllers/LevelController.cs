using Api.ViewModels.Level;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class LevelController : BaseAPIController
    {
        private readonly ILevelService _levelService;
        private readonly IMapper _mapper;

        public LevelController(ILevelService levelService,
            IMapper mapper)
        {
            _levelService = levelService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLevels()
        { 
            var isAdmin = HttpContext.User.IsInRole("Admin");
            var listModelDatas = await _levelService.GetAllLevels(isAdmin);
            var response = _mapper.Map<List<LevelViewModel>>(listModelDatas);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateLevel(LevelAddModel request)
        {
            var modelData = _mapper.Map<LevelModel>(request);
            var response = await _levelService.CreateLevel(modelData);
            if (response != null)
            {
                return Ok(_mapper.Map<LevelViewModel>(response));
            }
            return BadRequest();
        }
    }
}