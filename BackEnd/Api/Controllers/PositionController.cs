using Api.ViewModels.Position;
using AutoMapper;
using Castle.Core.Internal;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class PositionController : BaseAPIController
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(UserManager<WebUser> userManager, IPositionService positionService, IMapper mapper)
        {
            _userManager = userManager;
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Recruiter,Admin")]
        public async Task<IActionResult> AddPosition(PositionAddModel position)
        {
            var newModelData = _mapper.Map<PositionModel>(position);
            var response = await _positionService.AddPosition(newModelData);
            return response is not null ? Ok(response) : BadRequest(position);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPositions(Guid? companyId)
        {
            List<PositionModel> listModelDatas = await _positionService.GetAllPositions(companyId);
            List<PositionViewModel> response = _mapper.Map<List<PositionViewModel>>(listModelDatas);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter,Admin")]
        [Route("CurrentUser")]
        public async Task<IActionResult> GetAllPositionsByCurrentUser()
        {
            var userName = HttpContext.User.Identity!.Name;
            var user = await _userManager.FindByNameAsync(userName);
            List<PositionModel> listModelDatas = await _positionService.GetAllPositionsByCurrentUser(user.Id);
            List<PositionViewModel> response = _mapper.Map<List<PositionViewModel>>(listModelDatas);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPositionById(Guid positionId)
        {
            var modelData = await _positionService.GetPositionById(positionId);
            var response = _mapper.Map<PositionViewModel>(modelData);

            return response is not null ? Ok(response) : NotFound(positionId);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPositionByName(string positionName)
        {
            var modelDatas = await _positionService.GetPositionByName(positionName);
            var response = _mapper.Map<List<PositionViewModel>>(modelDatas);

            return !response.IsNullOrEmpty() ? Ok(response) : NoContent();
        }

        [HttpDelete("{positionId:guid}")]
        [Authorize(Roles = "Recruiter,Admin")]
        public async Task<IActionResult> RemovePosition(Guid positionId)
        {
            var response = await _positionService.RemovePosition(positionId);
            return response is true ? Ok(true) : NotFound();
        }

        [HttpPut("{positionId:guid}")]
        [Authorize(Roles = "Recruiter,Admin")]
        public async Task<IActionResult> UpdatePosition(PositionUpdateModel position, Guid positionId)
        {
            var updateModelData = _mapper.Map<PositionModel>(position);
            var response = await _positionService.UpdatePosition(updateModelData, positionId);
            return response is true ? Ok(true) : Ok(false);
        }
    }
}