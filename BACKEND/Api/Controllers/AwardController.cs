using Api.ViewModels.AdminAward;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class AwardController : BaseAPIController
    {
        private readonly IAwardService _awardService;
        private readonly IMapper _mapper;

        public AwardController(IAwardService awardService,
            IMapper mapper)
        {
            _awardService = awardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAwards()
        { 
            var listModelDatas = await _awardService.GetAllAwards();
            var response = _mapper.Map<List<AwardViewModel>>(listModelDatas);
            return Ok(response);
        }
    }
}