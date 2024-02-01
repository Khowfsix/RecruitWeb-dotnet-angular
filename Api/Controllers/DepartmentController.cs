using Api.ViewModels.Department;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class DepartmentController : BaseAPIController
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment(string? name)
        {
            var modelDatas = await _departmentService.GetAllDepartment(name);
            var departmentList = _mapper.Map<List<DepartmentViewModel>>(modelDatas);
            if (departmentList == null)
            {
                return Ok("Not found");
            }
            return Ok(departmentList);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveDepartment(DepartmentAddModel request)
        {
            var modelData = _mapper.Map<DepartmentModel>(request);
            var departmentList = await _departmentService.SaveDepartment(modelData);
            if (departmentList == null)
            {
                return Ok("Not found");
            }
            return Ok(departmentList);
        }

        [HttpPut("{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateDepartment(DepartmentUpdateModel request, Guid requestId)
        {
            try
            {
                var modelData = _mapper.Map<DepartmentModel>(request);
                var departmentList = await _departmentService.UpdateDepartment(modelData, requestId);
                return Ok(departmentList);
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }

        [HttpDelete("{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment(Guid requestId)
        {
            try
            {
                var departmentList = await _departmentService.DeleteDepartment(requestId);
                return Ok(departmentList);
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }
    }
}