using Api.ViewModels.SecurityQuestion;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class SecurityQuestionController : BaseAPIController
    {
        private readonly ISecurityQuestionService _securityQuestionService;
        private readonly IMapper _mapper;

        public SecurityQuestionController(ISecurityQuestionService securityQuestionService,
            IMapper mapper)
        {
            _securityQuestionService = securityQuestionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSecurityQuestion()
        {
            var listSecurityQuestion = await _securityQuestionService.GetAllSecurityQuestion();
            if (listSecurityQuestion == null)
            {
                return Ok("Not found");
            }
            var result = new List<SecurityQuestionViewModel>();
            foreach (var item in listSecurityQuestion)
            {
                result.Add(_mapper.Map<SecurityQuestionViewModel>(item));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSecurityQuestion(SecurityQuestionAddModel request)
        {
            if (request == null)
            {
                return Ok("Not found");
            }
            var model = _mapper.Map<SecurityQuestionModel>(request);
            var listSecurityQuestion = await _securityQuestionService.SaveSecurityQuestion(model);
            return Ok(listSecurityQuestion);
        }

        [HttpPut("{categoryQuestionId:guid}")]
        public async Task<IActionResult> UpdateSecurityQuestion(SecurityQuestionUpdateModel request, Guid requestId)
        {
            if (request == null)
            {
                return Ok("Not found");
            }
            var model = _mapper.Map<SecurityQuestionModel>(request);
            var listSecurityQuestion = await _securityQuestionService.UpdateSecurityQuestion(model, requestId);
            return Ok(listSecurityQuestion);
        }

        [HttpDelete("{requestId:guid}")]
        public async Task<IActionResult> DeleteSecurityQuestion(Guid requestId)
        {
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (requestId == null)
            {
                return Ok("Not found");
            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            var listCategoryQuestion = await _securityQuestionService.DeleteSecurityQuestion(requestId);
            return Ok(listCategoryQuestion);
        }
    }
}