using CloudinaryDotNet.Actions;
using Api.ViewModels.Question;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]

    public class QuestionController : BaseAPIController
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService,
            IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions(string? query, Guid? questionId)
        {
            if (questionId != null)
            {
                var questionList = await _questionService.GetAllQuestions(null, (Guid)questionId);
                if (questionList == null)
                {
                    return Ok();
                }
                List<QuestionViewModel> results = new List<QuestionViewModel>();
                foreach (var models in questionList)
                {
                    results.Add(_mapper.Map<QuestionViewModel>(models));
                }
                return Ok(results);
            }

            var listQuestion = await _questionService.GetAllQuestions(query, null);
            if (listQuestion == null)
            {
                return Ok("Not found");
            }
            List<QuestionViewModel> viewModels = new List<QuestionViewModel>();
            foreach (var models in listQuestion)
            {
                viewModels.Add(_mapper.Map<QuestionViewModel>(models));
            }
            return Ok(viewModels);
        }

        [HttpGet("[action]/Language")]
        public async Task<IActionResult> GetAllLanguageQuestions()
        {
            var listQuestion = await _questionService.GetAllLanguageQuestions();
            List<QuestionViewModel> viewModels = new List<QuestionViewModel>();
            foreach (var models in listQuestion)
            {
                viewModels.Add(_mapper.Map<QuestionViewModel>(models));
            }
            return Ok(viewModels);
        }

        [HttpGet("[action]/SoftSkill")]
        public async Task<IActionResult> GetAllSoftSkillQuestions()
        {
            var listQuestion = await _questionService.GetAllSoftSkillQuestions();
            List<QuestionViewModel> viewModels = new List<QuestionViewModel>();
            foreach (var models in listQuestion)
            {
                viewModels.Add(_mapper.Map<QuestionViewModel>(models));
            }
            return Ok(viewModels);
        }

        [HttpGet("[action]/Technology")]
        public async Task<IActionResult> GetAllTechnologyQuestions()
        {
            var listQuestion = await _questionService.GetAllTechnologyQuestions();
            List<QuestionViewModel> viewModels = new List<QuestionViewModel>();
            foreach (var models in listQuestion)
            {
                viewModels.Add(_mapper.Map<QuestionViewModel>(models));
            }
            return Ok(viewModels);
        }

        [HttpGet("[action]/{questionId:guid}")]
        public async Task<IActionResult> GetQuestion(Guid questionId)
        {
            var model = await _questionService.GetQuestion(questionId);
            return model is not null ? Ok(_mapper.Map<QuestionViewModel>(model)) : Ok("Not found");
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> AddQuestion(QuestionAddModel question)
        {
            var model = _mapper.Map<QuestionModel>(question);
            var response = await _questionService.AddQuestion(model);
            return response is not null ? Ok(response)
                                    : BadRequest(question);
        }
        //[Authorize(Roles = "Recruiter")]
        [HttpPut("{questionId:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateQuestion
        (QuestionUpdateModel question, Guid questionId)
        {
            var model = _mapper.Map<QuestionModel>(question);
            var response = await _questionService.UpdateQuestion(model, questionId);
            return response is true ? Ok(true) : Ok("Not found");
        }

        [HttpDelete("{questionId:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> RemoveQuestion(Guid questionId)
        {
            var response = await _questionService.RemoveQuestion(questionId);
            return response is true ? Ok(true) : Ok("Not found");
        }
    }
}