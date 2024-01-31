using Api.ViewModels.Shift;
using Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class ShiftController : BaseAPIController
    {
        private readonly IShiftService _shiftService;
        private readonly IMapper _mapper;

        public ShiftController(IShiftService shiftService,
            IMapper mapper)
        {
            _shiftService = shiftService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShift(int? query)
        {
            var shiftList = await _shiftService.GetAllShifts(query);
            if (shiftList == null)
            {
                return Ok("Not found");
            }
            var result = new List<ShiftViewModel>();
            foreach (var shift in shiftList)
            {
                result.Add(_mapper.Map<ShiftViewModel>(shift));
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> SaveShift(ShiftAddModel shiftModel)
        {
            if (shiftModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<ShiftModel>(shiftModel);
            var shiftList = await _shiftService.SaveShift(model);
            return Ok(shiftList);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> UpdateShift(ShiftUpdateModel shiftModel, Guid id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var model = _mapper.Map<ShiftModel>(shiftModel);
            var shiftList = await _shiftService.UpdateShift(model, id);
            return Ok(shiftList);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Recruiter,Interviewer,Admin")]
        public async Task<IActionResult> DeleteRound(Guid id)
        {
            if (id != null)
            {
                var roundlist = await _shiftService.DeleteShift(id);
                return Ok(roundlist);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}