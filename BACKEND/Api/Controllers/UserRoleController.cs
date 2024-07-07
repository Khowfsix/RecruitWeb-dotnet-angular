using Api.ViewModels.UserRole;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class UserRoleController : BaseAPIController
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService UserRoleService, IMapper mapper)
        {
            _userRoleService = UserRoleService;
            _mapper = mapper;
        }
            
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var modelDatas = await _userRoleService.GetAllUserRoles();
            var response = _mapper.Map<List<UserRoleViewModel>>(modelDatas);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveUserRole(UserRoleAddModel userRoleAddModel)
        {
            if (userRoleAddModel == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var modelData = _mapper.Map<UserRoleModel>(userRoleAddModel);
            var response = await _userRoleService.SaveUserRole(modelData);
            return Ok(_mapper.Map<UserRoleViewModel>(response));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserRole(UserRoleDeleteModel userRoleDeleteModel)
        {
            if (userRoleDeleteModel == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var modelData = _mapper.Map<UserRoleModel>(userRoleDeleteModel);
            var response = await _userRoleService.DeleteUserRole(modelData);
            return Ok(_mapper.Map<UserRoleViewModel>(response));
        }
    }
}