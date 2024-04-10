using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface IFileService
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);

        Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files);

        Task<DeletionResult> DeleteFileAsync(string url);

        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listUrls);

        Task<ImageUploadResult> UpdateFileAsync(IFormFile newFile, string oldFileUrl);

        Task<IEnumerable<Resource>> GetAllFileAsync();
    }
}