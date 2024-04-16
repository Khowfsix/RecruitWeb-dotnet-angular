using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface IFileService
    {
        Task<RawUploadResult> AddFileAsync(IFormFile file);

        Task<IEnumerable<RawUploadResult>> AddListFileAsync(List<IFormFile> files);

        Task<DeletionResult> DeleteFileAsync(string url);

        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listUrls);

        Task<RawUploadResult> UpdateFileAsync(IFormFile newFile, string oldFileUrl);

        Task<IEnumerable<Resource>> GetAllFileAsync();
    }
}