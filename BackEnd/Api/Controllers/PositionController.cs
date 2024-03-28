using Api.Paging;
using Api.ViewModels.Position;
using AutoMapper;
using Castle.Core.Internal;
using Data.CustomModel.Position;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PagedList;
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
        public async Task<IActionResult> AddPosition(PositionAddModel positionAddModel)
        {
            var positionModel = _mapper.Map<PositionModel>(positionAddModel);
            var response = await _positionService.AddPosition(positionModel);
            return response is not null ? Ok(response) : BadRequest(positionAddModel);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMinMaxRange()
        {
            var response = await _positionService.GetAllMinMaxRange();
            return response is not null ? Ok(response) : NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPositions
            (
            [FromQuery] PositionFilterModel positionFilterModel,
            string? sortString = "PositionName_ASC", 
            int? pageIndex = 1, 
            int? pageSize = 20
            )
        {

            var filter = _mapper.Map<PositionFilter>(positionFilterModel);
            filter.CompanyIds = positionFilterModel.getListOfCompanyIds();
            filter.CategoryPositionIds = positionFilterModel.getListOfCategoryPositionIds();
            filter.LanguageIds = positionFilterModel.getListOfLanguageIds();

            var listModelDatas = await _positionService.GetAllPositions(filter, sortString);

            var listPositionViewModel = _mapper.Map<List<PositionViewModel>>(listModelDatas);

            var isAdmin = HttpContext.User.IsInRole("Admin") ? true : false;
            if (!isAdmin)
                listPositionViewModel.Where(o => o.IsDeleted == false);

            var pageResponse = new PageResponse<PositionViewModel>(
                listPositionViewModel.ToPagedList(pageIndex.Value, pageSize.Value)
                );

            return Ok(pageResponse);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
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
        public async Task<IActionResult> UpdatePosition(PositionUpdateModel positionUpdateModel, Guid positionId)
        {
            var positionModel = _mapper.Map<PositionModel>(positionUpdateModel);
            var response = await _positionService.UpdatePosition(positionModel, positionId);
            return response is true ? Ok(true) : Ok(false);
        }
    }
}