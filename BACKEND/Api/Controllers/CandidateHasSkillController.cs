using Api.ViewModels.CandidateHasSkill;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class CandidateHasSkillController : BaseAPIController
    {
        private readonly ICandidateHasSkillService _candidateHasSkillService;
        private readonly IMapper _mapper;

        public CandidateHasSkillController(ICandidateHasSkillService candidateHasSkillService, IMapper mapper)
        {
            _candidateHasSkillService = candidateHasSkillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidateHasSkill(Guid? candidateId)
        {
            if (candidateId.HasValue)
            {
                var models = await _candidateHasSkillService.GetAllByCandidateId(candidateId.Value);
                return (models != null) ? Ok(_mapper.Map<List<CandidateHasSkillViewModel>>(models)) : Ok("Not found");
            }
            
            return Ok("Not found");
        }
    }
}