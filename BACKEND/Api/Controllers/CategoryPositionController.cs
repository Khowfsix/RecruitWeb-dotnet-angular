using Api.ViewModels.CategoryPosition;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCategoryPositions()
        {
            var listModelDatas = await _categoryPositionService.GetAllCategoryPositions();
            var response = _mapper.Map<List<CategoryPositionViewModel>>(listModelDatas);
            return Ok(response);
        }
    }
}
