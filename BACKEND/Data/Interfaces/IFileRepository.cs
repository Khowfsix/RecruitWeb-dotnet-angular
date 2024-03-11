using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Data.Interfaces
{
    public interface IFileRepository
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);
        Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files);
        Task<DeletionResult> DeleteFileAsync(string publicId);
        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> publicId);
        Task<IEnumerable<Resource>> GetAllFileAsync();
        Task<ImageUploadResult> UpdateFileAsync(IFormFile file, string oldPublicId);
    }
}