using Api.ViewModels.CategoryPosition;
using Api.ViewModels.Skill;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CategoryPositionController : BaseAPIController
    {
        private readonly ICategoryPositionService _categoryPositionService;
        private readonly IMapper _mapper;

        public CategoryPositionController(ICategoryPositionService categoryPositionService,
            IMapper mapper)
        {
            _categoryPositionService = categoryPositionService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCategoryPositions()
        {

            var isAdmin = HttpContext.User.IsInRole("Admin");
            var listModelDatas = await _categoryPositionService.GetAllCategoryPositions(isAdmin);
            var response = _mapper.Map<List<CategoryPositionViewModel>>(listModelDatas);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategoryPosition(CategoryPositionAddModel request)
        {
            var modelData = _mapper.Map<CategoryPositionModel>(request);
            var response = await _categoryPositionService.CreateCategoryPosition(modelData);
            if (response != null)
            {
                return Ok(_mapper.Map<CategoryPositionViewModel>(response));
            }
            return BadRequest();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCategoryPosition(CategoryPositionUpdateModel categoryPositionUpdateModel, Guid id)
        {
            var model = _mapper.Map<CategoryPositionModel>(categoryPositionUpdateModel);
            var isSuccess = await _categoryPositionService.UpdateCategoryPosition(model, id);
            return Ok(isSuccess);
        }
    }
}