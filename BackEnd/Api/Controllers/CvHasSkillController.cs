using Api.ViewModels.CvHasSkill;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CvHasSkillController : BaseAPIController
    {
        private readonly ICvHasSkillService _cvHasSkillService;
        private readonly IMapper _mapper;

        public CvHasSkillController(ICvHasSkillService cvHasSkillService, IMapper mapper)
        {
            _cvHasSkillService = cvHasSkillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCvHasSkill(string? request)
        {
            var cvHasSkillList = await _cvHasSkillService.GetAllCvHasSkillService(request);
            if (cvHasSkillList == null)
            {
                return Ok("Not found");
            }
            return Ok(cvHasSkillList);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCvHasSkill(CvHasSkillAddModel request)
        {
            var modelData = _mapper.Map<CvHasSkillModel>(request);
            var cvHasSkillList = await _cvHasSkillService.SaveCvHasSkillService(modelData);
            if (cvHasSkillList == null)
            {
                return Ok("Not found");
            }

            return Ok(cvHasSkillList);
        }

        [HttpPut("{requestId:guid}")]
        public async Task<IActionResult> UpdateCvHasSkill(CvHasSkillUpdateModel request, Guid requestId)
        {
            var modelData = _mapper.Map<CvHasSkillModel>(request);
            var cvHasSkillList = await _cvHasSkillService.UpdateCvHasSkillService(modelData, requestId);
            if (cvHasSkillList == null)
            {
                return Ok("Not found");
            }
            return Ok(cvHasSkillList);
        }

        [HttpDelete("{requestId:guid}")]
        public async Task<IActionResult> DeleteCvHasSkill(Guid requestId)
        {
            var cvHasSkillList = await _cvHasSkillService.DeleteCvHasSkillService(requestId);
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (cvHasSkillList == null)
            {
                return Ok("Not found");
            }
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            return Ok(cvHasSkillList);
        }
    }
}