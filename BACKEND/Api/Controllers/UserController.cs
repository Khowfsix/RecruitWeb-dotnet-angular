
using Api.ViewModels.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class UserController : BaseAPIController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService UserService, IMapper mapper)
        {
            _userService = UserService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var modelDatas = await _userService.GetAllUsers();
            var response = _mapper.Map<List<AdminUserViewModel>>(modelDatas.ToList());
            return Ok(response);
        }
    }
}