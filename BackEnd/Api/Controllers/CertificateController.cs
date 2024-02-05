using Api.ViewModels.Certificate;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

namespace Api.Controllers
{
    [Authorize]
    public class CertificateController : BaseAPIController
    {
        private readonly ICertificateService _certificateService;
        private readonly IMapper _mapper;

        public CertificateController(ICertificateService certificateService, IMapper mapper)
        {
            _certificateService = certificateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCertificate(string? request)
        {
            var modelDatas = await _certificateService.GetAllCertificate(request);
            var response = _mapper.Map<List<CertificateViewModel>>(modelDatas);
            if (response == null)
            {
                return Ok("Not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCertificate(CertificateAddModel request)
        {
            var modelData = _mapper.Map<CertificateModel>(request);
            var response = await _certificateService.SaveCertificate(modelData);
            if (response == null)
            {
                return Ok("Not found");
            }
            return Ok(response);
        }

        [HttpPut("{requestId:guid}")]
        public async Task<IActionResult> UpdateCertificate(CertificateUpdateModel request, Guid requestId)
        {
            try
            {
                var modelData = _mapper.Map<CertificateModel>(request);
                var response = await _certificateService.UpdateCertificate(modelData, requestId);
                return Ok(response);
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }

        [HttpDelete("{requestId:guid}")]
        public async Task<IActionResult> DeleteCertificate(Guid requestId)
        {
            try
            {
                var response = await (_certificateService.DeleteCertificate(requestId));
                return Ok(response);
            }
            catch (Exception)
            {
                return Ok("Not found");
            }
        }
    }
}