using Api.ViewModels.CategoryQuestion;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CategoryQuestionController : BaseAPIController
    {
        private readonly ICategoryQuestionService _categoryQuestionService;
        private readonly IMapper _mapper;

        public CategoryQuestionController(ICategoryQuestionService categoryQuestionService, IMapper mapper)
        {
            _categoryQuestionService = categoryQuestionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryQuestions(Guid? id, string? name, double? weight)
        {
            if (id != null)
            {
                var categoryQuestion = await _categoryQuestionService.GetCategoryQuestionById((Guid)id);
                if (categoryQuestion == null)
                {
                    return Ok("Not found");
                }
                var response_id = _mapper.Map<CategoryQuestionViewModel>(categoryQuestion);
                return Ok(response_id);
            }
            else if (name != null)
            {
                var listCategoryQuestionbyName = await _categoryQuestionService.GetCategoryQuestionsByName(name);
                if (listCategoryQuestionbyName == null)
                {
                    return Ok("Not found");
                }

                var response_name = _mapper.Map<List<CategoryQuestionViewModel>>(listCategoryQuestionbyName);
                return Ok(response_name);
            }
            else if (weight != null)
            {
                var listCategoryQuestionByWeight = await _categoryQuestionService.GetCategoryQuestionsByWeight((double)weight);
                if (listCategoryQuestionByWeight == null)
                {
                    return Ok("Not found");
                }

                var response_weight = _mapper.Map<List<CategoryQuestionViewModel>>(listCategoryQuestionByWeight);
                return Ok(response_weight);
            }

            var listCategoryQuestion = await _categoryQuestionService.GetAllCategoryQuestions();
            var response = _mapper.Map<List<CategoryQuestionViewModel>>(listCategoryQuestion);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryQuestionById(Guid id)
        {
            var categoryQuestion = await _categoryQuestionService.GetCategoryQuestionById(id);
            if (categoryQuestion == null)
            {
                return Ok("Not found");
            }
            var response = _mapper.Map<CategoryQuestionViewModel>(categoryQuestion);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryQuestionsByName(string keyword)
        {
            var listCategoryQuestion = await _categoryQuestionService.GetCategoryQuestionsByName(keyword);
            var response = _mapper.Map<List<CategoryQuestionViewModel>>(listCategoryQuestion);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryQuestionsByWeight(double weight)
        {
            var listCategoryQuestion = await _categoryQuestionService.GetCategoryQuestionsByWeight(weight);
            if (listCategoryQuestion == null)
            {
                return Ok("Not found");
            }
            var response = _mapper.Map<List<CategoryQuestionViewModel>>(listCategoryQuestion);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveCategoryQuestion(CategoryQuestionAddModel categoryQuestion)
        {
            if (categoryQuestion == null)
            {
                return Ok("Not found");
            }
            var modelData = _mapper.Map<CategoryQuestionModel>(categoryQuestion);
            var listCategoryQuestion = await _categoryQuestionService.SaveCategoryQuestion(modelData);
            return Ok(listCategoryQuestion);
        }

        [HttpPut("{categoryQuestionId:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateCategoryQuestion(CategoryQuestionUpdateModel categoryQuestion, Guid categoryQuestionId)
        {
            if (categoryQuestion == null)
            {
                return Ok("Not found");
            }
            var modelData = _mapper.Map<CategoryQuestionModel>(categoryQuestion);
            var listCategoryQuestion = await _categoryQuestionService.UpdateCategoryQuestion(modelData, categoryQuestionId);
            return Ok(listCategoryQuestion);
        }

        [HttpDelete("{requestId:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteCategoryQuestion(Guid requestId)
        {
            try
            {
                var listCategoryQuestion = await _categoryQuestionService.DeleteCategoryQuestion(requestId);
                return Ok(listCategoryQuestion);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}