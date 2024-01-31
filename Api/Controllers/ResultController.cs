using Api.ViewModels.Result;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class ResultController : BaseAPIController
    {
        private readonly IResultService _reportService;
        private readonly IMapper _mapper;

        public ResultController(IResultService reportService,
            IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResult()
        {
            var reportList = await _reportService.GetAllResult();
            var result = new List<ResultViewModel>();
            foreach (var report in reportList)
            {
                result.Add(_mapper.Map<ResultViewModel>(report));
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveResult(ResultAddModel request)
        {
            var model = _mapper.Map<ResultModel>(request);
            var reportList = await _reportService.SaveResult(model);
            return Ok(reportList);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateResult(ResultUpdateModel request, Guid id)
        {
            var model = _mapper.Map<ResultModel>(request);
            var reportList = await _reportService.UpdateResult(model, id);
            return Ok(reportList);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteResult(Guid id)
        {
            var reportList = await _reportService.DeleteResult(id);
            return Ok(reportList);
        }
    }
}