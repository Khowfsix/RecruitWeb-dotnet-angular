using Api.ViewModels.CandidateJoinEvent;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CandidateJoinEventController : BaseAPIController
    {
        private readonly ICandidateJoinEventService _candidateJoinEventService;
        private readonly IMapper _mapper;

        public CandidateJoinEventController(ICandidateJoinEventService candidateJoinEventService, IMapper mapper)
        {
            _candidateJoinEventService = candidateJoinEventService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidateJoinEvents(string? search, Guid? candidateId, Guid? eventId, string? sortString = "DateJoin_DESC")
        {
            if (candidateId.HasValue)
            {
                var models = await _candidateJoinEventService.GetAllCandidateJoinEventsByCandidateId(candidateId.Value, sortString!);
                var resp = _mapper.Map<List<CandidateJoinEventViewModel>>(models);
                return Ok(resp);
            }

            if (eventId.HasValue)
            {
                var models = await _candidateJoinEventService.GetAllCandidateJoinEventsByEventId(eventId.Value, search, sortString!);
                var resp = _mapper.Map<List<CandidateJoinEventViewModel>>(models);
                return Ok(resp);
            }

            var modelDatas = await _candidateJoinEventService.GetAllCandidateJoinEvents();
            var response = _mapper.Map<List<CandidateJoinEventViewModel>>(modelDatas);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCandidateJoinEvent(CandidateJoinEventAddModel request)
        {
            if (request == null)
            {
                return NotFound();
            }
            var modelData = _mapper.Map<CandidateJoinEventModel>(request);
            var response = await _candidateJoinEventService.SaveCandidateJoinEvent(modelData);
            if (response == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(response);
        }

        [HttpDelete("{requestId:guid}")]
        public async Task<IActionResult> DeleteCandidateJoinEvent(Guid requestId)
        {
            if (requestId.Equals(Guid.Empty))
            {
                return NotFound();
            }
            var response = await (_candidateJoinEventService.DeleteCandidateJoinEvent(requestId));
            return Ok(response);
        }

        [HttpPut("{requestId:guid}")]
        public async Task<IActionResult> UpdateCandidateJoinEvent(CandidateJoinEventUpdateModel request, Guid requestId)
        {
            if (request == null)
            {
                return NotFound();
            }

            var modelData = _mapper.Map<CandidateJoinEventModel>(request);
            var response = await _candidateJoinEventService.UpdateCandidateJoinEvent(modelData, requestId);
            return Ok(response);
        }

        [HttpGet("[action]/{candidateJoinEventId:guid}")]
        public async Task<IActionResult> JoinEventDetail(Guid candidateJoinEventId)
        {
            var modelData = await _candidateJoinEventService.JoinEventDetail(candidateJoinEventId);
            var response = _mapper.Map<CandidateJoinEventViewModel>(modelData);
            return response is not null ? Ok(response) : NotFound();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCandidatesSortedByJoinEventCount()
        {
            var response = await _candidateJoinEventService.GetCandidatesSortedByJoinEventCount();
            return response is not null ? Ok(response) : NotFound();
        }
    }
}