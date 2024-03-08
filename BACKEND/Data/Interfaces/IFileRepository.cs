using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Data.Interfaces
{
    public interface IFileRepository
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);
        Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files);
        Task<DeletionResult> DeleteFileAsync(string path);
        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listId);
    }
}