using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [Authorize]
    public class FileController : BaseAPIController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            var response = await _fileService.AddFileAsync(formFile);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadFiles(List<IFormFile> formFiles)
        {
            var response = await _fileService.AddListFileAsync(formFiles);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var response = await _fileService.DeleteFileAsync(fileName);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFiles(List<string> fileNames)
        {
            var response = await _fileService.DeleteListFileAsync(fileNames);
            return Ok(response);
        }
    }
}
