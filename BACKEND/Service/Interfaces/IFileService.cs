using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface IFileService
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);
        Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files);
        Task<DeletionResult> DeleteFileAsync(string path);
        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listId);
    }
}