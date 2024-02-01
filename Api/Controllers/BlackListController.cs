using Api.ViewModels.BlackList;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin,Recruiter,Interviewer")]
    public class BlackListController : BaseAPIController
    {
        private readonly IBlacklistService _blacklistService;
        private readonly IMapper _mapper;

        public BlackListController(IBlacklistService blacListService, IMapper mapper)
        {
            _blacklistService = blacListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlackList()
        {
            var listModelDatas = await _blacklistService.GetAllBlackLists();
            var response = _mapper.Map<List<BlacklistViewModel>>(listModelDatas);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBlackList(BlackListAddModel request)
        {
            if (request == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var modelData = _mapper.Map<BlacklistModel>(request); // <BlackListModel>
            var response = await _blacklistService.SaveBlackList(modelData);
            return Ok(response);
        }

        [HttpDelete("{requestId:guid}")]
        public async Task<IActionResult> DeleteBlackList(Guid requestId)
        {
            if (requestId.Equals(Guid.Empty))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var response = await _blacklistService.DeleteBlackList(requestId);
            return Ok(response);
        }

        [HttpPut("{requestId:guid}")]
        public async Task<IActionResult> UpdateBlackList(BlackListUpdateModel request, Guid requestId)
        {
            if (request == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var modelData = _mapper.Map<BlacklistModel>(request);
            var response = await _blacklistService.UpdateBlackList(modelData, requestId);
            return Ok(response);
        }
    }
}