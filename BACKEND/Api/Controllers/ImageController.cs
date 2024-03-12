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
        public async Task<IActionResult> DeleteFile(string url)
        {
            var response = await _fileService.DeleteFileAsync(url);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteFiles(List<string> listUrls)
        {
            var response = await _fileService.DeleteListFileAsync(listUrls);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateFile([FromForm] string oldImageUrl, IFormFile newImage)
        {
            var response = await _fileService.UpdateFileAsync(newImage, oldImageUrl);
            if (response != null)
            {
                return Ok(response);
            }
            return Ok("Can't update image");
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFile()
        {
            var response = await _fileService.GetAllFileAsync();
            return Ok(response);
        }
    }
}
