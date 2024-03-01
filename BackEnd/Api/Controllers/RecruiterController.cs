using Api.ViewModels.Recruiter;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers;

[Authorize]
public class RecruiterController : BaseAPIController
{
    private readonly IRecruiterService _recruiterService;
    private readonly IMapper _mapper;

    public RecruiterController(IRecruiterService recruiterService,
        IMapper mapper)
    {
        _recruiterService = recruiterService;
        _mapper = mapper;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllRecruiter(Guid? id)
    {
        if (id != null)
        {
            var data = await _recruiterService.GetRecruiterById((Guid)id);
            return data switch
            {
                null => NotFound(),
                _ => Ok(_mapper.Map<RecruiterViewModel>(data))
            };
        }

        var reportList = await _recruiterService.GetAllRecruiter();
        List<RecruiterViewModel> viewModels = new List<RecruiterViewModel>();
        foreach (var report in reportList)
        {
            viewModels.Add(_mapper.Map<RecruiterViewModel>(report));
        }
        return Ok(viewModels);
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SaveRecruiter(RecruiterAddModel request)
    {
        var model = _mapper.Map<RecruiterModel>(request);
        var response = await _recruiterService.SaveRecruiter(model);
        if (response != null)
        {
            return Ok(response);
        }
        return Ok("Can not create recruiter");
    }

    [HttpPut("[action]/{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateRecruiter(RecruiterUpdateModel request, Guid id)
    {
        var model = _mapper.Map<RecruiterModel>(request);
        return await _recruiterService.UpdateRecruiter(model, id) ? Ok(true) : BadRequest();
    }

    [HttpDelete("[action]/{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteRecruiter(Guid id)
    {
        return await _recruiterService.DeleteRecruiter(id) ? Ok(true) : NotFound();
    }

    [HttpGet("[action]/{userId}")]
    [Authorize(Roles = "Admin,Recruiter")]
    public async Task<IActionResult> GetRecruiterByUserId(string userId)
    {
        var model = await _recruiterService.GetRecruiterByUserId(userId);
        var response = _mapper.Map<RecruiterViewModel>(model);
        return Ok(response);
    }
}