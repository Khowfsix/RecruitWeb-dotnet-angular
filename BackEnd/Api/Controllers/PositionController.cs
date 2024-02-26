using Api.ViewModels.Position;
using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class PositionController : BaseAPIController
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
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
        public async Task<IActionResult> GetAllPositions(Guid? departmentId)
        {
            List<PositionModel> listModelDatas = await _positionService.GetAllPositions(departmentId);
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