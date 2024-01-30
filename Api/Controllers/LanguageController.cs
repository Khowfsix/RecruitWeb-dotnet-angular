using Api.ViewModels.Language;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class LanguageController : BaseAPIController
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguages(Guid? languageId, string? languageName)
        {
            if (languageId != null)
            {
                var languageById = await _languageService.GetLanguage((Guid)languageId);
                if (languageById == null)
                {
                    return Ok();
                }

                var viewModelDatas = _mapper.Map<LanguageViewModel>(languageById);
                return Ok(viewModelDatas);
            }
            else if (languageName != null)
            {
                var languagesByName = await _languageService.GetLanguage(languageName);
                if (languagesByName == null)
                {
                    return Ok();
                }

                var viewModelDatas = _mapper.Map<List<LanguageViewModel>>(languagesByName);
                return Ok(languagesByName);
            }

            var getallModelDatas = await _languageService.GetAllLanguages();
            return Ok(_mapper.Map<List<LanguageViewModel>>(getallModelDatas));
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> AddLanguage(LanguageAddModel obj)
        {
            var modelData = _mapper.Map<LanguageModel>(obj);
            var response = await _languageService.AddLanguage(modelData);
            return response is not null ? Ok(response) : BadRequest(obj);
        }

        [HttpPut("{languageId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateLanguage(LanguageUpdateModel obj, Guid languageId)
        {
            if (obj is null)
            {
                return BadRequest();
            }

            var modelData = _mapper.Map<LanguageModel>(obj);
            var response = await _languageService.UpdateLanguage(modelData, languageId);
            return response is true ? Ok(true) : NotFound(languageId);
        }

        [HttpDelete("{languageId:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLanguage(Guid languageId)
        {
            var response = await _languageService.RemoveLanguage(languageId);
            return response is true ? Ok(true) : NotFound(languageId);
        }
    }
}