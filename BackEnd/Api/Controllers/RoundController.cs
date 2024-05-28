using Api.ViewModels.Round;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class RoundController : BaseAPIController
    {
        private readonly IRoundService _roundService;
        private readonly IMapper _mapper;

        public RoundController(IRoundService roundService,
            IMapper mapper)
        {
            _roundService = roundService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRound(string? query, Guid? interviewId)
        {
            if (interviewId != null)
            {
                var roundlistOfInterview = await _roundService.GetRoundsOfInterview((Guid)interviewId);
                if (roundlistOfInterview == null)
                {
                    return Ok();
                }

                return Ok(roundlistOfInterview);
            }

            var roundlist = await _roundService.GetAllRounds(query);
            if (roundlist == null)
            {
                return NotFound();
            }

            var result = new List<RoundViewModel>();
            foreach (var round in roundlist)
            {
                result.Add(_mapper.Map<RoundViewModel>(round));
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveRound(RoundAddModel roundModel)
        {
            if (roundModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<RoundModel>(roundModel);
            var roundlist = await _roundService.SaveRound(model);
            return Ok(roundlist);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateRound(RoundUpdateModel roundModel, Guid id)
        {
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            var model = _mapper.Map<RoundModel>(roundModel);
            var roundlist = await _roundService.UpdateRound(model, id);
            return Ok(roundlist);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteRound(Guid id)
        {
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (id != null)
            {
                var roundlist = await _roundService.DeleteRound(id);
                return Ok(roundlist);
            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}