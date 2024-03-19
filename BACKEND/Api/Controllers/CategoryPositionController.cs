using Api.ViewModels.CategoryPosition;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var listModelDatas = await _categoryPositionService.GetAllCategoryPositions();
            var response = _mapper.Map<List<CategoryPositionViewModel>>(listModelDatas);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize("Admin")]
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
    }
}