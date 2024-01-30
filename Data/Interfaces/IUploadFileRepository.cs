using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Data.Interfaces
{
    public interface IUploadFileRepository
    {
        Task<ImageUploadResult> AddFileAsync(IFormFile file);
        Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files);
        Task<DeletionResult> DeleteFileAsync(string path);
        Task<bool> DeleteFileAsyncBool(string path);
        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listId);
        //Task<FileContentResult> DownloadFileAsync(string path);
    }
}
