using Api.ViewModels.QuestionSkill;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class QuestionSkillController : BaseAPIController
    {
        private readonly IQuestionSkillService _questionSkillService;
        private readonly IMapper _mapper;

        public QuestionSkillController(IQuestionSkillService questionSkillService,
            IMapper mapper)
        {
            _questionSkillService = questionSkillService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> AddQuestionSkill(QuestionSkillAddModel questionSkill)
        {
            var model = _mapper.Map<QuestionSkillModel>(questionSkill);
            var response = await _questionSkillService.AddQuestionSkill(model);

            return response is not null ?
            Ok(response) :
            BadRequest(questionSkill);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionSkills()
        {
            var models = await _questionSkillService.GetAllQuestionSkills();
            List<QuestionSkillViewModel> result = new List<QuestionSkillViewModel>();
            foreach (var model in models)
            {
                result.Add(_mapper.Map<QuestionSkillViewModel>(model));
            }
            return Ok(result);
        }

        [HttpDelete("{questionSkillId:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> RemoveQuestionSkill(Guid questionSkillId)
        {
            var response = await _questionSkillService.RemoveQuestionSkill(questionSkillId);
            return response is true ? Ok(true) : NotFound(questionSkillId);
        }

        [HttpPut("{questionSkillId:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateQuestionSkill
        (QuestionSkillUpdateModel questionSkill, Guid questionSkillId)
        {
            var model = _mapper.Map<QuestionSkillModel>(questionSkill);
            var response =
                await _questionSkillService.UpdateQuestionSkill(model, questionSkillId);
            return response is true ? Ok(true) : NotFound(questionSkillId);
        }
    }
}