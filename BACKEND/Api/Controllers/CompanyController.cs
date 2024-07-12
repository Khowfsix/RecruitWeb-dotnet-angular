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

        [HttpGet("{requestId:guid}")]
        [Authorize(Roles = "Admin,Recruiter")]
        public async Task<IActionResult> GetCompanyById(Guid requestId)
        {
            try
            {
                var isAdmin = HttpContext.User.IsInRole("Admin");
                var company = await _companyService.GetCompanyById(isAdmin, requestId);
                return Ok(_mapper.Map<CompanyViewModel>(company));
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize]
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
        [Authorize(Roles = "Admin,Recruiter")]
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

        [HttpPut("[action]/{requestId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(Guid requestId, bool isActived, bool isDeleted)
        {
            try
            {
                var updatedCompany = await _companyService.UpdateStatus(isActived, isDeleted, requestId);
                return Ok(updatedCompany);
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
                return NotFound();
            }
        }
    }
}