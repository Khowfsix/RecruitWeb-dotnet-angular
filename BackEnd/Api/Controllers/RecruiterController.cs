using Api.ViewModels.Position;
using Api.ViewModels.Recruiter;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
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

    [HttpPut("[action]/{requestId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStatus(Guid requestId, bool isActived, bool isDeleted)
    {
        try
        {
            var result = await _recruiterService.UpdateStatus(isActived, isDeleted, requestId);
            return Ok(result);
        }
        catch (Exception)
        {
            return Ok("Not found");
        }
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
    [Authorize]
    public async Task<IActionResult> SaveRecruiter(RecruiterAddModel request)
    {
        var model = _mapper.Map<RecruiterModel>(request);
        var response = await _recruiterService.SaveRecruiter(model);
        if (response != null)
        {
            return Ok(response);
        }
        return BadRequest(request);
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
    [Authorize(Roles = "Admin,Recruiter,Candidate")]
    public async Task<IActionResult> GetRecruiterByUserId(string userId, bool? isDeleted)
    {
        if (isDeleted == false)
        {
            var model1 = await _recruiterService.GetNotDeletedRecruiterByUserId(userId);
            var response1 = _mapper.Map<RecruiterViewModel>(model1);
            return Ok(response1);
        }

        var model = await _recruiterService.GetRecruiterByUserId(userId);
        var response = _mapper.Map<RecruiterViewModel>(model);
        return Ok(response);
    }
}