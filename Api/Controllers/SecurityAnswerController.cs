using Api.ViewModels.SecurityAnswer;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class SecurityAnswerController : BaseAPIController
    {
        private readonly ISecurityAnswerService _securityAnswerService;
        private readonly IMapper _mapper;

        public SecurityAnswerController(ISecurityAnswerService securityAnswerService,
            IMapper mapper)
        {
            _securityAnswerService = securityAnswerService;
            _mapper = mapper;
        }

        // GET: api/<SecurityQuestionController>
        [HttpGet]
        public async Task<IActionResult> GetAllSecurityAnswers(string req)
        {
            var reportList = await _securityAnswerService.GetAllSecurityAnswers();
            var result = new List<SecurityAnswerViewModel>();
            foreach (var report in reportList)
            {
                result.Add(_mapper.Map<SecurityAnswerViewModel>(report));
            }
            return Ok(result);
        }

        // POST api/<SecurityQuestionController>
        [HttpPost]
        public async Task<IActionResult> SaveSecurityAnswer(SecurityAnswerAddModel req)
        {
            var model = _mapper.Map<SecurityAnswerModel>(req);
            var sqList = await _securityAnswerService.SaveSecurityAnswer(model);
            return Ok(sqList);
        }

        // PUT api/<SecurityQuestionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSecurityAnswer(SecurityAnswerUpdateModel req, Guid id)
        {
            var model = _mapper.Map<SecurityAnswerModel>(req);
            var reportList = await _securityAnswerService.UpdateSecurityAnswer(model, id);
            return Ok(reportList);
        }

        // DELETE api/<SecurityQuestionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecurityAnswer(Guid id)
        {
            var reportList = await _securityAnswerService.DeleteSecurityAnswer(id);
            return Ok(reportList);
        }
    }
}