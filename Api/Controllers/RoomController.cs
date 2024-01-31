using Api.ViewModels.Room;
using Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    //[Authorize]
    public class RoomController : BaseAPIController
    {
        private readonly IRoomService _reportService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService reportService,
            IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoom()
        {
            var reportList = await _reportService.GetAllRoom();
            var result = new List<RoomViewModel>();
            foreach (var report in reportList)
            {
                result.Add(_mapper.Map<RoomViewModel>(report));
            }
            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveRoom(RoomAddModel request)
        {
            var model = _mapper.Map<RoomModel>(request);
            var reportList = await _reportService.SaveRoom(model);
            return Ok(reportList);
        }

        [HttpPut("{id:guid}")]
        //[Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateRoom(RoomUpdateModel request, Guid id)
        {
            var model = _mapper.Map<RoomModel>(request);
            var reportList = await _reportService.UpdateRoom(model, id);
            return Ok(reportList);
        }

        [HttpDelete("{id:guid}")]
        //[Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var reportList = await _reportService.DeleteRoom(id);
            return Ok(reportList);
        }
    }
}