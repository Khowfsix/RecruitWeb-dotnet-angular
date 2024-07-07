using Api.ViewModels.AdminQuestionLanguage;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class QuestionLanguageController : BaseAPIController
    {
        private readonly IQuestionLanguageService _questionLanguageService;
        private readonly IMapper _mapper;

        public QuestionLanguageController(IQuestionLanguageService questionLanguageService,
            IMapper mapper)
        {
            _questionLanguageService = questionLanguageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionLanguages()
        { 
            var listModelDatas = await _questionLanguageService.GetAllQuestionLanguages();
            var response = _mapper.Map<List<QuestionLanguageViewModel>>(listModelDatas);
            return Ok(response);
        }
    }
}