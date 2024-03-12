using Api.ViewModels.Position;
using AutoMapper;
using Castle.Core.Internal;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class PositionController : BaseAPIController
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public PositionController(IPositionService positionService, IMapper mapper, IFileService fileService)
        {
            _positionService = positionService;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Recruiter,Admin")]
        public async Task<IActionResult> AddPosition([FromForm] PositionAddModel positionAddModel)
        {
            var positionModel = _mapper.Map<PositionModel>(positionAddModel);

            if (positionAddModel.ImageFile != null)
            {
                var imageUploadResult = await _fileService.AddFileAsync(positionAddModel.ImageFile);
                positionModel.ImageURL = imageUploadResult.Url.OriginalString;
            }



            var response = await _positionService.AddPosition(positionModel);
            return response is not null ? Ok(response) : BadRequest(positionAddModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPositions(Guid? companyId)
        {
            var isAdmin = HttpContext.User.IsInRole("Admin") ? true : false;
            List<PositionModel> listModelDatas = await _positionService.GetAllPositions(companyId, isAdmin);
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
        public async Task<IActionResult> UpdatePosition([FromForm] PositionUpdateModel positionUpdateModel, 
            Guid positionId)
        {
            var positionModel = _mapper.Map<PositionModel>(positionUpdateModel);
            if (positionUpdateModel.ImageFile != null)
            {
                var oldModel = await _positionService.GetPositionById(positionId);
                if (oldModel.ImageURL != null)
                {
                    var oldImageUploadResult = await _fileService.DeleteFileAsync(oldModel.ImageURL);
                }

                var newImageUploadResult = await _fileService.AddFileAsync(positionUpdateModel.ImageFile);
                positionModel.ImageURL = newImageUploadResult.Url.OriginalString;
            }
            var response = await _positionService.UpdatePosition(positionModel, positionId);
            return response is true ? Ok(true) : Ok(false);
        }
    }
}