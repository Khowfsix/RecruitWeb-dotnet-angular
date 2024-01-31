using Api.ViewModels.Skill;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class SkillController : BaseAPIController
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService,
            IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkill(string? query)
        {
            var skilllist = await _skillService.GetAllSkills(query);
            if (skilllist == null)
            {
                return Ok("Not found");
            }
            var result = new List<SkillViewModel>();
            foreach (var skill in skilllist)
            {
                result.Add(_mapper.Map<SkillViewModel>(skill));
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveSkill(SkillAddModel skillModel)
        {
            if (skillModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<SkillModel>(skillModel);
            var skilllist = await _skillService.SaveSkill(model);
            return Ok(skilllist);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateSkill(SkillUpdateModel skillModel, Guid id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<SkillModel>(skillModel);
            var skillList = await _skillService.UpdateSkill(model, id);
            return Ok(skillList);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            if (id != null)
            {
                var skillList = await _skillService.DeleteSkill(id);
                return Ok(skillList);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}