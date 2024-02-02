using Api.ViewModels.Application;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers;

[Authorize]
public class ApplicationHistoryController : BaseAPIController
{
    private readonly IApplicationService _applicationService;
    private readonly IMapper _mapper;

    public ApplicationHistoryController(IApplicationService applicationService, IMapper mapper)
    {
        _applicationService = applicationService;
        _mapper = mapper;
    }

    [HttpGet("{candidateId:guid}")]
    public async Task<IActionResult> GetApplicationHistory(Guid candidateId)
    {
        var modelDatas = await _applicationService.GetApplicationHistory(candidateId);
        var response = _mapper.Map<List<ApplicationHistoryViewModel>>(modelDatas);
        return Ok(response);
    }
}