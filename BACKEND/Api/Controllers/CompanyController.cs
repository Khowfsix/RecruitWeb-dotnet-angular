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
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IFileService fileService, IMapper mapper)
        {
            _companyService = companyService;
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCompany(string? name)
        {
            var isAdmin = HttpContext.User.IsInRole("Admin");
            var modelDatas = await _companyService.GetAllCompany(isAdmin, name);
            var companyList = _mapper.Map<List<CompanyViewModel>>(modelDatas);
            if (companyList == null)
            {
                return NotFound();
            }
            return Ok(companyList);
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveCompany([FromForm] CompanyAddModel companyInfo, IFormFile? logo)
        {
            var modelData = _mapper.Map<CompanyModel>(companyInfo);

            if (logo != null)
            {
                var RawUploadResult = await _fileService.AddFileAsync(logo);
                modelData.Logo = RawUploadResult.Url.OriginalString;
            }

            var companyList = await _companyService.SaveCompany(modelData);
            if (companyList == null)
            {
                return NotFound();
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
                return NotFound();
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
                return NotFound();
            }
        }
    }
}