using Api.ViewModels.SuccessfulCadidate;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class SuccessfulCadidateController : BaseAPIController
    {
        private readonly ISuccessfulCandidateService _successfulCandidateService;
        private readonly IMapper _mapper;

        public SuccessfulCadidateController(ISuccessfulCandidateService successfulCandidateService,
            IMapper mapper)
        {
            _successfulCandidateService = successfulCandidateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSCs(string? query)
        {
            var SCsList = await _successfulCandidateService.GetAllSuccessfulCadidates(query);
            if (SCsList == null)
            {
                return Ok("Not found");
            }
            var result = new List<SuccessfulCadidateViewModel>();
            foreach (var SC in SCsList)
            {
                result.Add(_mapper.Map<SuccessfulCadidateViewModel>(SC));
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveSC(SuccessfulCadidateAddModel successfulCadidateModel)
        {
            if (successfulCadidateModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<SuccessfulCadidateModel>(successfulCadidateModel);
            var SCsList = await _successfulCandidateService.SaveSuccessfulCadidate(model);
            return Ok(SCsList);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateCS(SuccessfulCadidateUpdateModel successfulCadidateModel, Guid id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<SuccessfulCadidateModel>(successfulCadidateModel);
            var SCsList = await _successfulCandidateService.UpdateSuccessfulCadidate(model, id);
            return Ok(SCsList);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteCS(Guid id)
        {
            if (id != null)
            {
                var SCsList = await _successfulCandidateService.DeleteSuccessfulCadidate(id);
                return Ok(SCsList);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}