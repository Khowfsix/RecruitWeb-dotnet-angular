using Api.ViewModels.Role;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class RoleController : BaseAPIController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
            
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var modelDatas = await _roleService.GetAllRoles();
            var response = _mapper.Map<List<RoleViewModel>>(modelDatas);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetRoleById(string id)
        {
            RoleModel? modelDatas = await _roleService.GetRoleById(id);
            if (modelDatas == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var response = _mapper.Map<RoleViewModel>(modelDatas);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRole(RoleAddModel roleAddModel)
        {
            if (roleAddModel == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var modelData = _mapper.Map<RoleModel>(roleAddModel);
            var response = await _roleService.SaveRole(modelData);
            return Ok(_mapper.Map<RoleModel>(response));
        }

        [HttpPut("{roleId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(
            RoleUpdateModel roleUpdateModel,
            string roleId
        )
        {
            if (roleUpdateModel == null)
                return StatusCode(StatusCodes.Status400BadRequest);
            var modelData = _mapper.Map<RoleModel>(roleUpdateModel);
            var response = await _roleService.UpdateRole(modelData, roleId);
            return Ok(response);
        }
    }
}