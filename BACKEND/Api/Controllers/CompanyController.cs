using Api.ViewModels.Company;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CompanyController : BaseAPIController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompany(string? name)
        {
            var modelDatas = await _companyService.GetAllCompany(name);
            var companyList = _mapper.Map<List<CompanyViewModel>>(modelDatas);
            if (companyList == null)
            {
                return Ok("Not found");
            }
            return Ok(companyList);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveCompany(CompanyAddModel request)
        {
            var modelData = _mapper.Map<CompanyModel>(request);
            var companyList = await _companyService.SaveCompany(modelData);
            if (companyList == null)
            {
                return Ok("Not found");
            }
            return Ok(companyList);
        }

        [HttpPut("{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCompany(CompanyUpdateModel request, Guid requestId)
        {
            try
            {
                var modelData = _mapper.Map<CompanyModel>(request);
                var companyList = await _companyService.UpdateCompany(modelData, requestId);
                return Ok(companyList);
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }

        [HttpDelete("{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCompany(Guid requestId)
        {
            try
            {
                var companyList = await _companyService.DeleteCompany(requestId);
                return Ok(companyList);
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }
    }
}